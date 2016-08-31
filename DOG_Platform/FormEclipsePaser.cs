using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DOGPlatform
{
    public partial class FormEclipsePaser : Form
    {
        public FormEclipsePaser()
        {
            InitializeComponent();
        }
        List<string> ltLineEcl = new List<string>();
        List<string> ltFaceValue = new List<string>();
        int iNum = 50;
        int jNum = 50;
        private void btnReadFileECL_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开Eclipse文件：";
            ofdProjectPath.Filter = "eclipse网格文件|*.GRDECL";
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                string eclFilePath = ofdProjectPath.FileName;
                this.tbxFilepath.Text = eclFilePath;
                ltLineEcl=cIOGridEcl.readGridEcl(eclFilePath);
                getIJnum();
               ltFaceValue = getProperty();
               tbxInfor.Text = string.Join("\t",ltFaceValue.GetRange(0,800));
            }
            else
            {
            }
        }

        List<string> getProperty()
        {
            List<string> ltValue = new List<string>();
            bool bFace = false;
            for (int i=0;i<ltLineEcl.Count;i++)
            {
                string line=ltLineEcl[i];
                string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length > 0)
                {
                    string kWord = split[0];
                    if( bFace == true)
                    {
                        foreach(string sValue in split)
                        {
                            if (sValue == "/") return ltValue;
                            else 
                            {
                                if (sValue.IndexOf("*") > 0)
                                {
                                    string[] splitValue=sValue.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                                    int iNumCount = 0;
                                    int.TryParse(splitValue[0], out iNumCount);
                                    for (int kk = 0; kk < iNumCount; kk++) 
                                    {
                                        ltValue.Add(splitValue[1]);  
                                    }
                                }
                                else 
                                {
                                    ltValue.Add(sValue); 
                                }
                            }
                        }
                    }
                    if (kWord == "FACIES") bFace = true;
                   
                }
            } //end for

            return ltValue;
        }

        void getIJnum()
        {
            for (int i = 0; i < ltLineEcl.Count; i++)
            {
                string line = ltLineEcl[i];
                string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                //读取图头获取网格参数
                if (split.Length > 0)
                {
                    string kWord = split[0];
                    if (kWord == "SPECGRID")
                    {
                        string[] splitLineNext = ltLineEcl[i + 1].Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int.TryParse(splitLineNext[0], out iNum);
                        int.TryParse(splitLineNext[1], out jNum);
                        tbxNumI.Text = splitLineNext[0];
                        tbxNumJ.Text = splitLineNext[1];
                        return;
                    }
                }
            }
        }

        Color GetColor(Int32 rangeStart /*Complete Red*/,Int32 rangeEnd /*Complete Green*/,Int32 actualValue)
        { 
            if(rangeStart >= rangeEnd) return Color.Black;
            Int32 max = rangeEnd - rangeStart;// make the scale start from 0
            Int32 value = actualValue - rangeStart;// adjust the value accordingly
            Int32 blue =(255* value)/ max;// calculate green (the closer the value is to max, the greener it gets)
            Int32 red = 255 - blue;// set red as inverse of green
            return Color.FromArgb((Byte)red, (Byte)0, (Byte)blue);
        }
        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        public  void addGrid(Panel panel, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            Font font = new Font("黑体", 8);
            Brush blueBrush = Brushes.Blue;
            Pen pen = new Pen(Color.Black, 0.5F);

            //for (int i = 0; i < nI; i++)
            //{
            //    int iXCurrentView = panel.Width*i/nI;
            //    Point point1 = new Point(iXCurrentView, 0);
            //    Point point2 = new Point(iXCurrentView, panel.Height);
            //    dc.DrawLine(pen, point1, point2);
            //    //dc.DrawString((cProjectData.dfMapXrealRefer + i * 500).ToString(), font, blueBrush, iXCurrentView, 0);
            //}

            //for (int j = 0; j < nJ; j++)
            //{
            //    int iYCurrentView = panel.Height  * j / nJ;
            //    Point point3 = new Point(0, iYCurrentView);
            //    Point point4 = new Point(panel.Width, iYCurrentView);
            //    dc.DrawLine(pen, point3, point4);
            //    //dc.DrawString((cProjectData.dfMapYrealRefer - i * 500).ToString(), font, blueBrush, 0, iYCurrentView);
            //}

            float iWidthGrid = (float)panel.Width / this.iNum ;
            float iHeightGrid = (float)panel.Height / this.jNum;
            for (int j = 0; j < jNum; j++)
            {
                float iYCurrentView = iHeightGrid * j; //当前Y
                for (int i = 0; i < iNum; i++)
                {
                    float iXCurrentView = iWidthGrid * i; //当前X
                    Random rnd = new Random();
                    int iRand = rnd.Next(1, 1000);
                    Color myColor = GetColor(1, 1000, iRand);
                    if (jNum * j + i < ltFaceValue.Count) 
                    {
                        myColor = ltFaceValue[jNum * j + i] == "1" ? Color.Red : Color.Blue;
                    }
                  //  RectangleF rt = new RectangleF(iXCurrentView, iYCurrentView, iWidthGrid, iHeightGrid);
                    SolidBrush brush = new SolidBrush(myColor);
                    dc.FillRectangle(brush, iXCurrentView, iYCurrentView, iWidthGrid, iHeightGrid);
                    brush.Dispose();
                    dc.DrawRectangle(pen, iXCurrentView, iYCurrentView, iWidthGrid, iHeightGrid);
                }
              
            }
        }
        private void panelVoronoi_Paint(object sender, PaintEventArgs e)
        {
            Panel panelDraw = sender as Panel;
            addGrid(panelDraw, e);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int iPanelWidth = 500;//显示好看pannel比最大大4个网格
            int iPanelHeight = 500; 
            panelEclipse.Dock = System.Windows.Forms.DockStyle.None;

            panelEclipse.Width = iPanelWidth;
            panelEclipse.Height = iPanelHeight;
            this.panelEclipse.Invalidate();
            this.panelEclipse.Focus();
        }
    }
}
