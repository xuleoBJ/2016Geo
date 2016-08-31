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
    public partial class FormCalWellDistance : Form
    {
        public FormCalWellDistance()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            cPublicMethodForm.inialComboBox(cbbXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbJH, cProjectData.ltStrProjectJH);
            cPublicMethodForm.inialListBox(listBoxJH, cProjectData.ltStrProjectJH);
        }

        private void btnCalResult_Click(object sender, EventArgs e)
        {

            string sInjectWellSelected = this.cbbJH.SelectedItem.ToString();

            List<string> ltSelectedJH = cPublicMethodForm.ltStrSelectedItemsReturnFromListBox(listBoxJH);

            string fileName =Path.Combine( cProjectManager.dirPathTemp , sInjectWellSelected + "-WellDistance.txt");

            string sXCM = cbbXCM.SelectedItem.ToString();
            string sJH = cbbJH.SelectedItem.ToString();


            List<ItemDicLayerDataStatic> listCurrentLayerData = cIODicLayerDataStatic.readDicLayerData2struct().FindAll(p => p.sXCM == sXCM);
            ItemDicLayerDataStatic currentItem = listCurrentLayerData.Find(p => p.sJH==sJH);

            StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
            if (listCurrentLayerData.Count > 0)
            {
                foreach (ItemDicLayerDataStatic goalItem in listCurrentLayerData.FindAll(p=>ltSelectedJH.Contains(p.sJH)))
                {
                    List<string> ltStrWrited = new List<string>();
                    double distance = cCalDistance.calDistance2D(currentItem.dbX, currentItem.dbY, goalItem.dbX, goalItem.dbY);
                    ltStrWrited.Add(sXCM);
                    ltStrWrited.Add(sJH);
                    ltStrWrited.Add(goalItem.sJH);
                    ltStrWrited.Add(distance.ToString("0.00"));
                    sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
                }

            }

            sw.Close();

            cPublicMethodForm.read2DataGridViewByTextFile(fileName, this.dgvWellDistance);
        }

 

        private void btnSlectByXCM_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setListBoxChooseAll(listBoxJH); 
        }

        private void cbbXCM_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPublicMethodForm.setListBoxChooseAll(listBoxJH); 
        }

        private void btnSelectNo_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setListBoxChooseNo(listBoxJH);
        }
    }
}
