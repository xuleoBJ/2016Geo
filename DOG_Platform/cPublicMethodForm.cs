using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace DOGPlatform
{
    class cPublicMethodForm :cPublicMethodBase
    {
        public static bool checkRenameSameFile(string filePath)
        {
            bool bDelete = true;
            if (File.Exists(filePath))
            {
                DialogResult dialogResult = MessageBox.Show(" 是否覆盖？", "同名文件已存在", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) bDelete = false;
            }
            return bDelete;
        }
        public static void copyDGVselect2Clipboard(DataGridView dgvDataTable) 
        {
            if (dgvDataTable.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                // Add the selection to the clipboard.
                Clipboard.SetDataObject(
                    dgvDataTable.GetClipboardContent());
            }
        }

        public static void exportDGV2txt(DataGridView dgvDataTable) 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export txt File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
                return;

            StreamWriter tw = new StreamWriter(saveFileDialog.FileName);

            for (int x = 0; x < dgvDataTable.Columns.Count; x++)
            {
                tw.Write(dgvDataTable.Columns[x].HeaderText);
                if (x != dgvDataTable.Columns.Count - 1)
                {
                    tw.Write(", ");
                }
            }

            tw.WriteLine();

            //writing the data
            for (int x = 0; x < dgvDataTable.Rows.Count - 1; x++)
            {
                for (int y = 0; y < dgvDataTable.Columns.Count; y++)
                {
                    tw.Write(dgvDataTable.Rows[x].Cells[y].Value.ToString());
                    if (y != dgvDataTable.Columns.Count - 1)
                    {
                        tw.Write(", ");
                    }
                }
                tw.WriteLine();
            }
            tw.Close();
            MessageBox.Show("导出完成。");
        
        }
        public static void exportDGV2Excel(DataGridView dgvDataTable) 
        {
            #region
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "_execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
                return;
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            string str = "";
            try
            {
                for (int i = 0; i < dgvDataTable.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvDataTable.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                for (int j = 0; j < dgvDataTable.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dgvDataTable.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += dgvDataTable.Rows[j].Cells[k].Value.ToString();
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show("导出完成。");
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
            #endregion
        }

        public static void initialMapScale(ToolStripComboBox cbbMap)
        {
            cbbMap.Items.Clear();
            if (cProjectData.projectUnit == typeUnit.Metric.ToString())
                foreach (string sItem in cProjectManager.ltStrMapMetricScale) cbbMap.Items.Add(sItem);
            if (cProjectData.projectUnit == typeUnit.Field.ToString())
                foreach (string sItem in cProjectManager.ltStrMapFieldScale) cbbMap.Items.Add(sItem);
        }

        public static void initialMapScale(ComboBox cbbMap)
        {
            cbbMap.Items.Clear();
            if(cProjectData.projectUnit==typeUnit.Metric.ToString())
                foreach (string sItem in cProjectManager.ltStrMapMetricScale) cbbMap.Items.Add(sItem);
            if (cProjectData.projectUnit == typeUnit.Field.ToString())
                foreach (string sItem in cProjectManager.ltStrMapFieldScale) cbbMap.Items.Add(sItem); 
        }
        public static List<string> readDataGridView2ListWord(DataGridView dgv)
        {
            List<string> ltStrReturn = new List<string>();
            for (int j = 0; j < dgv.RowCount - 1; j++)
            {
                bool isDataOK = true;
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (dgv.Rows[j].Cells[i].Value == null)
                    {
                        isDataOK = false;
                        break;
                    }
                }
                if (isDataOK == true)
                {
                    for (int i = 0; i < dgv.ColumnCount; i++) ltStrReturn.Add(dgv.Rows[j].Cells[i].Value.ToString());
                }
            }

            return ltStrReturn;
        }

        public static void loadText2DataGridViewByFirstLineHead(string filepathTableData, DataGridView dgvDataTable)
        {
            if (File.Exists(filepathTableData))
            {
                dgvDataTable.Columns.Clear();
                int lineindex = 0;
                string[] split;
                List<string> ltStrHeadColoum = new List<string>();
                using (StreamReader sr = new StreamReader(filepathTableData, Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null && lineindex < 1) //delete the line whose legth is 0
                    {
                        lineindex++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < split.Length; i++) ltStrHeadColoum.Add(split[i]);
                    }
                }
                for (int i = 0; i < ltStrHeadColoum.Count; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = ltStrHeadColoum[i];
                    dgvDataTable.Columns.Add(col);
                }
                cPublicMethodForm.read2DataGridViewByTextFile(filepathTableData, dgvDataTable);
                dgvDataTable.Rows.RemoveAt(0);
            }
        }
        public static void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        public static  List<string> getLtStrOfdgvColoum(DataGridView dgv, int indexCol)
        {
            List<string> listStr = new List<string>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if(dgv.Rows[i].Cells[indexCol].Value!=null)
                listStr.Add(dgv.Rows[i].Cells[indexCol].Value.ToString());
            }
            return listStr;
        }

        public static bool NodeExists(TreeNode node, string key)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                if (subNode.Text == key) return true;
            }
            return false;
        }

        public static TreeNode FindNode(TreeNode tnParent, string strValue)
        {

            if (tnParent == null) return null;

            if (tnParent.Text == strValue) return tnParent;

            TreeNode tnRet = null;

            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, strValue);
                if (tnRet != null) break;
            }
            return tnRet;
        }

        public static void loadDgvByGeoText(DataGridView dgv, string geoFilePath)
        {

            List<string> ltStrHeadColumn = cIOGeoEarthText.getFileHeadColumnFromGeoText(geoFilePath);
            List<string> ltStrLineData = cIOGeoEarthText.getDataLineListStringFromGeoText(geoFilePath);
            dgv.Columns.Clear();
            for (int i = 0; i < ltStrHeadColumn.Count; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = ltStrHeadColumn[i];
                dgv.Columns.Add(col);
            }
            dgv.Rows.Clear(); //清空井头信息表格全部内容，以便重新加载
            foreach (string _sLinedata in ltStrLineData)
            {
                string[] _splitData = _sLinedata.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                dgv.Rows.Add(_splitData);
            }
        }
        public static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name,0,1);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            foreach (var file in directoryInfo.GetFiles())
            {
   
                directoryNode.Nodes.Add(new TreeNode(file.Name,2,2));
            }
            return directoryNode;
        }

        public static void transferItemFromleftListBox2rightListBox(ListBox lbxLeft,ListBox lbxRight) 
        {
            string sWellItem = "";
            if (lbxLeft.SelectedIndex >= 0)
            {
                sWellItem = lbxLeft.SelectedItem.ToString();
                if (lbxRight.Items.IndexOf(sWellItem) < 0)
                    lbxRight.Items.Add(sWellItem);
                lbxRight.SetSelected(lbxRight.Items.Count - 1, true);
            }
            else
            {
                MessageBox.Show("请从左侧点选井号添加");
            }
        }
        //允许重复的Item
        public static void transferItemFromleftListBox2rightListBoxWithRepeation(ListBox lbxLeft, ListBox lbxRight)
        {
            string sWellItem = "";
            if (lbxLeft.SelectedIndex >= 0)
            {
                sWellItem = lbxLeft.SelectedItem.ToString();
                lbxRight.Items.Add(sWellItem);
                lbxRight.SetSelected(lbxRight.Items.Count - 1, true);
            }
            else
            {
                MessageBox.Show("请从左侧点选井号添加");
            }
        }

        //若不是第一行则上移
        public static void upItemInListBox(ListBox lbx)
        {
            if (lbx.SelectedIndex > 0)
            {
                int index = lbx.SelectedIndex;
                string temp = lbx.Items[index - 1].ToString();
                lbx.Items[index - 1] = lbx.SelectedItem.ToString(); ;
                lbx.Items[index] = temp;
                lbx.SelectedIndex = index - 1;
            }
        }
        public static void downItemInListBox(ListBox lbx)
        {
            if (lbx.SelectedIndex < lbx.Items.Count - 1)
            {
                //若不是第最后一行则下移
                int index = lbx.SelectedIndex;
                string temp = lbx.Items[index + 1].ToString();
                lbx.Items[index + 1] = lbx.SelectedItem.ToString(); ;
                lbx.Items[index] = temp;
                lbx.SelectedIndex = index + 1;
            }
        }
        public static void deleteSlectedItemFromListBox(ListBox lbx)
        {
            if (lbx.SelectedItem != null)
            {
                string sWellItem = lbx.SelectedItem.ToString();
                lbx.Items.Remove(sWellItem);
            }
            if (lbx.Items.Count > 0)
                lbx.SetSelected(lbx.Items.Count - 1, true);
        }
        
        public static void inputTextBoxIntOnly(TextBox tbxInput) 
        {
            Regex r = new Regex("^-?\\d+$");
            if (!r.IsMatch(tbxInput.Text))
            {
              //MessageBox.Show("请输入整数米数。");
              tbxInput.Text = "100";
            }
        }
        public static void inputTextBoxPositiveRealOnly(TextBox tbxInput)
        {
            Regex r = new Regex(@"^\d+(\.\d+)?$");
            if (!r.IsMatch(tbxInput.Text))
            {
                //MessageBox.Show("请输入正实数。");
                tbxInput.Text = "0.0";
            }
        }
        //从文本读入数据到DatagridView
        public static void read2DataGridViewByTextFile(DataGridView dgv4txt)
        {
            
            string strSelectedFileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK && dgv4txt!=null)
            {

                Cursor.Current = Cursors.WaitCursor;
                strSelectedFileName = openFileDialog.FileName;
                //importWellHead(strSelectedFileName, dgvInterpret);

                dgv4txt.Rows.Clear(); //清空井头信息表格全部内容，以便重新加载
                int lineindex = 0;
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                string[] split;
                try
                {
                    using (StreamReader sr = new StreamReader(strSelectedFileName, Encoding.Default))
                    {

                        String line;
                        while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                        {
                            lineindex++;
                            split = line.Trim().Split(new char[] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                            dgv4txt.Rows.Add(split);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
           

                AutoNumberRowsForGridView(dgv4txt);
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("请选对应文件，格式对应表头", "提示");
            }
            
        }


        public static void read2DataGridViewByListStrLine(List<string>ltStrLine, DataGridView dgv4txt)
        {
            if (dgv4txt.Rows.Count > 0) dgv4txt.Rows.Clear(); //清空井头信息表格全部内容，以便重新加载

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            string[] split;
            foreach (string _line in ltStrLine) 
            {
                split = _line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                dgv4txt.Rows.Add(split);
            }
           
            AutoNumberRowsForGridView(dgv4txt);

        }
        public static void read2DataGridViewByTextFile(string filePath,DataGridView dgv4txt)
        {
            if (filePath != ""&&dgv4txt!=null)
            {
                if (dgv4txt.Rows.Count > 0) dgv4txt.Rows.Clear(); //清空井头信息表格全部内容，以便重新加载
                int lineindex = 0;

                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                string[] split;
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                        {
                            lineindex++;
                            split = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            if(split.Length>0) dgv4txt.Rows.Add(split);
                        }
                    }
                }
                AutoNumberRowsForGridView(dgv4txt);
            }
 
        }

        //从datagrid数据写入文本
        public static string readDataGridView2string(DataGridView dgv)
        {
            string sReturn="";
            bool IsDataOK = true; //数据未校验
            //数据校验过程
            cProjectData.sErrLineInfor= "";
            for (int j = 0; j < dgv.RowCount - 1; j++)
                for (int i = 0; i < dgv.ColumnCount; i++)
                {   //判读数据是否缺失
                    if (dgv.Rows[j].Cells[i].Value == null)
                    {
                        String line = "";
                        line = "文件第" + (j + 1).ToString() + "行" + "第" + (i + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                        cProjectData.sErrLineInfor+= line;
                        IsDataOK = false;
                    }
                }

            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {
              
                for (int j = 0; j < dgv.RowCount - 1; j++)
                {
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        sReturn += dgv.Rows[j].Cells[i].Value.ToString() + "\t";
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("数据有错误，请查看相关信息！", "提示信息");
                outputErrInfor2Text(cProjectData.sErrLineInfor);
            }
            return sReturn;
        }

        public static List<string> readDataGridView2ListLine(DataGridView dgv)
        {
            List<string> ltStrReturn = new List<string>();
            bool IsDataOK = true; //数据未校验
            //数据校验过程
            cProjectData.sErrLineInfor= "";
            for (int j = 0; j < dgv.RowCount - 1; j++)
                for (int i = 0; i < dgv.ColumnCount; i++)
                {   //判读数据是否缺失
                    if (dgv.Rows[j].Cells[i].Value == null)
                    {
                        String line = "";
                        line = "文件第" + (j + 1).ToString() + "行" + "第" + (i + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                        cProjectData.sErrLineInfor+= line;
                        IsDataOK = false;
                    }
                }

            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {
                for (int j = 0; j < dgv.RowCount - 1; j++)
                {
                    string sLine = "";
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        sLine += dgv.Rows[j].Cells[i].Value.ToString() + "\t";
                    }
                    ltStrReturn.Add(sLine);
                }
            }
            else
            {
                MessageBox.Show("数据有错误，请查看相关信息！", "提示信息");
                outputErrInfor2Text(cProjectData.sErrLineInfor);
            }
            return ltStrReturn;
        }

        public static void updateInputStartWithJH(string inputFileName,DataGridView dgvInput) 
        {
             List<string> ltStrInputText=cIOBase.readText2StringList(inputFileName,0);
             List<string> ltStrInputDGV = readDataGridView2ListLine(dgvInput);
             List<string> ltStrJHinDGV = getDataGridViewColumn(dgvInput, 0);
             ltStrJHinDGV.Distinct();

             StreamWriter swWrited = new StreamWriter(inputFileName, false, Encoding.UTF8);
             for (int i = 0; i < ltStrInputDGV.Count; i++)
             {
                 swWrited.WriteLine(ltStrInputDGV[i]);
             }
             for (int i = 0; i < ltStrInputText.Count; i++) 
             {
                 string[] split = ltStrInputText[i].Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                 string sJH=split[0];
                 if (ltStrJHinDGV.Contains(sJH) != true) 
                 {
                     swWrited.WriteLine(ltStrInputText[i]);
                 }
             }
           
             swWrited.Close();
           //  MessageBox.Show("文件入库完毕");
        }
        
        //
        public static List<string> getDataGridViewColumn(DataGridView dgv, int iIndexColumn)
        {

            List<string> ltStrReturn = new List<string>();
            bool IsDataOK = true; //数据未校验
            //数据校验过程
            cProjectData.sErrLineInfor= "";
            for (int j = 0; j < dgv.RowCount - 1; j++)
            {   //判读数据是否缺失
                if (dgv.Rows[j].Cells[iIndexColumn].Value == null)
                {
                    String line = "";
                    line = "文件第" + (j + 1).ToString() + "行" + "第" + (iIndexColumn + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                    cProjectData.sErrLineInfor+= line;
                    IsDataOK = false;
                }
            }

            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {
               
                for (int j = 0; j < dgv.RowCount - 1; j++)
                {
                    ltStrReturn.Add(dgv.Rows[j].Cells[iIndexColumn].Value.ToString());
                }
            }
            else
            {
                MessageBox.Show("数据有错误，请查看相关信息！", "提示信息");
                outputErrInfor2Text(cProjectData.sErrLineInfor);

            }
            return ltStrReturn;
        }

        //从datagrid数据写入文本
        public static void readDataGridView2TXTFile(DataGridView dgv, string filePathGeoTextWrited)
        {
            bool IsDataOK = true; //数据未校验
            //数据校验过程
            cProjectData.sErrLineInfor= "";
            for (int j = 0; j < dgv.RowCount - 1; j++)
                for (int i = 0; i < dgv.ColumnCount; i++)
                {   //判读数据是否缺失
                    if (dgv.Rows[j].Cells[i].Value == null)
                    {
                        String line = "";
                        line = "文件第" + (j + 1).ToString() + "行" + "第" + (i + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                        cProjectData.sErrLineInfor+= line;
                   
                        IsDataOK = false;
                    }
                }
 
            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {
                StreamWriter swWrited = new StreamWriter(filePathGeoTextWrited, false, Encoding.UTF8);

                for (int j = 0; j < dgv.RowCount - 1; j++)
                {
                    List<string> listData = new List<string>();
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        listData.Add(dgv.Rows[j].Cells[i].Value.ToString());
                    }
                    swWrited.Write(string.Join("\t", listData.ToArray())+"\r\n");
                }

                swWrited.Close();
   
            }
            else
            {
                MessageBox.Show("数据有错误，请查看相关信息！", "提示信息");
                outputErrInfor2Text(cProjectData.sErrLineInfor);
                
            }
        }

        public static void readDataGridView2TXTFileWithColoumHead(DataGridView dgv, string filePathTextWrited)
        {

            StreamWriter swWrited = new StreamWriter(filePathTextWrited, false, Encoding.UTF8);
            List<string> ltStrColumnHead = new List<string>();
            for (int j = 0; j <= dgv.ColumnCount - 1; j++)
            {
                ltStrColumnHead.Add(dgv.Columns[j].HeaderText);
            }
            swWrited.WriteLine(string.Join("\t", ltStrColumnHead.ToArray()));
            for (int j = 0; j < dgv.RowCount - 1; j++)
            {
                List<string> listData = new List<string>();
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (dgv.Rows[j].Cells[i].Value != null)
                        listData.Add(dgv.Rows[j].Cells[i].Value.ToString());
                    else listData.Add(" ");
                }
                swWrited.WriteLine(string.Join("\t", listData.ToArray()) );
            }

            swWrited.Close();
        }
        public static void readDataGridView2geoTXTFileWithColoumHead(DataGridView dgv, string filePathGeoTextWrited,string firstLine)
        {

            List<string> ltStrColumnHead = new List<string>();
            for (int j = 0; j <= dgv.ColumnCount - 1; j++)
            {
                ltStrColumnHead.Add(dgv.Columns[j].HeaderText);
            }

            List<string> ltStrLine = new List<string>();
            for (int j = 0; j < dgv.RowCount - 1; j++)
            {
                string _line = "";
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (dgv.Rows[j].Cells[i].Value != null)
                        _line+="\t"+ dgv.Rows[j].Cells[i].Value.ToString();
                    else _line+="\tNan";
                }
                ltStrLine.Add(_line);
            }

            cIOGeoEarthText.generateFileGeoText(filePathGeoTextWrited,firstLine, ltStrColumnHead, ltStrLine);
        }
        public static void readDataGridView2TXTFile(DataGridView dgv, string filePathWrited, int iLine)
        {
            iLine = 0;
            bool IsDataOK = true; //数据未校验
            //数据校验过程
            StreamWriter swErrInfor = new StreamWriter(cProjectManager.filePathRunInfor, false, Encoding.UTF8);
            for (int j = 0; j < dgv.RowCount - 1; j++)
                for (int i = 0; i < dgv.ColumnCount; i++)
                {   //判读数据是否缺失
                    if (dgv.Rows[j].Cells[i].Value == null)
                    {
                        String line = "";
                        line = "文件第" + (j + 1).ToString() + "行" + "第" + (i + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                        swErrInfor.Write(line);
                        IsDataOK = false;
                    }
                }
            swErrInfor.Close();
            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {
                StreamWriter swWrited = new StreamWriter(filePathWrited, false, Encoding.UTF8);

                for (int j = 0; j < dgv.RowCount - 1; j++)
                {
                    iLine = iLine + 1;
                    List<string> listData = new List<string>();
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        listData.Add(dgv.Rows[j].Cells[i].Value.ToString());
                    }
                    swWrited.WriteLine(iLine.ToString() + '\t' + string.Join("\t", listData.ToArray()) );
                }

                swWrited.Close();
                MessageBox.Show("文件整理完毕");
            }
            else
            {
                MessageBox.Show("数据可能有错误，请查看相关信息！", "提示信息");
                swErrInfor.Close();
                System.Diagnostics.Process.Start("notepad.exe", cProjectManager.filePathRunInfor);
            }
        }

        //从某一行开始读datagrid数据
        public static void readDataGridView2TXTFile(DataGridView dgv, int fisrtDataLine, string filePathWrited)
        {
            bool IsDataOK = true; //数据未校验
            //MessageBox.Show(fisrtDataLine.ToString());
            //数据校验过程
            StreamWriter swErrInfor = new StreamWriter(cProjectManager.filePathRunInfor, false, Encoding.UTF8);
            for (int j = fisrtDataLine; j < dgv.RowCount - 1; j++)
                for (int i = 0; i < dgv.ColumnCount; i++)
                {   //判读数据是否缺失
                    if (dgv.Rows[j].Cells[i].Value == null)
                    {
                        String line = "";
                        line = "文件第" + (j + 1).ToString() + "行" + "第" + (i + 1).ToString() + "列数据可能缺失或者有错误，请查看。" + "\r\n";
                        swErrInfor.Write(line);
                        IsDataOK = false;
                    }
                }
            swErrInfor.Close();

            if( fisrtDataLine<0) fisrtDataLine=0;  //默认开始的行数 需要再仔细处理验证下
            if (IsDataOK == true) //数据通过所有的校验过程，整理成所需要的格式
            {
                StreamWriter swWrited = new StreamWriter(filePathWrited, false, Encoding.UTF8);

                for (int j = fisrtDataLine; j < dgv.RowCount - 1; j++)
                {
                    List<string> listData = new List<string>();
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        listData.Add(dgv.Rows[j].Cells[i].Value.ToString().Trim());
                    }
                    swWrited.WriteLine(string.Join("\t", listData.ToArray()) );
                }

                swWrited.Close();
                MessageBox.Show("数据导入完成。", "提示");
            }
            else
            {
                MessageBox.Show("数据可能有错误，请查看相关信息！", "提示信息");
                swErrInfor.Close();
                System.Diagnostics.Process.Start("notepad.exe", cProjectManager.filePathRunInfor);
            }
        }

        //自动产生行号
        public static void AutoNumberRowsForGridView(DataGridView dgv)
        {
            dgv.RowHeadersWidth = 60;
            if (dgv != null)
            {
                for (int count = 0; (count <= (dgv.Rows.Count - 2)); count++)
                {
                    dgv.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                }
            }

        }

        public static  void DataGridViewCellPaste(DataGridView dgv)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                 dgv.Rows.Clear(); //清空井头信息表格全部内容，以便重新加载
                //这里是取剪贴板里的内容，如果内容为空，则退出
                string pastTest = Clipboard.GetText();
                // 获取剪切板的内容，并按行分割
                if (string.IsNullOrEmpty(pastTest)) return;
                //excel中是以 空格 和换行来 当做字段和行，所以用\n \r来分隔
                string[] lines = pastTest.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] strs = line.Trim().Split(new char[] { '\t' });
                    dgv.Rows.Add(strs);
                }
                AutoNumberRowsForGridView(dgv);
                Cursor.Current = Cursors.Default;
            }
            catch
            {
                MessageBox.Show("请从ExcelCopy数据。");
            }
        }

        public static  void deleteSelectedCurrentRowDGV(DataGridView dgv)
        {

            if (dgv.RowCount > 1)
            {
                int idRow = dgv.SelectedCells[0].RowIndex;
                if (idRow != dgv.RowCount - 1) dgv.Rows.RemoveAt(idRow);
            }
        }
      /// <summary>
        /// 删除多个选中行，选中模式调成 FullRowSelect
      /// </summary>
      /// <param name="dgvDataTable"></param>
       public static void deleteSelectedManyRowInDataGridView(DataGridView dgvDataTable)
       {
           Int32 selectedRowCount = dgvDataTable.SelectedRows.Count;
           if (selectedRowCount > 0)
           {
               for (int i = 0; i < selectedRowCount; i++)
               {
                   if (dgvDataTable.SelectedRows[0].Cells[0].Value != null)
                       dgvDataTable.Rows.RemoveAt(dgvDataTable.SelectedRows[0].Index);
               }
           } 
       }
        
        //全选ListBox
        public static void setListBoxChooseAll(ListBox lbx) 
        {
            for (int i = 0; i < lbx.Items.Count; i++)
            {
                lbx.SetSelected(i, true);
            }
        }

        //全不选ListBox
        public static void setListBoxChooseNo(ListBox lbx)
        {
            for (int i = 0; i < lbx.Items.Count; i++)
            {
                lbx.SetSelected(i, false);
            }
        }

        //初始化ListBox
          public static void inialListBox(ListBox lbx,List<string> ltStrItem)
        {
            lbx.Items.Clear();
            foreach (string sItem in ltStrItem)
            {
                lbx.Items.Add(sItem);
            }
        }
        //初始化combobox
          public static void inialComboBox(ComboBox cbb, List<string> ltStrItem)
          {
              cbb.Items.Clear();
              foreach (string sItem in ltStrItem)
              {
                  cbb.Items.Add(sItem);
              }
              if (cbb.Items.Count>0)
              cbb.SelectedIndex = 0;
          }

          public static void inialComboBox(ToolStripComboBox  tsCbb, List<string> ltStrItem)
          {
              tsCbb.Items.Clear();
              foreach (string sItem in ltStrItem)
              {
                  tsCbb.Items.Add(sItem);
              }
              if (tsCbb.Items.Count > 0)
                  tsCbb.SelectedIndex = 0;
          }

          //获取ComboBox中的全部的items
          public static List<string> get_ltStrFromComboBox(ComboBox cbb)
          {
              List<string> ltStrReturn = new List<string>();
              foreach (string sItem in cbb.Items)
              {
                  ltStrReturn.Add(sItem);
              }
              return ltStrReturn;
          }

        public static void loadDataGridViewWithGeoText(DataGridView dgv,string filePath)
          {
              Cursor.Current = Cursors.WaitCursor;

              if (File.Exists(filePath))
              {
                  dgv.Columns.Clear();
                  dgv.Rows.Clear(); //清空井头信息表格全部内容，以便重新加载

                  using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                  {
                      String line;
                      int _indexLine = 0;
                      int _dataStartLine = 3;
                      while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                      {
                          _indexLine++;
                          string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                          if (_indexLine == 1) continue; //first comment line
                          else if (_indexLine == 2) _dataStartLine = int.Parse(split[0]);  //second line is number of column,
                          else if (_indexLine <= (2 + _dataStartLine))
                          {
                              DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                              col.HeaderText = split[0];
                              dgv.Columns.Add(col);
                          }
                          else dgv.Rows.Add(split);
                      }
                  }
              }
              AutoNumberRowsForGridView(dgv);
              Cursor.Current = Cursors.Default;
        }


        //获取ListBox中的被选items
          public static List<string> ltStrSelectedItemsReturnFromListBox(ListBox lbx)
          {
              List<string> ltStrReturn = new List<string>();
              foreach (object selecteditem in lbx.SelectedItems)
              {
                  string strItem = selecteditem as String;
                  ltStrReturn.Add(strItem);
              }
              return ltStrReturn;
          }

        //上移treeview节点
          public static void upTreeViewNote(TreeView TVdepartment)
        {
            TreeNode Node = TVdepartment.SelectedNode;
            TreeNode PrevNode = Node.PrevNode;
            if (PrevNode != null)
            {

                TreeNode NewNode = (TreeNode)Node.Clone();
                if (Node.Parent == null)
                {
                    TVdepartment.Nodes.Insert(PrevNode.Index, NewNode);
                }
                else
                {
                    Node.Parent.Nodes.Insert(PrevNode.Index, NewNode);
                }
                Node.Remove();
                TVdepartment.SelectedNode = NewNode;
            }
        }

          //下移treeview节点
          public static void downTreeViewNote(TreeView TVdepartment)
          {
              TreeNode Node = TVdepartment.SelectedNode;
              TreeNode NextNode = Node.NextNode;
              if (NextNode != null)
              {
                  TreeNode NewNode = (TreeNode)Node.Clone();
                  if (Node.Parent == null)
                  {
                      TVdepartment.Nodes.Insert(NextNode.Index + 1, NewNode);
                  }
                  else
                  {
                      Node.Parent.Nodes.Insert(NextNode.Index + 1, NewNode);
                  }
                  Node.Remove();
                  TVdepartment.SelectedNode = NewNode;
              }
          }

          public static void setDataGridViewNotSorted(DataGridView dgv) 
          {
              for (int i = 0; i < dgv.Columns.Count; i++)
              {
                  dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
              }
          }
        
          //获取ListBox中的被选item的文本
          public static string getSelectedItemTextFromListBox(ListBox lbx)
          {
              string selectedItemText = "";

              if (lbx.SelectedIndex >= 0)
              {
                  selectedItemText = lbx.SelectedItem.ToString();
              }

              return selectedItemText;
          }
        //根据ltStr选择ListBox
          public static void setListBoxwithltStr(ListBox lbx, List<string> ltStr)
        {
            for (int i = 0; i < lbx.Items.Count; i++)
            {
                lbx.SetSelected(i, false);
                if (ltStr.Contains( lbx.Items[i].ToString()))
                    lbx.SetSelected(i, true);
            }
        }
          public static void setComboBoxBackColorByColorDialog(ComboBox cbb) 
          {
              ColorDialog colorDialog1 = new ColorDialog();
              if (colorDialog1.ShowDialog() == DialogResult.OK)
              {
                  cbb.BackColor = colorDialog1.Color;
              }  
          }
          public static List<string> getSelectedXCMList(ComboBox cbbSelectedTopXCM, ComboBox cbbSelectedBottomXCM)
          {
              List<string> ltStrSelectedLayer = new List<string>();
              string sSelectedTopLayer = cbbSelectedTopXCM.SelectedItem.ToString();
              string sSelectedBottomLayer = cbbSelectedBottomXCM.SelectedItem.ToString();
              int iIndexTopLayer = cProjectData.ltStrProjectXCM.IndexOf(sSelectedTopLayer);
              int iIndexBottomLayer = cProjectData.ltStrProjectXCM.IndexOf(sSelectedBottomLayer);
              for (int i = iIndexTopLayer; i <= iIndexBottomLayer; i++) ltStrSelectedLayer.Add(cProjectData.ltStrProjectXCM[i]);
              return ltStrSelectedLayer;
          }

          public static void textboxViewText(TextBox tbx, string filePath, int numLine) 
          {
              int lineindex = 0;
              string _s = "";
              using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
              {
                  String line;

                  while ((line = sr.ReadLine()) != null && lineindex < numLine) //delete the line whose legth is 0
                  {
                      lineindex++;
                      _s = _s + lineindex.ToString() + "\t" + line + "\r\n";
                  }
              }
              tbx.Text = _s; 
          }

          public static void viewTextRichText(RichTextBox tbx, string filePath, int numLine)
          {
              int lineindex = 0;
              string _s = "";
              using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
              {
                  String line;

                  while ((line = sr.ReadLine()) != null && lineindex < numLine) //delete the line whose legth is 0
                  {
                      lineindex++;
                      _s = _s + lineindex.ToString() + "\t" + line + "\r\n";
                  }
              }
              tbx.Text = _s;
          }

          public static bool chekDataGridViewHasNullValue(DataGridView dgv)
          {
              bool bCheck = true;

              for (int rows = 0; rows < dgv.Rows.Count-1; rows++)
              {
                  for (int col = 0; col < dgv.Rows[rows].Cells.Count; col++)
                  {
                      if (dgv.Rows[rows].Cells[col].Value == null)
                      {
                          MessageBox.Show("第" + rows.ToString() + "行数据有空值 。");
                          bCheck = false;
                          break;
                      }
                  }
                  if (bCheck == false) return false;
              }

              return bCheck;
          }

          public static void CheckAllNodes(TreeNodeCollection nodes)
          {
              foreach (TreeNode node in nodes)
              {
                  node.Checked = true;
                  CheckChildren(node, true);
              }
          }

          public static void UncheckAllNodes(TreeNodeCollection nodes)
          {
              foreach (TreeNode node in nodes)
              {
                  node.Checked = false;
                  CheckChildren(node, false);
              }
          }

          private static void CheckChildren(TreeNode rootNode, bool isChecked)
          {
              foreach (TreeNode node in rootNode.Nodes)
              {
                  CheckChildren(node, isChecked);
                  node.Checked = isChecked;
              }
          }
    }
}
