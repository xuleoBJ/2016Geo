using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DOGPlatform
{  ///
   /// 加新导入的测井曲线格式需要以下几个部分的修改
   /// 1. enum 类型加
   /// 2. 下拉选择列表加
   /// 3. 选择文件头inputLog类加
    ///4  寻找到数据行，调用读取数据数据的方法，注意输入数据其实行
    public partial class FormDataImportLog : Form
    {
        public FormDataImportLog(string _sJH)
        {
            InitializeComponent();
            initializeForm(_sJH);
        }
        enum FormatLogFile
        {
            forward1,
            ascii,
            list,
            las,
            las2,
        }

        string sJH="";
        string filePathSourceLogFile = "";
        FormatLogFile currentFormat = FormatLogFile.forward1;

        void initializeForm(string _sJH)
        {
            this.Text = _sJH;
            this.sJH=_sJH;
            List<string> logFormatText = new List<string>();
            logFormatText.Add(FormatLogFile.forward1.ToString());
            logFormatText.Add(FormatLogFile.ascii.ToString());
            logFormatText.Add(FormatLogFile.list.ToString());
            logFormatText.Add(FormatLogFile.las.ToString());
            logFormatText.Add(FormatLogFile.las2.ToString());
            cbbLogFormat.DataSource = logFormatText;
            this.cbbLogFormat.SelectedIndex = 0;
        }
        //必须跟下拉菜单的顺序一样
        private void cbbLogFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentFormat = (FormatLogFile)cbbLogFormat.SelectedIndex;
        }

        private void btnOpenEX_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdfilePathLog = new OpenFileDialog();

            ofdfilePathLog.Title = sJH;
            ofdfilePathLog.Filter = "所有文件|*.*|las文件|*.las|las2文件|*.las|txt文件|*.txt|list文件|*.list";
            //设置默认文件类型显示顺序 
            ofdfilePathLog.FilterIndex = 1;

            string logDir = Path.Combine(cProjectManager.dirPathWellDir, this.sJH , "测井");
            if (Directory.Exists(logDir)) ofdfilePathLog.InitialDirectory = logDir;
            else ofdfilePathLog.RestoreDirectory = true;
            if (ofdfilePathLog.ShowDialog() == DialogResult.OK)
            {
                filePathSourceLogFile=ofdfilePathLog.FileName;
                this.tbxUserFilePath.Text = filePathSourceLogFile;
                cPublicMethodForm.textboxViewText(this.tbxView, filePathSourceLogFile, 50);
                dgvLog.Rows.Clear();
            }
            
        }

        List<string> getListLogHeadByLogFormat(string filepath) 
        {
            List<string> listLogHeadColumn = new List<string>();
            if (currentFormat==FormatLogFile.forward1) listLogHeadColumn=cIOinputLog.getLogSerierNamesFromLogForward(filepath);
            if (currentFormat==FormatLogFile.ascii) listLogHeadColumn = cIOinputLog.getLogSerierNamesFromTXTLog(filepath);
            if (currentFormat == FormatLogFile.list) listLogHeadColumn = cIOinputLog.getLogSerierNamesFromListLog(filepath);
            if (currentFormat == FormatLogFile.las) listLogHeadColumn = cIOinputLog.getLogSerierNamesFromLasLog(filepath);
            if (currentFormat == FormatLogFile.las2) listLogHeadColumn = cIOinputLog.getLogSerierNamesFromLasV2Log(filepath);
            return listLogHeadColumn; 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //depth can't delete need deal
            cPublicMethodForm.deleteSelectedCurrentRowDGV(dgvLog);
        }
        private void wait4import(object sender, WaitWindowEventArgs e)
        { 
            //首先更新测井全局字典
            //字典里是否存在要导入的曲线，如果存在看单位，如果不存在加入
            updateLogDic();
            //导入曲线
            importLog(); //导入时更新了全局测井曲线，然后主界面刷新
        }

        void updateLogDic()
        {
            List<ItemDicLogGlobe> logHeadRet = cIODicLogHeadProject.readDicGlobeLog();
            for (int i = 0; i < dgvLog.Rows.Count - 1; i++)
            {
                if(dgvLog.Rows[i].Cells["logNameNew"].Value!=null &&  dgvLog.Rows[i].Cells["logSUnit"].Value!=null)
                {
                string sID=dgvLog.Rows[i].Cells["logNameNew"].Value.ToString();
                string mUnit = dgvLog.Rows[i].Cells["logSUnit"].Value.ToString();
                ItemDicLogGlobe selectItem=logHeadRet.FirstOrDefault(p => p.sLogID == sID);
                if (selectItem == null)
                {
                    ItemDicLogGlobe newItem =new ItemDicLogGlobe(sID);
                    newItem.sUnit = mUnit;
                    logHeadRet.Add(newItem);
                }
                else if(mUnit.Trim()!="") selectItem.sUnit = mUnit;
            }
            }
            cIODicLogHeadProject.writeDicGlobe(logHeadRet);
          
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            WaitWindow.Show(this.wait4import);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        void importLog() 
        {
            if (currentFormat == FormatLogFile.forward1) importTextLogText(7); 
            if (currentFormat == FormatLogFile.ascii) importTextLogText(2);
            if (currentFormat == FormatLogFile.list) importTextLogText(4); 
            if (currentFormat == FormatLogFile.las) importTextLogText(cIOinputLog.getDataStartLineOfLasLog(filePathSourceLogFile));
            if (currentFormat == FormatLogFile.las2) importTextLogText(cIOinputLog.getDataStartLineOfLasLog(filePathSourceLogFile)); 
        }
        public  void importTextLogText(int _iDataStartLine)
        {
            List<string> ltStrLogHead = new List<string>();
            List<int> ltIndexLog = new List<int>();

            for (int i = 0; i < dgvLog.Rows.Count - 1; i++)
            {
                ltStrLogHead.Add(dgvLog.Rows[i].Cells["logNameNew"].Value.ToString());
                ltIndexLog.Add(Convert.ToInt16(dgvLog.Rows[i].Cells["logNum"].Value) - 1); //指数比列多1
            }
            for (int i = 0; i < ltIndexLog.Count; i++)
            {
                string logName = ltStrLogHead[i].Replace("/",".");
                int _indexLog = ltIndexLog[i];
                string filePathLog = Path.Combine(cProjectManager.dirPathWellDir, sJH, logName + cProjectManager.fileExtensionWellLog);
                List<string> _ltLogFileHead = new List<string>();
                _ltLogFileHead.Add("Depth");
                _ltLogFileHead.Add(logName);
                string _firstLine = sJH + " " + logName + " source:" + this.filePathSourceLogFile 
                    + " columnNum:" + (_indexLog+1).ToString() + " " + DateTime.Now.ToString();
                //如果已经存在同名曲线就加_same标记
                if (File.Exists(filePathLog))
                {
                    logName += "_Same";
                    filePathLog = Path.Combine(cProjectManager.dirPathWellDir, sJH, logName + cProjectManager.fileExtensionWellLog);
                }
                cIOGeoEarthText.creatFileGeoHeadText(filePathLog, _firstLine, _ltLogFileHead);
                cIOGeoEarthText.addDataLines2GeoEarTxt(filePathLog, cIOinputLog.readLogData(filePathSourceLogFile, _iDataStartLine, _indexLog)); 
            }

            //全局测井头更新
            foreach (string _s in ltStrLogHead)
                if (cProjectData.ltStrProjectGlobeLog.IndexOf(_s) < 0) cProjectData.ltStrProjectGlobeLog.Add(_s);
            
            //保留原输入测井数据,刚才导入时loghead删除了depth，保留文件时加上
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameInputWellLog);
            ltStrLogHead.Insert(0, "DEPTH");
            cIOGeoEarthText.creatFileGeoHeadText(filePath, sJH, ltStrLogHead);
            ltIndexLog.Insert(0, 0);
            cIOGeoEarthText.addDataLines2GeoEarTxt(filePath, cIOinputLog.readLogData(filePathSourceLogFile, _iDataStartLine, ltIndexLog));
            MessageBox.Show("导入完成。");
        }


        private void btnShowLogHead_Click(object sender, EventArgs e)
        {
            List<string> ltStrHead = getListLogHeadByLogFormat(filePathSourceLogFile);
            dgvLog.Rows.Clear();
            char[] charsToTrim = { '.', ' ', '\'',':'};
            List<string> ltUnit = new List<string>();
            List<string> ltLogID=new List<string>();

            foreach (string line in ltStrHead) 
            {
                 string[] split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                 ltLogID.Add(split[0]);
                 if (split.Length >= 2 && (currentFormat == FormatLogFile.las2 || currentFormat == FormatLogFile.las))
                     ltUnit.Add(split[1]);
                 else
                 {
                  ltUnit.Add(""); 
                 }
            }

            for (int i = 0; i < ltStrHead.Count; i++)
            {
                this.dgvLog.Rows.Add(ltLogID[i], (i + 2).ToString(), ltLogID[i].ToUpper().Trim(charsToTrim), ltUnit[i].Trim(charsToTrim));
            }
        }

        private void btnOpenProjectDirLog_Click(object sender, EventArgs e)
        {
            string logDir = Path.Combine(cProjectManager.dirPathWellDir, this.sJH , "测井");
            if (Directory.Exists(logDir))
            {
                string[] wellLogItemLas = Directory.GetFiles(logDir, "*.las");
                string[] wellLogItemText = Directory.GetFiles(logDir, "*.txt");
                string[] mergeItem = wellLogItemLas.Concat(wellLogItemText).ToArray();
                if (mergeItem.Count() > 0)
                {
                    filePathSourceLogFile = Path.Combine(logDir, mergeItem[0]);
                    for (int i = 1; i < mergeItem.Count(); i++)
                    {
                        FileInfo fLog = new FileInfo(filePathSourceLogFile);
                        string curFile = Path.Combine(logDir, mergeItem[i]);
                        FileInfo fCur = new FileInfo(curFile);
                        if (fCur.Length > fLog.Length) filePathSourceLogFile = curFile;
                    }

                    readLogSourceFile(filePathSourceLogFile);
                }
                else
                {
                    MessageBox.Show("资料管理目录中测井曲线不存在");
                }
            } //end 目录存在判断。
        }

        void readLogSourceFile(string filePath) 
        {
            this.tbxUserFilePath.Text = filePath;
            dgvLog.Rows.Clear();
            cPublicMethodForm.textboxViewText(this.tbxView, filePath, 100);
        }

        private void FormDataImportLog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FormDataImportLog_DragDrop(object sender, DragEventArgs e)
        {
            string[] directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
            //get all files inside folder            
            foreach (string fileDrop in directoryName)
            {
                readLogSourceFile(fileDrop);
            }   
        }

      

       


    }
}
