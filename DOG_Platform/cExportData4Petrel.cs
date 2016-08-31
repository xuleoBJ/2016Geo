using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cExportData4Petrel
    {
        public static void exportWellHead()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //设置文件类型
            sfd.Filter = "petrel井头文件（*.txt）|*.txt";

            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;

            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                List<ItemWellHead> listWellHead = cIOinputWellHead.readWellHead2Struct();
                StreamWriter sw = new StreamWriter(localFilePath, false, Encoding.ASCII);
                foreach (ItemWellHead item in listWellHead)
                {
                    List<string> ltStrTempWrited = new List<string>();
                    ltStrTempWrited.Add(item.sJH);
                    ltStrTempWrited.Add(item.dbX.ToString());
                    ltStrTempWrited.Add(item.dbY.ToString());
                    ltStrTempWrited.Add(item.fKB.ToString());
                    ltStrTempWrited.Add(item.iWellType.ToString());
                    sw.WriteLine(string.Join("\t", ltStrTempWrited.ToArray()));
                }
                sw.Close();
                MessageBox.Show("petrel导出完成");
            }
           
        }

        public static void exportWellInterpretation()
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            //点了保存按钮进入
            if (fd.ShowDialog()== DialogResult.OK)
            {
                foreach (string _sJH in cProjectData.ltStrProjectJH)
                {
                    string localFilePath = Path.Combine(fd.SelectedPath, _sJH + ".txt");
                    List<ItemJSJL> listJSJL = cIOinputJSJL.readJSJL2Struct(_sJH);
                    StreamWriter sw = new StreamWriter(localFilePath, false, Encoding.ASCII);
                    foreach (ItemJSJL item in listJSJL)
                    {
                        List<string> ltStrTempWrited = new List<string>();
                        ltStrTempWrited.Add(item.sJH);
                        ltStrTempWrited.Add(item.fDS1.ToString());
                        ltStrTempWrited.Add(item.fDS2.ToString());
                        ltStrTempWrited.Add(item.iJSJL.ToString());
                        sw.WriteLine(string.Join("\t", ltStrTempWrited.ToArray()));
                    }
                    sw.Close();
                 
                }
            }
           MessageBox.Show("导出完成");
        }

        public static void exportWellTops()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //设置文件类型
            sfd.Filter = "WellTops文件（*.txt）|*.txt";

            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            sfd.RestoreDirectory = true;

            //点了保存按钮进入
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                MessageBox.Show("需要编写");
            }
            //List<ItemLayerDepth> ltPetrelWellTops = new List<ItemLayerDepth>();
            //List<ItemLayerDepth> ltLayerDepth = cIOinputLayerDepth.readLayerDepth2Struct(); 
            //StreamWriter sw = new StreamWriter(filePath, false, Encoding.ASCII);
            //foreach(string _sJH in cProjectData.ltStrProjectJH)
            //    foreach (string _xch in cProjectData.ltStrProjectXCM)
            //    {
            //        ItemLayerDepth _currentLayerDepth = new ItemLayerDepth();
            //        _currentLayerDepth.sJH = _sJH;
            //        _currentLayerDepth.sXCM = _xch;
            //        _currentLayerDepth.fDS1 = 0.0f;
            //        _currentLayerDepth.fDS2 = 0.0f;
            //        List<ItemLayerDepth> _select = ltLayerDepth.FindAll(p => p.sJH == _sJH && p.sXCM == _xch).ToList();
            //        if (_select.Count>0) 
            //        {
            //            _currentLayerDepth.fDS1 = _select.Min(p => p.fDS1);
            //            _currentLayerDepth.fDS2 = _select.Max(p => p.fDS2);
            //        }
            //        ltPetrelWellTops.Add(_currentLayerDepth);
            //    }
            ////自动填写的标识是fds2是0
           
            //for (int i=0;i<ltPetrelWellTops.Count;i++) 
            //{
            //    ItemLayerDepth item = ltPetrelWellTops[i];
            //    List<string> ltStrTempWrited = new List<string>();
            //    ltStrTempWrited.Add(item.sJH);
            //    ltStrTempWrited.Add(item.sXCM.ToString());
            //    if (item.fDS1 == 0.0 && i < ltPetrelWellTops.Count - 1 && item.sJH == ltPetrelWellTops[i + 1].sJH) //非最后一行的处理且与下行同号
            //    {
            //         item.fDS1 = ltPetrelWellTops[i + 1].fDS1;
            //    }
            //    if (item.fDS1 == 0.0 &&i>1 && i < ltPetrelWellTops.Count - 1 && item.sJH != ltPetrelWellTops[i + 1].sJH)
            //        //
            //    {
            //        if (item.sJH == ltPetrelWellTops[i -1].sJH) item.fDS1 = ltPetrelWellTops[i - 1].fDS2;
            //    }
            //    if (item.fDS1 == 0.0 && i == ltPetrelWellTops.Count - 1 )//最后一行的处理
            //    {
            //        if (item.sJH == ltPetrelWellTops[i - 1].sJH) item.fDS1 = ltPetrelWellTops[i - 1].fDS2;
            //    }
            //    ltStrTempWrited.Add(item.fDS1.ToString());
            //    ltStrTempWrited.Add(item.fDS2.ToString());
            //    sw.WriteLine(string.Join("\t", ltStrTempWrited.ToArray()));
            //}
            //sw.Close();
            MessageBox.Show("需要编写");
        }
    }
}
