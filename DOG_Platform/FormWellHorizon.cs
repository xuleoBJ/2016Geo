using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.IO;

namespace DOGPlatform
{
    public partial class FormWellHorizon : Form
    {
        string filePathOperate; 
        public FormWellHorizon()
        {
            InitializeComponent();
            cPublicMethodForm.inialListBox(lbxJH, cProjectData.ltProjectWell.FindAll(p=>p.WellPathList.Count>3).Select(p=>p.sJH).ToList());
        }
        private void btn_addWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.transferItemFromleftListBox2rightListBox(lbxJH, lbxJHSeclected);
        }

        private void numUDHorizonalLineWidth_ValueChanged(object sender, EventArgs e)
        {
            cXMLLayerMapHorizonalWell.setLineWidthHorzionalInterval(filePathOperate, Convert.ToInt16(this.nUDLineWidthHorizonalInterval.Value));
        }
        private void btn_deleteWell_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.deleteSlectedItemFromListBox(lbxJHSeclected);
        }
        private void cbbColorHorizonalInterval_MouseClick(object sender, MouseEventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(this.cbbColorHorizonalInterval);
            string rgbColor = cPublicMethodForm.getRGB(this.cbbColorHorizonalInterval.BackColor);
            cXMLLayerMapHorizonalWell.setColorHorionalInterval(this.filePathOperate, rgbColor);
        }
        private void cbxAddHorizonWell_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAddHorizonWell.Checked == true)
            {
                List<string> llistHorizinalJH = new List<string>();
                foreach (object selecteditem in lbxJHSeclected.Items)
                {
                    string strItem = selecteditem as String;
                    llistHorizinalJH.Add(strItem);
                }
                //add svg文件中水平井段
                if (File.Exists(filePathOperate))
                {
                    cXMLLayerMapHorizonalWell.delHorizonalWellIntervalNode(this.filePathOperate);
                    List<string> _ltStrData = new List<string>();
                    foreach (string _sjh in llistHorizinalJH)
                    {
                        List<ItemDicWellPath> currentWellPath = cIOinputWellPath.readWellPath2Struct(_sjh);
                        //井必须在project井范围内
                        if (cProjectData.ltStrProjectJH.IndexOf(_sjh) >= 0)
                        {
                            ItemDicWellPath top = currentWellPath.Find(x => x.f_incl > 80);
                            ItemDicWellPath tail = currentWellPath.FindLast(x => x.f_incl > 80);
                            // 井号+ 井型 + 井口view坐标 + head view 坐标 + tail view 坐标 

                      //      ItemWellMapPosition item = this.listWellsStatic.Find(x => x.sJH == _sjh);
                            ItemWellMapPosition item = new ItemWellMapPosition();
                            if (item != null && top.sJH != null && tail.sJH != null)
                            {
                                _ltStrData.Add(_sjh);
                                _ltStrData.Add(item.iWellType.ToString());

                                _ltStrData.Add(item.dbX.ToString());
                                _ltStrData.Add(item.dbY.ToString());


                                _ltStrData.Add(top.dbX.ToString());
                                _ltStrData.Add(top.dbY.ToString());

                                _ltStrData.Add(tail.dbX.ToString());
                                _ltStrData.Add(tail.dbY.ToString());

                            }
                        }
                    }//end foreach

                    string _data = string.Join(" ", _ltStrData);
                    cXMLLayerMapHorizonalWell.addLayerWellHorizonalInterval2XML(this.filePathOperate, "horizonalWellInterval", _data);
                }
                else MessageBox.Show("请先创建原始图件。");
            }
            else
            {   //删除水平井段
                cXMLLayerMapHorizonalWell.delHorizonalWellIntervalNode(this.filePathOperate);
            }


        }
    }
}
