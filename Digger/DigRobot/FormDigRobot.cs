using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using DigRobot;
using System.Xml;

namespace DigRobot
{
    public partial class FormDigRobot : Form
    {
        public Image saveImage;                              //保存输入的图像
        private bool bLeftButtonDown = false;          //记录开关，是否是读入坐标数据

       SolidBrush pointBrush = new SolidBrush(Color.Blue);

       string strProperty = "point1";

       int iOperMode = 1;

        public FormDigRobot()
        {
            InitializeComponent();
            this.tbxProperty.Text = strProperty;
            this.dgv.Location = new Point(this.btnDelDgvLine.Location.Y - 3, this.btnDelDgvLine.Location.X) ;
            this.dgv.Dock = DockStyle.Bottom;
            this.splitContainer1.Panel2Collapsed = true;
            
        }

         private void pictureBox_OriginalPic_MouseClick(object sender, MouseEventArgs e)
        {
            switch (iOperMode)
            {
                case 1:
                    if (e.Button == MouseButtons.Left && bLeftButtonDown == true)
                    {
                        cRef3Points.tempPointScreen.X = -1;
                        cRef3Points.tempPointScreen.Y = -1;
                        int iCount = cRef3Points.ListRef3RealPosition.Count;
                        if (iCount <= 2)
                        {

                            Graphics g = ((PictureBox)sender).CreateGraphics();
                            g.FillEllipse(Brushes.Blue, e.X - 5, e.Y - 5, 10, 10);
                            g.FillEllipse(Brushes.Red, e.X - 4, e.Y - 4, 8, 8);
                            g.Dispose();
                            cRef3Points.tempPointScreen.X = e.X;
                            cRef3Points.tempPointScreen.Y = e.Y;
                            coordinateLocationForm coordinateLocationForm = new coordinateLocationForm();
                            if (coordinateLocationForm.ShowDialog() == DialogResult.OK)
                            {
                                PointF currentScreenPointF = new PointF(cRef3Points.tempPointScreen.X, cRef3Points.tempPointScreen.Y);
                                cRef3Points.ListRef3ScreenPosition.Add(currentScreenPointF);

                                PointF currentRealPointF = new PointF(cRef3Points.tempPointReal.X, cRef3Points.tempPointReal.Y);
                                cRef3Points.ListRef3RealPosition.Add(currentRealPointF);

                            }
                            if (iCount + 1 == 3) { calFactor(); MessageBox.Show("三点定位设置完毕，请点击开始采集！"); }
                        }
                        else if (iCount == 3)
                        {
                            Graphics g = ((PictureBox)sender).CreateGraphics();
                            g.FillEllipse(pointBrush, e.X - 4, e.Y - 4, 8, 8);
                            g.Dispose();
                            double realX = cRef3Points.ListRef3RealPosition[0].X + cRef3Points.fCordA1 * e.X + cRef3Points.fCordB1 * e.Y + cRef3Points.fCordC1;
                            double realY = cRef3Points.ListRef3RealPosition[0].Y + cRef3Points.fCordA2 * e.X + cRef3Points.fCordB2 * e.Y + cRef3Points.fCordC2;
                            int index = this.dgv.Rows.Add();

                            this.dgv.Rows[index].Cells[0].Value = realX.ToString("0.0");
                            this.dgv.Rows[index].Cells[1].Value = realY.ToString("0.0");
                            this.dgv.Rows[index].Cells[2].Value = strProperty;
                            toolStripStatusLabel_infor.Text = "X:" + realX.ToString("0.0000") + "    Y:" + realY.ToString("0.0000");
                        }
                    }
                    break;
                case 2:
                    MessageBox.Show( Win32.GetPixelColor(e.X, e.Y).ToString());
                    break;
            }
            

        }
   

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        //计算坐标系系数,需要修改 从 cPublicData.ListRef3ScreenPosition提取数据并计算系数才能完整
        public void calFactor()
        {
            double[,] calFoctorA1B1C1 = new double [3, 4];
            double[,] calFoctorA2B2C2 = new double[3, 4];
            if (cRef3Points.ListRef3ScreenPosition.Count == 3 && cRef3Points.ListRef3RealPosition.Count==3)
            {
                calFoctorA1B1C1[0, 0] = 0.0;
                calFoctorA2B2C2[0, 0] = 0.0;

                for (int i=0;i<3;i++)

                    {
                        calFoctorA1B1C1[i, 0] = cRef3Points.ListRef3ScreenPosition[i].X;
                        calFoctorA1B1C1[i, 1] = cRef3Points.ListRef3ScreenPosition[i].Y;
                        calFoctorA1B1C1[i, 2] = 1.0;
                        calFoctorA1B1C1[i, 3] = cRef3Points.ListRef3RealPosition[i].X - cRef3Points.ListRef3RealPosition[0].X;

                        calFoctorA2B2C2[i, 0] = cRef3Points.ListRef3ScreenPosition[i].X ;
                        calFoctorA2B2C2[i, 1] = cRef3Points.ListRef3ScreenPosition[i].Y ;
                        calFoctorA2B2C2[i, 2] = 1.0;
                        calFoctorA2B2C2[i, 3] = cRef3Points.ListRef3RealPosition[i].Y -cRef3Points.ListRef3RealPosition[0].Y;
                    }
                
            }
            else MessageBox.Show("设置定位坐标值有错误！");

            List<double> fListSolveD3_ABC1 = new List<double>();
            fListSolveD3_ABC1=cCalMatrix.solveLinear3(calFoctorA1B1C1);
            cRef3Points.fCordA1 = fListSolveD3_ABC1[0];
            cRef3Points.fCordB1 = fListSolveD3_ABC1[1];
            cRef3Points.fCordC1 =fListSolveD3_ABC1[2];

            List<double> fListSolveD3_ABC2 = new List<double>();
            fListSolveD3_ABC2=cCalMatrix.solveLinear3(calFoctorA2B2C2);
            cRef3Points.fCordA2 = fListSolveD3_ABC2[0];
            cRef3Points.fCordB2 = fListSolveD3_ABC2[1];
            cRef3Points.fCordC2 = fListSolveD3_ABC2[2];
        }

        private void ToolStripMenuItemSetSystem3Point_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择三个点作为参考基准点，请在图上点击开始采集第一个点：");
            bLeftButtonDown = true;
            cRef3Points.ListRef3ScreenPosition.Clear();
            cRef3Points.ListRef3RealPosition.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm about = new aboutForm();
            about.ShowDialog();
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   System.Diagnostics.Process.Start("DigRobot帮助.pdf"); 
        }

        private void initProjectPublicData()
        {
            cRef3Points.ListRef3RealPosition.Clear();
            cRef3Points.ListRef3ScreenPosition.Clear();
        }

        private void openPicture(string strPicturePath) 
        {
            saveImage = Image.FromFile(strPicturePath);                       //保存当前打开图像到saveImage变量中
            if (saveImage.Height < ptbOriginalPic.Height && saveImage.Width < ptbOriginalPic.Width)
                ptbOriginalPic.SizeMode = PictureBoxSizeMode.CenterImage;
            else ptbOriginalPic.SizeMode = PictureBoxSizeMode.StretchImage;

            ptbOriginalPic.Image = Image.FromFile(strPicturePath);               //将打开的图像存放到pictureBox中
        }

        private void openPicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "\\\\";
            openFileDialog.Filter = "jpg文件|*.jpg|bmp文件|*.bmp|png文件|*.png|GIF文件|*.gif|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fName = openFileDialog.FileName;
                openPicture(fName);
            }
        }


        private void FormDigRobot_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
        }

        private void FormDigRobot_Load(object sender, EventArgs e)
        {

        }

        private void FormDigRobot_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yes 保存工程并关闭，No 放弃关闭", "关闭工程", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { this.Dispose(true); }
            else e.Cancel = true; 
        }

        private void tbxProperty_TextChanged(object sender, EventArgs e)
        {
            if (tbxProperty.Text != "") strProperty = tbxProperty.Text;
            else strProperty = "point1";
        }

        private void OperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择三个点作为参考基准点，请在图上点击开始采集第一个点：");
            bLeftButtonDown = true;
            cRef3Points.ListRef3ScreenPosition.Clear();
            cRef3Points.ListRef3RealPosition.Clear();
        }

        private void btnDelDgvLine_Click(object sender, EventArgs e)
        {
            deleteSelectedRowInDataGridView(dgv);
        }

        public static void deleteSelectedRowInDataGridView(DataGridView dgv)
        {
            if (dgv.RowCount > 1)
            {
                int idRow = dgv.SelectedCells[0].RowIndex;
                if (idRow != dgv.RowCount - 1) dgv.Rows.RemoveAt(idRow);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Title = " 请输入保存数据的位置：";
            sfd.Filter = "txt文件|*.txt|所有文件|*.*";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            string resultFilePath ="c:\\dig.txt";
            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK) resultFilePath = sfd.FileName.ToString(); //获得文件路径 
            readDataGridView2TXTFile(dgv, resultFilePath);
        }

        public static void readDataGridView2TXTFile(DataGridView dgv, string filePathGeoTextWrited)
        {
                StreamWriter swWrited = new StreamWriter(filePathGeoTextWrited, false, Encoding.UTF8);

                for (int j = 0; j < dgv.RowCount - 1; j++)
                {
                    List<string> listData = new List<string>();
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        listData.Add(dgv.Rows[j].Cells[i].Value.ToString());
                    }
                    swWrited.Write(string.Join("\t", listData.ToArray()) + "\r\n");
                }
                swWrited.Close();

        }

        private void btnDelall_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }

       

        private void pnlColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlColor.BackColor = colorDialog.Color;
                pointBrush.Color = pnlColor.BackColor;
            }
        }

        private void tsmiDigitier_Click(object sender, EventArgs e)
        {
            iOperMode = 1; 
            this.splitContainer1.Panel2Collapsed = false;
            tsmiSet3Points.Enabled = true;
        }

        private void tsmiColorPic_Click(object sender, EventArgs e)
        {
            iOperMode = 2;
            this.splitContainer1.Panel2Collapsed = true;
            tsmiSet3Points.Enabled = false ;
        }


        public Bitmap CaptureScreen(double x, double y, double width, double height)
        {
            int ix, iy, iw, ih;
            ix = Convert.ToInt32(x);
            iy = Convert.ToInt32(y);
            iw = Convert.ToInt32(width);
            ih = Convert.ToInt32(height);
            Bitmap image = new Bitmap(iw, ih,
                   System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(ix, iy, ix, iy,
                     new System.Drawing.Size(iw, ih),
                     CopyPixelOperation.SourceCopy);
            return image;
        }

        private void tsmiCaptureScreen_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Bitmap bitmap = CaptureScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            ptbOriginalPic.Image=bitmap;
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
