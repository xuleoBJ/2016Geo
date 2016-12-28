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
{
    //输入数据仅仅输入不计算,不同位置打开不同。
    public partial class FormDataImportWells : Form
    {  
        int iCase=0;
        /// <summary>
        /// iCase区分显示的tbg
        /// </summary>
        /// <param name="_icase"></param>
        public FormDataImportWells(int _icase)
        {
            InitializeComponent();
            this.iCase=_icase;
            initializeForm(); 
        }
        DataGridView dgvCurrent;
        string filePathGoal = "";

        void initializeForm() 
        {     
            //暂时移出平面的数据输入部分
            dgvCurrent = this.dgvWellDev;
            this.tbcProjectDataInput.TabPages.Remove(tbgProductWellData);
            this.tbcProjectDataInput.TabPages.Remove(tbgInjectWellData);
            if(this.iCase==1)
            {
                this.tbcProjectDataInput.TabPages.Remove(tbgLayerDepth);
            }
            if (this.iCase == 2)
            {
                foreach (TabPage tbg in tbcProjectDataInput.TabPages)
                {
                    if (tbg.Text != tbgLayerDepth.Text) this.tbcProjectDataInput.TabPages.Remove(tbg);
                } 
                dgvCurrent = this.dgvLayerDepth;
            }
            if (cProjectData.ltStrProjectJH.Count  > 0)
            {
                foreach (string item in cProjectData.ltStrProjectJH) cbbJH.Items.Add(item);
                cbbJH.SelectedIndex = 0;
            }
            filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPath);
            cPublicMethodForm.read2DataGridViewByTextFile(filePathGoal, dgvCurrent);
        }

        void updateCurrentTab() 
        {
            cPublicMethodForm.read2DataGridViewByTextFile(filePathGoal, dgvCurrent);
        }

        private void tbcProjectDataInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcProjectDataInput.SelectedTab.Name)
            {
                case "tbgLayerDepth":
                    filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputLayerDepth);
                    dgvCurrent = dgvLayerDepth;
                    break;
                case "tbgJSJL":
                    filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputJSJL);
                    dgvCurrent = dgvIntepretation;
                    break ;
                case "tbgWellPath":
                    filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPath);
                    dgvCurrent = dgvWellDev;
                    break;
                case "tbgProFile":
                    filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPath);
                    dgvCurrent = dgvProfile;
                    break;
                case "tbgPerforation":
                     filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPerforation);
                     dgvCurrent = dgvPerforation;
                    break;
                case "tbgProductWellData":
                    filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellProduct);
                    dgvCurrent = this.dgvOilProductionData;
                    break;
                case "tbgInjectWellData":
                    filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellInject);
                    dgvCurrent = this.dgvWaterInjectionData; 
                    break;
                default:
                    break;
            }
            updateCurrentTab();
        }


        private void tsmiDeleteCurrentLine_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSelectedCurrentRowDGV(this.dgvCurrent);
        }

         bool dataImported() 
        {
            List<string> lt_dgvStrLine = cPublicMethodForm.readDataGridView2ListLine(dgvCurrent);
            List<string> _ltJH = cPublicMethodForm.getDataGridViewColumn(dgvCurrent, 0).Distinct().ToList();
            List<string> _ltJHnotINproject = new List<string>();

            List<string> _ltJHimportOK = new List<string>();
            foreach (string _sjh in _ltJH)
            {
                if (cProjectData.ltStrProjectJH.IndexOf(_sjh) >= 0)
                {
                    List<string> _listLines = cIOBase.getListStrFromStringListByFirstWord(lt_dgvStrLine, _sjh);
                    if (dgvCurrent == this.dgvLayerDepth)
                    {
                        cIOinputLayerDepth.creatInputFile(_sjh, _listLines);
                        cProjectData.setProjectWellsInfor();
                    }
                     if (dgvCurrent == this.dgvIntepretation) cIOinputJSJL.creatInputFile(_sjh, _listLines);
                     if (dgvCurrent == this.dgvWellDev)
                     {
                         cIOinputWellPath.creatInputFile(_sjh, _listLines);
                         cIOinputWellPath.creatWellGeoFile(_sjh);
                     }
                     if (dgvCurrent == this.dgvProfile) cIOinputInjectProfile.creatInputFile(_sjh, _listLines);
                     if (dgvCurrent == this.dgvPerforation) cIOinputWellPerforation.creatInputFile(_sjh, _listLines);
                     if (dgvCurrent == this.dgvOilProductionData) cIOinputWellProduct.creatInputFile(_sjh, _listLines);
                     if (dgvCurrent == this.dgvWaterInjectionData) cIOInputWellInject.creatInputFile(_sjh, _listLines);
                     _ltJHimportOK.Add(_sjh);
                }
                else _ltJHnotINproject.Add(_sjh); 
            }
            if (_ltJHimportOK.Count > 0) MessageBox.Show(string.Join("\t", _ltJHimportOK) + "导入成功。");
               
            if (_ltJHnotINproject.Count > 0)
            {
                MessageBox.Show(string.Join("\t", _ltJHnotINproject) + "缺失井信息，请加入井信息后重新加载。"); 
                return false;
            }
            return true;
        }

        private void tsmiDataImport_Click(object sender, EventArgs e)
        {
            bool isFull=true;
            for (int j = 0; j < dgvCurrent.RowCount - 1; j++)
            {
               for (int i=0;i<dgvCurrent.ColumnCount;i++)
                {
                    if (dgvCurrent.Rows[j].Cells[i].Value == null)
                    {
                        MessageBox.Show("表格:行"+(j+1).ToString()+"列" + (i+1).ToString() + " 数据缺失");
                        isFull = false;
                        break;
                    }  
                }
               if (isFull == false) break;
            }
            if (isFull)
            {
                DialogResult dialogResult = MessageBox.Show("确认数据入库？", "数据导入", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    dataImported();
                    Cursor.Current = Cursors.Default;
                } 
            }
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.read2DataGridViewByTextFile(this.dgvCurrent);
        }

        private void cbbJH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvCurrent == dgvLayerDepth && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputLayerDepth);
            if (dgvCurrent == dgvIntepretation && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputJSJL);
            if (dgvCurrent == dgvWellDev && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPath);
            if (dgvCurrent == this.dgvProfile && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellProfile);
            if (dgvCurrent ==dgvPerforation && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellPerforation);
            if (dgvCurrent == dgvOilProductionData && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellProduct);
            if (dgvCurrent == dgvWaterInjectionData  && cbbJH.SelectedIndex >= 0)
                filePathGoal = Path.Combine(cProjectManager.dirPathWellDir, this.cbbJH.SelectedItem.ToString(), cProjectManager.fileNameInputWellInject);
            updateCurrentTab();
               
        }

        private void tsmiCopyFromExcel_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(this.dgvCurrent);
        }

        private void tsmiAllLineCopy_Click(object sender, EventArgs e)
        {
            dgvCurrent.ClearSelection();
            for (int i = 0; i < dgvCurrent.Rows.Count; i++)
                for (int j = 0; j < dgvCurrent.Columns.Count; j++)
                    dgvCurrent.Rows[i].Cells[j].Selected = true;
            cPublicMethodForm.copyDGVselect2Clipboard(this.dgvCurrent);
        }

        private void ftmToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }
    }
}
