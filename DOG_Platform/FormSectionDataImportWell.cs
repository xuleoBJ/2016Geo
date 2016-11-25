using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DOGPlatform.XML;
using System.Xml;

namespace DOGPlatform
{
    public partial class FormDataImportWell : Form
    {
        string sJH = "";
        string  trackTypeStr;
        string filePathOper;
        string sTrackID;
        List<itemDrawDataIntervalValue> listDataItem = new List<itemDrawDataIntervalValue>();

        public FormDataImportWell(string _sJH, string _trackTypeStr, string _filePathOper, string _sTrackID)
        {
            InitializeComponent();
            sJH = _sJH;
            trackTypeStr = _trackTypeStr;
            filePathOper = _filePathOper;
            sTrackID = _sTrackID;
            initializaForm(filePathOper, sTrackID);
        }
        //由于有剖面井的存在导数据的问题
        void initializaForm(string m_filePathOperSource,string m_sTrackID)
        {
            if(sJH!="")
            {
                this.Text = trackTypeStr +"数据导入: "+ sJH;
                listDataItem = cXmlDocSectionWell.getListDataItemIntervalPropertyValue(m_filePathOperSource, m_sTrackID);
                if (trackTypeStr == TypeTrack.分层.ToString())
                {
                    this.dgvDataTable .Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶度");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("layerName", "小层名");
                    for (int i=0;i< listDataItem.Count;i++) 
                    {
                        itemDrawDataIntervalValue item=listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sProperty.ToString();
                    }
                }
                if (trackTypeStr == TypeTrack.测井解释.ToString() || trackTypeStr == TypeTrack.沉积旋回.ToString() ||trackTypeStr == TypeTrack.含油级别.ToString())
                {
                    dgvDataTable.Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶深");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("property", trackTypeStr);
                    for (int i = 0; i < listDataItem.Count; i++)
                    {
                        itemDrawDataIntervalValue item = listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sProperty.ToString();
                    }
                }
                if (trackTypeStr == TypeTrack.描述.ToString())
                {
                    dgvDataTable.Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶深");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("property", "类别");
                    dgvDataTable.Columns.Add("text", trackTypeStr);
                    for (int i = 0; i < listDataItem.Count; i++)
                    {
                        itemDrawDataIntervalValue item = listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sProperty.ToString();
                        dgvDataTable.Rows[i].Cells[3].Value = item.sText.ToString();
                    }
                }
                if (trackTypeStr == TypeTrack.岩性层段.ToString())
                {
                    dgvDataTable.Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶深");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("property", "颜色");
                    dgvDataTable.Columns.Add("text", "岩性");
                    for (int i = 0; i < listDataItem.Count; i++)
                    {
                        itemDrawDataIntervalValue item = listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sProperty.ToString();
                        dgvDataTable.Rows[i].Cells[3].Value = item.sText.ToString();
                    }
                }
                if (trackTypeStr == TypeTrack.文本道.ToString())
                {
                    dgvDataTable.Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶深");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("text", "文本");
                    for (int i = 0; i < listDataItem.Count; i++)
                    {
                        itemDrawDataIntervalValue item = listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sText.ToString();
                    }
                }
                if (trackTypeStr == TypeTrack.符号.ToString())
                {
                    dgvDataTable.Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶深");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("topDepth", "符号");
                    dgvDataTable.Columns.Add("baseDepth", "备注");
                    for (int i = 0; i < listDataItem.Count; i++)
                    {
                        itemDrawDataIntervalValue item = listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sProperty.ToString();
                        dgvDataTable.Rows[i].Cells[3].Value = item.sText.ToString();
                    }
                }
                if (trackTypeStr == TypeTrack.比例条.ToString())
                {
                    dgvDataTable.Columns.Clear();
                    dgvDataTable.Columns.Add("topDepth", "顶深");
                    dgvDataTable.Columns.Add("baseDepth", "底深");
                    dgvDataTable.Columns.Add("value", "值(%)");
                    for (int i = 0; i < listDataItem.Count; i++)
                    {
                        itemDrawDataIntervalValue item = listDataItem[i];
                        dgvDataTable.Rows.Add();
                        dgvDataTable.Rows[i].Cells[0].Value = item.top.ToString();
                        dgvDataTable.Rows[i].Cells[1].Value = item.bot.ToString();
                        dgvDataTable.Rows[i].Cells[2].Value = item.sProperty.ToString();
                    }
                }
               
            }
         
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.read2DataGridViewByTextFile(dgvDataTable);
        }

        private void tsmiDeleteCurrentLine_Click(object sender, EventArgs e)
        {
            //int index = dgvDataTable.CurrentCell.RowIndex;
            //dgvDataTable.Rows.RemoveAt(index);
            Int32 selectedRowCount = dgvDataTable.SelectedRows.Count;
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    if(dgvDataTable.SelectedRows[0].Cells[0].Value!=null)
                    dgvDataTable.Rows.RemoveAt(dgvDataTable.SelectedRows[0].Index);
                }
            }
        }

        public void readDataGridView2ListData(DataGridView dgv)
        {
            listDataItem.Clear();
            ItemWell curWell = cProjectData.ltProjectWell.FirstOrDefault(p => p.sJH == this.sJH);
            for (int i = 0; i < dgv.RowCount; i++)
            {
                bool bDataCorrect = true;
                //根据不同类型赋缺省值
                if (trackTypeStr == TypeTrack.符号.ToString())
                {
                    if (dgv.Rows[i].Cells[2].Value == null) dgv.Rows[i].Cells[2].Value = "半工字";
                    if (dgv.Rows[i].Cells[3].Value == null) dgv.Rows[i].Cells[3].Value = " ";
                }
                for (int j = 0; j < dgv.ColumnCount; j++) 
                {
                    if (dgv.Rows[i].Cells[j].Value == null||dgv.Rows[i].Cells[j].Value.ToString()=="")
                    { 
                        bDataCorrect = false; 
                        break; 
                    }
                }

                if (bDataCorrect == false)
                { 
                    //抛弃空值行
                }
                else if (trackTypeStr == TypeTrack.分层.ToString()
                  || trackTypeStr == TypeTrack.测井解释.ToString()
                  || trackTypeStr == TypeTrack.含油级别.ToString()
                   || trackTypeStr == TypeTrack.沉积旋回.ToString()
                  || trackTypeStr == TypeTrack.比例条.ToString()
                  )
                {
                    itemDrawDataIntervalValue itemPro = new itemDrawDataIntervalValue();
                    itemPro.top = float.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    itemPro.bot = float.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                    itemPro.sProperty = dgv.Rows[i].Cells[2].Value.ToString();
                    itemPro.calTVD(curWell);
                    listDataItem.Add(itemPro);
                }  //end 第一种类型

                else if (trackTypeStr == TypeTrack.岩性层段.ToString()
                     || trackTypeStr == TypeTrack.描述.ToString()
                     || trackTypeStr == TypeTrack.符号.ToString()
                    )
                {
                    itemDrawDataIntervalValue itemPro = new itemDrawDataIntervalValue();
                    itemPro.top = float.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    itemPro.bot = float.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                    itemPro.sProperty = dgv.Rows[i].Cells[2].Value.ToString();
                    itemPro.sText = dgv.Rows[i].Cells[3].Value.ToString();
                    itemPro.calTVD(curWell);
                    listDataItem.Add(itemPro);
                }
                else if (trackTypeStr == TypeTrack.文本道.ToString())
                {
                    itemDrawDataIntervalValue itemPro = new itemDrawDataIntervalValue();
                    itemPro.top = float.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    itemPro.bot = float.Parse(dgv.Rows[i].Cells[1].Value.ToString());
                    itemPro.sProperty = "none";
                    itemPro.sText = dgv.Rows[i].Cells[2].Value.ToString();
                    itemPro.calTVD(curWell);
                    listDataItem.Add(itemPro);
                }
            } 

        }
        private void tsmiDataImport_Click(object sender, EventArgs e)
        {
             readDataGridView2ListData(this.dgvDataTable);
             cXmlDocSectionWell.addDataItemListIntervaProperty(filePathOper, sTrackID, listDataItem);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
      
        private void tsmiCilpCopy_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.DataGridViewCellPaste(dgvDataTable);
        }

        private void tsmiFromDB_Click(object sender, EventArgs e)
        {
            if (sJH != "")
            {
                List<string> listStrLine = new List<string>();
                if (trackTypeStr == TypeTrack.分层.ToString())
                {
                    cIOinputLayerDepth cSelectLayerDepth = new cIOinputLayerDepth();
                    listStrLine = cSelectLayerDepth.selectSectionDrawData2List(sJH);
                }

                if (trackTypeStr == TypeTrack.测井解释.ToString())
                {
                    cIOinputJSJL cSelectJSJL = new cIOinputJSJL();
                    listStrLine = cSelectJSJL.selectSectionDrawData2List(sJH);
                }
            
                cPublicMethodForm.read2DataGridViewByListStrLine(listStrLine, this.dgvDataTable);
            }   
           
        }

        private void tsmiExportExcel_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.exportDGV2Excel(this.dgvDataTable); 
        }

        private void tsmiExport2Txt_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.exportDGV2txt(this.dgvDataTable); 
        }

        private void tsmiCopyData_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.copyDGVselect2Clipboard(this.dgvDataTable);
        }

        private void tsmiSelectAllAndCopy_Click(object sender, EventArgs e)
        {
            dgvDataTable.ClearSelection();
            for (int i = 0; i < dgvDataTable.Rows.Count; i++)
                for (int j = 0; j < dgvDataTable.Columns.Count; j++)
                    dgvDataTable.Rows[i].Cells[j].Selected = true;
            cPublicMethodForm.copyDGVselect2Clipboard(this.dgvDataTable);
        }

        private void tsmiFromSectionWell_Click(object sender, EventArgs e)
        {
            if (sJH != "")
            {
                //根据井号找到单井综合图配置文件路径
                string filePathWellSection = Path.Combine(cProjectManager.dirPathWellDir, sJH, sJH + cProjectManager.fileExtensionSectionWell);
                //加入测井图
                if (File.Exists(filePathWellSection))
                {
                    //读取单井文件，读取图道
                    string sTrackID_match="";
                    foreach (XmlElement el_Track in cXmlDocSectionWell.getTrackNodes(filePathWellSection))
                    {
                        trackDataDraw curTrackDraw = new trackDataDraw(el_Track);
                        if (curTrackDraw.sTrackType == trackTypeStr)
                        {
                            sTrackID_match = curTrackDraw.sTrackID;  //结点name
                            break;
                        }
                    }
                    if (sTrackID_match != "") initializaForm(filePathWellSection, sTrackID_match);
                }
               
            }   
        }

    }
}
