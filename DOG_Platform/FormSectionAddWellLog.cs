using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace DOGPlatform
{
    public partial class FormSectionAddWellLog : Form
    {
        public ItemLogHeadInfor logHeadRet = new ItemLogHeadInfor();

        public FormSectionAddWellLog(string _sJH)
        {

            InitializeComponent();
            initializaMycontrols(_sJH);
        }
        void initializaMycontrols(string _sJH)
        {
            logHeadRet.sJH = _sJH;
            logHeadRet.sLogColor = "black";
            logHeadRet.fLeftValue = 0.0f;
            logHeadRet.fRightValue = 100.0f;
            logHeadRet.fLineWidth = 1.0f;
            this.tbxJH.Text = logHeadRet.sJH;
            initialCbbLog();
        }

        void initialCbbLog() 
        {
            cbbLog.Items.Clear();
            string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, logHeadRet.sJH);
            string[] wellLogItems = Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog);
            foreach (string strItem in wellLogItems)
            {
                string logName = Path.GetFileNameWithoutExtension(strItem);
                cbbLog.Items.Add(logName);
            }
            if (cbbLog.Items.Count > 0) cbbLog.SelectedIndex = 0;
        }

        void initialLogHeadByDic()
        {
            string filePathDic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code", "ItemLogHead.txt");
            if (File.Exists(filePathDic) && logHeadRet.sLogName != null)
            {
                using (StreamReader sr = new StreamReader(filePathDic, System.Text.Encoding.UTF8))
                {
                    String line;
                    int _indexLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (logHeadRet.sLogName.ToUpper() == split[0].ToUpper() || logHeadRet.sLogName == split[1])
                        {
                            logHeadRet.sUnit = split[2];
                            logHeadRet.sLogColor = split[3];
                            logHeadRet.fLeftValue = float.Parse(split[4]);
                            logHeadRet.fRightValue = float.Parse(split[5]);
                            logHeadRet.iIsLog = int.Parse(split[6]);
                            logHeadRet.iLineType = int.Parse(split[7]);
                            logHeadRet.iLineType = int.Parse(split[8]);
                            break; //end while
                        }
                    }
                }//end using
            }//end if 
            else 
            {
            
            }
        }

        private void cbbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialLogHeadByDic();
        }

        private void btnNewLog_Click(object sender, EventArgs e)
        {
            logHeadRet.sLogName = tbxNewLogName.Text;
            initialLogHeadByDic();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            logHeadRet.sLogName = cbbLog.SelectedItem.ToString();
            initialLogHeadByDic();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}