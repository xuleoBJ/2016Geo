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
    public partial class FormFileManagerGeo : Form
    {

        string subDir = cProjectManager.dirPathTemp;
        string sJHCurrent = "";
        string dirCurrent = "";
        public FormFileManagerGeo()
        {
            InitializeComponent();
            this.AllowDrop = true;
            setupTNwell2TV(this.tvFileManage);
        }

        public static void setupTNwell2TV(TreeView _tv)
        {
            _tv.Nodes.Clear();
            TreeNode tnWells = new TreeNode();
            tnWells.Name = TypeGeoFile.projectDir.ToString();
            tnWells.Text = "工区";
            tnWells.Tag = TypeGeoFile.projectDir;
            foreach (string sJH in cProjectData.ltStrProjectJH)
            {
                TreeNode tnJH = new TreeNode(sJH,0,1);
                tnJH.Name = sJH;
                tnJH.Tag = TypeGeoFile.well;
                setupWellChildNode(tnJH);
                tnWells.Nodes.Add(tnJH);
            }
            _tv.Nodes.Add(tnWells);
        }


        //装载井菜单下的测井treenote
        public static void setupWellChildNode(TreeNode tnWell)
        {
            //删除原来的welllogNode
            foreach (TreeNode subNode in tnWell.Nodes)
            {
                subNode.Remove();
            }
            string sJH = tnWell.Text;
            //测井
            TreeNode tnWellDig = new TreeNode("钻井",0, 1);
            tnWellDig.Name = TypeGeoFile.钻井.ToString();
            tnWellDig.Tag = TypeGeoFile.钻井;
            tnWell.Nodes.Add(tnWellDig);

            //测井
            TreeNode tnWellStructure = new TreeNode("井身结构", 0, 1);
            tnWellStructure.Name = TypeGeoFile.井身结构.ToString();
            tnWellStructure.Tag = TypeGeoFile.井身结构;
            tnWell.Nodes.Add(tnWellStructure);

            //测井
            TreeNode tnWellLogDir = new TreeNode("测井",0,1);
            tnWellLogDir.Name = TypeGeoFile.测井.ToString();
            tnWellLogDir.Tag = TypeGeoFile.测井;
            tnWell.Nodes.Add(tnWellLogDir);

            //
            TreeNode tnRecLogDir = new TreeNode("录井", 0, 1);
            tnRecLogDir.Name = TypeGeoFile.录井.ToString();
            tnRecLogDir.Tag = TypeGeoFile.录井;
            tnWell.Nodes.Add(tnRecLogDir);

            //
            TreeNode tnDirCore = new TreeNode("岩心", 0, 1);
            tnDirCore.Name = TypeGeoFile.岩心.ToString();
            tnDirCore.Tag = TypeGeoFile.岩心;
            tnWell.Nodes.Add(tnDirCore);

            //
            TreeNode tnDirAnalysisTest = new TreeNode("分析化验", 0, 1);
            tnDirAnalysisTest.Name = TypeGeoFile.分析化验.ToString();
            tnDirAnalysisTest.Tag = TypeGeoFile.分析化验;
            tnWell.Nodes.Add(tnDirAnalysisTest);

            //
            TreeNode tnDirOther = new TreeNode("文档", 0, 1);
            tnDirOther.Name = TypeGeoFile.其它.ToString();
            tnDirOther.Tag = TypeGeoFile.其它;
            tnWell.Nodes.Add(tnDirOther);
        }
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

       void setupDir()
       {
           if (sJHCurrent != "" && subDir != "")
           {
               dirCurrent = Path.Combine(cProjectManager.dirPathWellDir, sJHCurrent, subDir);
               if (!Directory.Exists(dirCurrent)) Directory.CreateDirectory(dirCurrent);
           }
       }

        private void lvFileGeo_DragEnter(object sender, DragEventArgs e)
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

        private void lvFileGeo_DragDrop(object sender, DragEventArgs e)
        {
            string[] directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
            //get all files inside folder            
            foreach (string fileDrop in directoryName)
            {
                addFile(fileDrop);
            }   
        }
        string makeUniqueFilePath(string filePath)
        {
            while (File.Exists(filePath))
            {
                string fileName = Path.GetFileName(filePath);
                string dirFile = Path.GetDirectoryName(filePath);
                filePath = Path.Combine(dirFile, "copy_" + fileName);
            }
            return filePath;

        }
        void addFile(string filePathSource)
        {
            if (sJHCurrent != "" && subDir != "")
            {
                setupDir();
                string filePathNew = Path.Combine(dirCurrent, Path.GetFileName(filePathSource));
                bool bDelete = cPublicMethodForm.checkRenameSameFile(filePathNew);
                if (bDelete == false) filePathNew = makeUniqueFilePath(filePathSource); 
                File.Copy(filePathSource, filePathNew, true); //覆盖
                lvFileGeo.Items.Add(Path.GetFileName(filePathNew)); 
            }
            else
            {
                MessageBox.Show("请选择操作目标路径。");
            }
        }

        private void lvFileGeo_DoubleClick(object sender, EventArgs e)
        {
            setupDir();
            string fileName=lvFileGeo.SelectedItems[0].SubItems[0].Text;
            string filePath = Path.Combine(dirCurrent, fileName);
            tsslPathCurrent.Text  = filePath;
            if (File.Exists(filePath)) System.Diagnostics.Process.Start(filePath);
            else MessageBox.Show("路径不正确。");
        }

        void loadFiles2LV() 
        {
            setupDir();
            lvFileGeo.Items.Clear();
            if (dirCurrent != "")
            {
                string[] files = Directory.GetFiles(dirCurrent);
                foreach (string file in files)
                {
                    addItem2LV(file);
                }
            }
        }

        void addItem2LV(string file) 
        {
            string fileName = Path.GetFileName(file);
            ListViewItem item = new ListViewItem(fileName);
            item.Tag = file;
            lvFileGeo.Items.Add(item);
        }
        private void tvFileManage_MouseUp(object sender, MouseEventArgs e)
        {
           TreeNode selectedNode = this.tvFileManage.GetNodeAt(e.X, e.Y);
            if (selectedNode != null)
            {
                if (selectedNode.Level == 1)
                {
                    sJHCurrent = selectedNode.Text;
                    subDir = "";
                }
                else if (selectedNode.Level == 2)
                {
                    sJHCurrent = selectedNode.Parent.Text;
                    subDir = selectedNode.Text;
                    
                    loadFiles2LV(); 
                }
                else sJHCurrent = "";
                this.tsslPathCurrent.Text = "//" + sJHCurrent+ "//" + subDir;
            }
            else 
            {
                this.tsslPathCurrent.Text  = "未选中对象";
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            deleteSelectItemInLV(); 
        }

        void deleteSelectItemInLV() 
        {
            foreach (ListViewItem eachItem in this.lvFileGeo.SelectedItems)
            {
                setupDir();
                string fileName = eachItem.SubItems[0].Text;
                string filePath = Path.Combine(dirCurrent, fileName);
                tsslPathCurrent.Text = filePath;
                if (File.Exists(filePath))
                {
                    DialogResult dialogResult = MessageBox.Show("注意：此操作不可恢复，确认删除？\n" + fileName, "提示", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        setClearViewControl();
                        File.Delete(filePath);
                        lvFileGeo.Items.Remove(eachItem);
                    }
                }
            }
        }

        void setClearViewControl() 
        {
            this.richTBXview.Text = "";
            if (picBoxView.Image != null)
            {
                picBoxView.Image.Dispose();
            }
            this.picBoxView.Image = null;
            this.webBrowserFile.Navigate("about:blank");
        }
        private void tsmiRename_Click(object sender, EventArgs e)
        {
            setupDir(); 
            if (lvFileGeo.SelectedItems.Count > 0)
            {
                ListViewItem selectItem = lvFileGeo.SelectedItems[0];
                string fileName = selectItem.SubItems[0].Text;
                FormInputBox inputBox = new FormInputBox("新文件名：", "请输入：", fileName);
                var result = inputBox.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = Path.Combine(dirCurrent, fileName);
                    string newInputFileName = inputBox.ReturnValueStr;
                    string newfilepath = Path.Combine(dirCurrent, newInputFileName);
                    bool bDelete = checkRenameSameFile(newfilepath);
                    if (bDelete == true)
                    {
                        File.Copy(filePath, newfilepath, bDelete); //用新文件名保存，
                        File.Delete(filePath);  //删除原文件
                        lvFileGeo.Items.Remove(selectItem);
                    }
                    addItem2LV(newfilepath);
                }
            }
        }
        bool checkRenameSameFile(string filePath)
        {
            bool bDelete = true;
            if (File.Exists(filePath))
            {
                DialogResult dialogResult = MessageBox.Show(" 是否覆盖？", "同名文件已存在", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) bDelete = false;
            }
            return bDelete;
        }


        private void tsmiOpenDir_Click(object sender, EventArgs e)
        {
            setupDir();
            System.Diagnostics.Process.Start("explorer.exe", dirCurrent);
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开项目：";
            ofdProjectPath.Filter = "所有文件|*.*";
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                addFile(ofdProjectPath.FileName);
            }
        }

        string filePathPDFViewTemp = Path.Combine(cProjectManager.dirPathTemp, "fileViewTemp.pdf");

        private void lvFileGeo_Click(object sender, EventArgs e)
        {
           
        }

        private void lvFileGeo_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void lvFileGeo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                setupDir();
                string fileName = lvFileGeo.SelectedItems[0].SubItems[0].Text;
                string filePath = Path.Combine(dirCurrent, fileName);
                tsslPathCurrent.Text = filePath;
                setClearViewControl();
                this.richTBXview.Visible = false;
                this.webBrowserFile.Visible = false;
                this.picBoxView.Visible = false;
                tsslViewInfor.Text = "";
                if (File.Exists(filePath))
                {
                    if (filePath.EndsWith(".jpg") ||
                       filePath.EndsWith(".png") ||
                       filePath.EndsWith(".gif") ||
                       filePath.EndsWith(".jpeg") ||
                       filePath.EndsWith(".bmp") ||
                       filePath.EndsWith(".wmf")
                    )
                    {
                        picBoxView.SizeMode = PictureBoxSizeMode.StretchImage;
                        picBoxView.Visible = true;
                        picBoxView.ImageLocation = filePath;
                    }
                    else if (filePath.EndsWith(".pdf"))
                    {
                        webBrowserFile.Visible = true;
                        File.Copy(filePath, filePathPDFViewTemp, true);
                        webBrowserFile.Navigate(filePathPDFViewTemp);
                        //this.richTBXview.Visible = true;
                        //richTBXview.Text = "pdf文档，请双击打开。";
                    }
                    else if (filePath.ToLower().EndsWith(".tif"))
                    {
                        picBoxView.Visible = true;
                        Bitmap b = new Bitmap(filePath);
                        picBoxView.Image = b;
                        picBoxView.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (
                        filePath.EndsWith(".xls") ||
                        filePath.EndsWith(".xlsx") ||
                        filePath.EndsWith(".doc") ||
                        filePath.EndsWith(".docx") ||
                        filePath.EndsWith(".ppt") ||
                        filePath.EndsWith(".pptx")
                        )
                    {
                        this.richTBXview.Visible = true;
                        richTBXview.Text = "office文档，请双击打开。";
                    }
                    else
                    {
                        this.richTBXview.Visible = true;
                        cPublicMethodForm.viewTextRichText(this.richTBXview, filePath, 100);
                        tsslViewInfor.Text = "文件前100行预览";
                    }
                }
            }//end 点击查看
        }

        private void tsmiTVOpenDir_Click(object sender, EventArgs e)
        {
            setupDir();
            System.Diagnostics.Process.Start("explorer.exe", dirCurrent);
        }

        private void tsmiTVRefresh_Click(object sender, EventArgs e)
        {
            setupTNwell2TV(this.tvFileManage);
        }

        private void tsmiRefreshDir_Click(object sender, EventArgs e)
        {
            loadFiles2LV();
        }

        private void lvFileGeo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void lvFileGeo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode  == Keys.Delete ) deleteSelectItemInLV(); 
        }

       
        
    } 
}
