using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.Xml;


namespace DOGPlatform
{
    public partial class FormSettingModeInterval : Form
    {
        string filePathSectionGeoCss;
        string dirSectionData;
        List<ItemWellSection> listWellsSection = new List<ItemWellSection>();
        public FormSettingModeInterval(string _filePathSectionGeoCss, string _dirSectionData)
        {
            InitializeComponent();
            filePathSectionGeoCss = _filePathSectionGeoCss;
            dirSectionData = _dirSectionData;
            initialForm();
        }

        void initialForm() 
        {
            cPublicMethodForm.inialComboBox(cbbTopXCM, cProjectData.ltStrProjectXCM);
            cPublicMethodForm.inialComboBox(cbbBottomXCM, cProjectData.ltStrProjectXCM);
            foreach (XmlElement elWell in cXmlDocSectionGeo.getWellNodes(filePathSectionGeoCss))
            {
                ItemWellSection item = new ItemWellSection(elWell["JH"].InnerText);
                item.fShowedDepthTop = float.Parse(elWell["fShowTop"].InnerText); 
                item.fShowedDepthBase = float.Parse(elWell["fShowBot"].InnerText);
                item.fXview = float.Parse(elWell["Xview"].InnerText);
                item.fYview = float.Parse(elWell["Yview"].InnerText);
                listWellsSection.Add(item);
            }
        }

        List<string> getSelectListLayer() 
        {
            List<string> ltStrSelectedXCM = new List<string>();
            string sTopXCM = this.cbbTopXCM.SelectedItem.ToString();
            int iTopIndex = cProjectData.ltStrProjectXCM.IndexOf(sTopXCM);
            string sBottomXCM = this.cbbBottomXCM.SelectedItem.ToString();
            int iBottomIndex = cProjectData.ltStrProjectXCM.IndexOf(sBottomXCM);
            if (iBottomIndex - iTopIndex >= 0) ltStrSelectedXCM = cProjectData.ltStrProjectXCM.GetRange(iTopIndex, iBottomIndex - iTopIndex + 1);
            return ltStrSelectedXCM; 
        }

        void makeNewShowDepth()
        {
            List<string> ltStrSelectedXCM = getSelectListLayer();
            if (ltStrSelectedXCM.Count>0)
            {
                int _up = Convert.ToInt16(this.nUDtopDepthUp.Value);
                int _down = Convert.ToInt16(this.nUDbottomDepthDown.Value);
                //重新给显示的顶底赋值
                foreach(ItemWellSection item in listWellsSection)
                {
                    string sJH = item.sJH;
                    //有可能上下层有缺失。。。所以这块的技巧是找出深度序列，取最大最小值
                    cIOinputLayerDepth fileLayerDepth = new cIOinputLayerDepth();
                    List<float> fListDS1Return = fileLayerDepth.selectDepthListFromLayerDepthByJHAndXCMList(sJH, ltStrSelectedXCM);
                    if (fListDS1Return.Count > 0)  //返回值为空 说明所选层段整个缺失！
                    {
                        item.fShowedDepthTop = fListDS1Return.Min() - _up;
                        item.fShowedDepthBase = fListDS1Return.Max() + _down;
                        cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "fShowTop", item.fShowedDepthTop.ToString("0"));
                        cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "fShowBot", item.fShowedDepthBase.ToString("0"));
                    }
                }//end foreach
            }//end if
        }

        private void btnSectionShowDepth_Click(object sender, EventArgs e)
        {
            makeNewShowDepth();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnFlattedByTop_Click(object sender, EventArgs e)
        {
            makeFlattedByLayer(cbxFlattedTrans2TVD.Checked);
            this.DialogResult = DialogResult.OK;
        }

        void makeFlattedByLayer(bool bFlattedTVD)
        {
            string sTopXCM = this.cbbTopXCM.SelectedItem.ToString();
            cXmlBase.setNodeInnerText(filePathSectionGeoCss, cXETrackRuler.xmlFullPathiVisible, "0");
            foreach (ItemWellSection item in listWellsSection)
            {
                string sJH = item.sJH;
                string filePathOper = dirSectionData + "//" + sJH + ".xml";
                float fTop = -999;
                //应该先在文件中按层名查找个性layer深度
                XmlNode xnProperty= cXmlBase.selectNodeByInnerText(filePathOper, "sProperty", sTopXCM);
                if (xnProperty != null)
                {
                    itemDrawDataIntervalValue xn = new itemDrawDataIntervalValue(xnProperty.ParentNode);
                    fTop = xn.top;
                }
                else
                {
                    cIOinputLayerDepth fileLayerDepth = new cIOinputLayerDepth();
                    fTop = fileLayerDepth.selectTopDepthMDByJHAndXCM(sJH, sTopXCM);
                }
                if (fTop > 0)  //返回值-999 说明未找到 
                {
                    if( bFlattedTVD == false) cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "Yview", (-fTop).ToString());
                    else
                    {
                        float fTVD = cIOinputWellPath.getTVDByJHAndMD(sJH, fTop); //md->tvd
                        cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "Yview", (-fTVD).ToString());
                    }
                }
            } 
        }

        private void btnByElevation_Click(object sender, EventArgs e)
        {
            cXmlBase.setNodeInnerText(filePathSectionGeoCss, cXETrackRuler.xmlFullPathiVisible, "1");
            foreach (ItemWellSection item in listWellsSection)
            {
                string sJH = item.sJH;
                cXmlBase.setSelectedNodeChildNodeValue(filePathSectionGeoCss, sJH, "Yview", (-item.fKB).ToString());
            } 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConnectLayerByTop_Click(object sender, EventArgs e)
        {
            List<string> ltStrSelectedXCM = getSelectListLayer();
            foreach (string sXCM in ltStrSelectedXCM)
            {
                for (int i = 0; i < listWellsSection.Count - 1; i++)
                {
                    //搜索单井和下一口井的地层名；地层名必须唯一
                    cDataItemConnect selectItem1 = getLayerItem(listWellsSection[i].sJH, sXCM);
                    cDataItemConnect selectItem2 = getLayerItem(listWellsSection[i + 1].sJH, sXCM);
                    cXmlDocSectionGeo.addConnectDataItem(this.filePathSectionGeoCss, 1, selectItem1, selectItem2);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        cDataItemConnect getLayerItem(string sJH, string sLayer)
        {
            cDataItemConnect dataItemConnect = new cDataItemConnect();

            string filePathOper = dirSectionData + "//" + sJH + ".xml";

            XmlDocument wellTemplateXML = new XmlDocument();
            wellTemplateXML.Load(filePathOper);
            //在文件道中循环，找到第一个地层道
            XmlNodeList trackNodeList = cXmlDocSectionWell.getTrackNodes(filePathOper);
            foreach (XmlNode xnTrack in trackNodeList)
            {
                if (xnTrack["trackType"].InnerText == TypeTrack.分层.ToString())
                {
                    dataItemConnect.sIDTrack = xnTrack.Attributes["id"].Value;
                    dataItemConnect.sJH = sJH;
                    dataItemConnect.typeTrack = TypeTrack.分层.ToString();
                    string sPath = string.Format(".//sProperty[text()=\"{0}\"]", sLayer);
                    XmlNode selectNode = xnTrack.SelectSingleNode(sPath);
                    if (selectNode != null)
                    {
                        XmlNode dataItem = selectNode.ParentNode;
                        dataItemConnect.sIDDataItem = dataItem.Attributes["id"].Value;
                        dataItemConnect.sFill = sLayer;
                        return dataItemConnect;
                    }
                }
            }
            return dataItemConnect;

        }

        private void btnClearConnectLayer_Click(object sender, EventArgs e)
        {
            cXmlDocSectionGeo.clearAllConnectDataItem(this.filePathSectionGeoCss);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
