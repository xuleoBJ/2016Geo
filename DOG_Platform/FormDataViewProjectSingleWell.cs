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
    public partial class FormDataViewProjectSingleWell : Form
    {

        public string sJH = "";
        string filePathOperation = "";
        public FormDataViewProjectSingleWell(string _sJH)
        {
            InitializeComponent();
            initializeForm(_sJH);
        }

        void initializeForm(string _sJH)
        {
            this.sJH = _sJH;
            filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellPath);
            foreach(string item in cProjectData.ltStrProjectJH)
            {
              cbbJH.Items.Add(item );
            }
            cbbJH.SelectedIndex=cProjectData.ltStrProjectJH.IndexOf(_sJH) ;
            List<string> ltCbbdataType = new List<string>();
            ltCbbdataType.Add(TypeInputFile.井轨迹.ToString());
            ltCbbdataType.Add(TypeInputFile.分层数据.ToString());
            ltCbbdataType.Add(TypeInputFile.测井解释.ToString());
            ltCbbdataType.Add(TypeInputFile.射孔数据.ToString());
            ltCbbdataType.Add(TypeInputFile.吸水剖面.ToString());
            foreach (string item in ltCbbdataType)
            {
                this.cbbDataType.Items.Add(item);
            }
            this.filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellPath);
            updateDgvByGeoText();
        }


        void updateDgvByGeoText()
        {
            if (cbbJH.SelectedIndex >= 0 && cbbDataType.SelectedIndex >= 0)
            {
                this.sJH = cbbJH.SelectedItem.ToString();
                if (cbbDataType.SelectedItem.ToString() == TypeInputFile.井轨迹.ToString())
                {
                    this.filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellPath);
                }
                if (cbbDataType.SelectedItem.ToString() == TypeInputFile.测井解释.ToString())
                {
                    this.filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellJSJL);
                }
                if (cbbDataType.SelectedItem.ToString() == TypeInputFile.分层数据.ToString())
                {
                    this.filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellLayerDepth);
                }
                if (cbbDataType.SelectedItem.ToString() == TypeInputFile.射孔数据.ToString())
                {
                    this.filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellPerforation);
                }
                if (cbbDataType.SelectedItem.ToString() == TypeInputFile.吸水剖面.ToString())
                {
                    this.filePathOperation = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellProfile);
                }
                this.Text = this.sJH;
                cPublicMethodForm.loadDataGridViewWithGeoText(this.dgvDataTable, this.filePathOperation);
               
            }
        }
      

        private void cbbJH_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDgvByGeoText();
        }

        private void cbbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDgvByGeoText();
        }

        


    }
}
