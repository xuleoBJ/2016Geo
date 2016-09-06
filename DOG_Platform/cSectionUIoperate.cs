using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using DOGPlatform.XML;
using System.Drawing;

namespace DOGPlatform
{
    class cSectionUIoperate
    {
        public static DialogResult setNodeProperty(TreeNode selectNode, string filePathOper)
        {
            DialogResult result = DialogResult.OK;
            string selectNodeID=selectNode.Name;
            XmlNode selectXmlNode = cXmlBase.selectNodeByID(filePathOper, selectNode.Name);
            if (selectNode.Level == 0) //页面设置
            {
                FormSettingShowState wellShowSetting = new FormSettingShowState(filePathOper);
                result=wellShowSetting.ShowDialog();
            }
            if (selectNode.Level == 1) //道内设置
            {
                FormSettingSectionTrack newForm = new FormSettingSectionTrack(filePathOper, selectNode.Name);
                result = newForm.ShowDialog(); 
            }

            if (selectNode.Level == 2) //道内属性设置
            {
                if (selectNode.Parent.Tag.ToString() == TypeTrack.曲线道.ToString())
                {
                    FormSettingSectionLog setLogCurve = new FormSettingSectionLog(filePathOper, selectNodeID);
                    result=setLogCurve.ShowDialog();
                }
                if (cProjectManager.ltStrTrackTypeIntervalProperty.IndexOf( selectNode.Parent.Tag.ToString())>=0)
                {
                    FormSettingSectionDataItemView setJSJL = new FormSettingSectionDataItemView(filePathOper, selectNodeID, selectNode.Parent.Tag.ToString());
                    result=setJSJL.ShowDialog();
                }
             
                if (selectNode.Parent.Tag.ToString() == TypeTrack.分层.ToString())
                {
                    FormSettingSectionLayer setLayer = new FormSettingSectionLayer(filePathOper, selectNode.Parent.Name,selectNodeID);
                    result=setLayer.ShowDialog();
                }
                if (selectNode.Parent.Tag.ToString() == TypeTrack.文本道.ToString())
                {
                    FormSettingSectionText setText = new FormSettingSectionText(filePathOper, selectNodeID);
                    result=setText.ShowDialog();
                }
            }
            return result;
        }

        //节点名存ID 通过id xml和 treeview 关联 
        public static DialogResult updateTrackData(string sJHSelected, TreeNode selectNode, string filePathOper)
        {
            string sTrackID=selectNode.Name;
            XmlNode selectXmlNode = cXmlBase.selectNodeByID(filePathOper, sTrackID);
            string typeTrackstr = selectNode.Tag.ToString();
            DialogResult resultRet = DialogResult.OK;
            if (selectNode.Level == 1) 
            {
                if (selectNode.Tag.ToString() == TypeTrack.深度尺.ToString())
                {
                    FormSettingSectionDepthRuler setRuler = new FormSettingSectionDepthRuler(filePathOper, sTrackID);
                    resultRet = setRuler.ShowDialog();
                }
                else
                {
                    FormDataImportWell formInputDataTableSingleWell = new
                              FormDataImportWell(sJHSelected, typeTrackstr, filePathOper, sTrackID);
                    resultRet = formInputDataTableSingleWell.ShowDialog();
                }
            }

            if (selectNode.Level == 2)
            {
                if (selectNode.Parent.Tag.ToString() == TypeTrack.曲线道.ToString())
                {
                    TypeTrack typetrack = (TypeTrack)Enum.Parse(typeof(TypeTrack), selectNode.Parent.Tag.ToString());
                    string sLogName=selectNode.Tag.ToString();
                    FormSectionDataLog formInputDataTableSingleWell = new
                             FormSectionDataLog(sJHSelected, sLogName, typetrack.ToString(), filePathOper, sTrackID);
                    resultRet = formInputDataTableSingleWell.ShowDialog();
                 
                }
            }//end lever2
            return resultRet;
        }

        public static DialogResult updateTrackData(string filePathOper, string sTrackID)
        {
            string sJH = cXmlDocSectionWell.getNodeInnerText(filePathOper, cXmlDocSectionWell.fullPathJH);
            XmlNode selectTrack = cXmlBase.selectNodeByID(filePathOper, sTrackID);
            string typeTrackstr = cXmlDocSectionWell.getTrackTypeByID(filePathOper, sTrackID);
            DialogResult resultRet = DialogResult.OK;
            if (typeTrackstr == TypeTrack.组分.ToString()) 
            {
                FormSectionDataLogComposition newDataImport = new FormSectionDataLogComposition(sJH, typeTrackstr, filePathOper, sTrackID);
                resultRet = newDataImport.ShowDialog();
            }
            else if (typeTrackstr != TypeTrack.曲线道.ToString())
            {
                FormDataImportWell formInputDataTableSingleWell = new
                         FormDataImportWell(sJH, typeTrackstr, filePathOper, sTrackID);
                resultRet = formInputDataTableSingleWell.ShowDialog();
            }
            return resultRet;
        }

        public static void selectTrackUp(TreeView tvSectionEdit, TreeNode selectNode, string filePathOper, string sIDtrack)
        {
            if (selectNode != null && selectNode.Level == 1)
            {
                cPublicMethodForm.upTreeViewNote(tvSectionEdit);
                cXmlDocSectionWell.upSelectTrack(filePathOper, tvSectionEdit.SelectedNode.Name.ToString());
            }
        }

         public static void selectTrackDown(TreeView tvSectionEdit, TreeNode selectNode, string filePathOper, string sIDtrack)
        {
            if (selectNode != null && selectNode.Level == 1)
            {
               cPublicMethodForm.downTreeViewNote(tvSectionEdit);
                cXmlDocSectionWell.downSelectTrack(filePathOper, tvSectionEdit.SelectedNode.Name.ToString());
            }
        }
        
         public static void selectItemDelete( TreeNode selectNode, string filePathOper, string sIDtrack)
         {

             if (selectNode != null && selectNode.Level >= 1)
             {
                 DialogResult dialogResult = MessageBox.Show("将删除" + selectNode.Text + "，确认删除？", "删除选中项", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     cXmlDocSectionWell.deleteItemByID(filePathOper, selectNode.Name.ToString());
                     selectNode.Remove();
                 }
             }
             if (selectNode.Parent != null) selectNode.Parent.Expand();
         }

         public static void deleteItemByID(TreeNode selectNode, string filePathOper, string sIDtrack) 
         {
             if (selectNode != null)
             {
                 DialogResult dialogResult = MessageBox.Show("将删除选中:" + selectNode.Text + "，确认删除？", "删除选中", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     cXmlDocSectionWell.deleteItemByID(filePathOper, selectNode.Name.ToString());
                     selectNode.Remove();
                 }
             }
             if (selectNode.Parent != null) selectNode.Parent.Expand();
         }

         public static Point getOffSet(WebBrowser wbSVG)
         {
             Point offPointRet = new Point(0, 0);
             if (wbSVG.Document != null)
             {
                 HtmlElementCollection eleCol=wbSVG.Document.GetElementsByTagName("svg");
                 if (eleCol.Count > 0)
                 {
                     HtmlElement ele = eleCol[0];
                     if (ele != null)
                     {
                         offPointRet.X = ele.ScrollLeft;
                         offPointRet.Y = ele.ScrollTop;
                     }
                 }
             }
             return offPointRet;
         }
        
    }
}
