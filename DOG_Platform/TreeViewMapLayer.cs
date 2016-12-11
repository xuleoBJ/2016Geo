using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing;
using DOGPlatform.XML;

namespace DOGPlatform
{
    class TreeViewMapLayer
    {
        public static void setupLayerNode(TreeNode tn, string filePathOper)
        {
            //read xml and treeview
            string sLayer = cXmlBase.getNodeInnerText(filePathOper, cXmlDocLayer.fmpXCM);  //井号从新建窗口读入

            foreach (XmlElement el_layer in cXmlDocLayer.getLayerNodes(filePathOper))
            {
                layerDataDraw curLayerDraw = new layerDataDraw(el_layer);
                TreeNode tnode = new TreeNode();
                tnode.Text = curLayerDraw.sLayerTitle;
                tnode.Name = curLayerDraw.sLayerID;  //结点name
                tnode.Tag = curLayerDraw.sLayerType;
                tn.Nodes.Add(tnode);
                if (curLayerDraw.iVisible > 0) tnode.Checked = true;
                else tnode.Checked = false;
            }
        }
    }
}
