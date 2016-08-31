using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace DOGPlatform
{
    class cPublicMethodBase
    {
       
        public static TimeSpan ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }

        public static double unitPxScale(string sUnit) 
        {
            double fUnitPxScale = 3.78;
            switch (sUnit)
            {
                case "mm":
                    fUnitPxScale = 3.78;
                    break;
                case "px":
                    fUnitPxScale = 1;
                    break;
                case "in":
                    fUnitPxScale = 9.6;
                    break;
                case "ft":
                    fUnitPxScale = 115.2;
                    break;
                case "cm":
                    fUnitPxScale = 37.8;
                    break;
                default:
                    break;
            }
            return fUnitPxScale;
        }

        public static void showErrInfor(string sRightNote)
        {
            if (cProjectData.sErrLineInfor== "")
            {
                MessageBox.Show(sRightNote);
            }
            else
            {
                cProjectData.sErrLineInfor= "数据可能错误如下：" + " \r\n" + cProjectData.sErrLineInfor;
                cPublicMethodForm.outputErrInfor2Text(cProjectData.sErrLineInfor);
            }
        }

        public static void DirectoryDelAllFiles(string dirPath) 
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static List<string> splitText2ListCharByLength(string sText,double  dLimitWidth, Font font)
        {
            //分行处理
            List<string> ltStrRet=new List<string>();
            var stringSize = TextRenderer.MeasureText(sText, font);
            int inumLine = (int)(stringSize.Width / (dLimitWidth-2)) + 1;
            int iMaxChar = sText.Length / inumLine;
             for (int  i=0;i<=inumLine;i++)
                 ltStrRet.Add(sText.Substring(iMaxChar * i, Math.Min(iMaxChar, sText.Length - iMaxChar * i)));
             return ltStrRet;
        }
        /// <summary>
        /// 用\r换行
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="iWidth"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static List<string> splitText2LimitLineWithChangLine(string sText, int iWidth, Font font)
        {
            List<string> ltStrRet = new List<string>();
            List<string> ltSplit = sText.Split(new string[] {"\r\n"}, StringSplitOptions.None).ToList();
            foreach (string word in ltSplit) ltStrRet.AddRange(splitText2ListCharByLength(word, iWidth, font));
            return ltStrRet;
        }
        public static string getYMLastMonth(string sYYYYMM)
        {
            int iYM=int.Parse(sYYYYMM);
            if (iYM%100>1) return (iYM - 1).ToString(); //不是一月份
            else return (iYM/100 - 1).ToString()+"12";
        }
        private void LoadTreeViewFromXmlFile(string filename, TreeView trv)
        {
            // Load the XML document.
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(filename);
            // Add the root node's children to the TreeView.
            trv.Nodes.Clear();
            AddTreeViewChildNodes(trv.Nodes, xml_doc.DocumentElement);
            trv.CollapseAll();
        }


        private void AddTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode newNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;
            if (xmlNode.HasChildNodes)
            {
                nodeList = xmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    newNode = xmlNode.ChildNodes[i];
                    treeNode.Nodes.Add(new TreeNode(newNode.Name));
                    tNode = treeNode.Nodes[i];
                    AddTreeNode(newNode, tNode);
                }
            }
            else treeNode.Text = (xmlNode.OuterXml).Trim();
        }

        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                TreeNode new_node = parent_nodes.Add(child_node.Name);

                // Recursively make this node's descendants.
                AddTreeViewChildNodes(new_node.Nodes, child_node);

                // If this is a leaf node, make sure it's visible.
                if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
            }
        }


        public static string getRGB(Color m_color)
        {
            string r = m_color.R.ToString();
            string g = m_color.G.ToString();
            string b = m_color.B.ToString();
            return "rgb(" + r + "," + g + "," + b + ")";
        }

        public static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        /// <summary>
        /// 判断是否是一个#开头8位有效颜色
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public static bool isValidColor(string col)
        {
           return col.StartsWith("#") & (col.Length == 7 | col.Length == 4) & col.Substring(1).All(c => "ABCDEF0123456789".IndexOf(Char.ToUpper(c)) != -1);
       }
        public static String HexConverter(int r, int g, int b)
        {
        return  "#"+r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }

        public static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        public static int getCeilingNumer(double fValue, int iInteval)
        {
             return Convert.ToInt16(Math.Ceiling(fValue) / iInteval + 1) * iInteval;
        }

        public static void printsErrLineInforIndex(int iIndexLine)
        {
            StreamWriter swNew = new StreamWriter(cProjectManager.filePathRunInfor, false, Encoding.UTF8);
            swNew.WriteLine(iIndexLine.ToString());
            swNew.Close();
        }

        public static void outputErrInfor2Text(string errInfor)
        {
            StreamWriter swNew = new StreamWriter(cProjectManager.filePathRunInfor, false, Encoding.UTF8);
            swNew.WriteLine(DateTime.Now.ToString());
            swNew.WriteLine(errInfor);
            swNew.Close();
            System.Diagnostics.Process.Start("notepad.exe", cProjectManager.filePathRunInfor);
        }

        public static List<string> ltStrJHInProject(List<string> ltStrJH )
        {
            for (int i = (ltStrJH.Count - 1); i >= 0; i--)
            {
                if (cProjectData.ltStrProjectJH.Contains(ltStrJH[i]) == false)
                    ltStrJH.RemoveAt(i);
            }
            return ltStrJH;
        }
      

    }
}
