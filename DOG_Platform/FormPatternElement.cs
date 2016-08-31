using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DOGPlatform.SVG;
using System.IO;
using System.Xml.Linq;
using System.Drawing.Imaging;
using DigRobot;

namespace DOGPlatform
{
    public partial class FormPatternElement : Form
    {
        public FormPatternElement()
        {
            InitializeComponent();
            tbcPattern.TabPages.Remove(tbgPatternLayer);
            tbcPattern.TabPages.Remove(tbgPatternVolcanicRock);
        }

        string sLithoName = "粗砂岩";
        string sID = "101";
        bool hasSplit = false;

        int numfilePathTemp = 0;//生成预览图的编号

        private void bthLitho_Click(object sender, EventArgs e)
        {
           sLithoName = "粗砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text;
            sID = "101";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }
         XElement getDef4SandStone(string sLithoName, string sID)
        {
            int iHeightPattern = Convert.ToInt16(nUDPatternSandHeight.Value);
            int iWidthPattern = iHeightPattern * 2;
            string sBackColor = cPublicMethodBase.getRGB(cbbPatternSandBackColor.BackColor);
            string sCircleColor = cPublicMethodBase.getRGB(this.cbbInnerColor.BackColor);
           return cSVGXEPatternLithoSand.lithoPatternDefsSand(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor, sCircleColor, hasSplit);
        }


         XElement getDef4MudStone(string sLithoName, string sID)
         {
             int iHeightPattern = Convert.ToInt16(this.nUDPatternMudHeight.Value);
             int iWidthPattern = iHeightPattern*2;
             string sBackColor = cPublicMethodBase.getRGB(this.cbbPatternMudBackColor.BackColor);
             return cSVGXEPatternMud.lithoPatternDefsMud(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor, hasSplit);
         }

        private void cbbPatternBackColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbPatternSandBackColor);
        }


         void addDef4Limestone( string sLithoName ,string sID)
        {
            int iHeightPattern = Convert.ToInt16(nUDPatternLimesHeight.Value);
            int iWidthPattern = iHeightPattern*2;
            string sBackColor = cPublicMethodBase.getRGB(cbbPatternLimesBackColor.BackColor);
            cSVGXEPatternCarbonatie.addDef2Ink(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor);
        }

         XElement getDef4Limestone(string sLithoName, string sID)
         {
             int iHeightPattern = Convert.ToInt16(nUDPatternLimesHeight.Value);
            int iWidthPattern = iHeightPattern*2;
             return  cSVGXEPatternCarbonatie.lithoPatternLimesDefs(sLithoName, sID, iWidthPattern, iHeightPattern);
         }

         void addDef4SandStone(string sLithoName, string sID)
         {
             int iHeightPattern = Convert.ToInt16(nUDPatternSandHeight.Value);
             int iWidthPattern = iHeightPattern * 2;
             string sBackColor = cPublicMethodBase.getRGB(cbbPatternSandBackColor.BackColor);
             string sCircleColor = cPublicMethodBase.getRGB(this.cbbInnerColor.BackColor);
             cSVGXEPatternLithoSand.addDef2Ink(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor, sCircleColor, hasSplit);
         }


         void addDef4MudStone(string sLithoName, string sID)
         {
             int iHeightPattern = Convert.ToInt16(this.nUDPatternMudHeight.Value);
             int iWidthPattern = iHeightPattern*2;
             string sBackColor = cPublicMethodBase.getRGB(this.cbbPatternMudBackColor.BackColor);
             cSVGXEPatternMud.addDef2Ink(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor,hasSplit);
         }

         void addDefGravelStone(string sLithoName, string sID)
         {
             int iHeightPattern = Convert.ToInt16(nUDPatternGravelHeight.Value);
             int iWidthPattern = iHeightPattern*2;
             string sBackColor = cPublicMethodBase.getRGB(this.cbbGravelBackcolor.BackColor);
             cSVGXEPatternGravel.addDef2Ink(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor,hasSplit);
         }
        private void btnLimestone_Click(object sender, EventArgs e)
        {
             sLithoName = "石灰岩";
            if (this.tbxPatternNameHuiyan.Text.Trim() != "") sLithoName = tbxPatternNameHuiyan.Text; 
             sID = "201";
             viewPattern(sLithoName, getDef4Limestone(sLithoName, sID));
        }

        private void btnDolomite_Click(object sender, EventArgs e)
        {
             sLithoName = "白云岩";
            if (this.tbxPatternNameHuiyan.Text.Trim() != "") sLithoName = tbxPatternNameHuiyan.Text; 
            sID = "202";
            viewPattern(sLithoName, getDef4Limestone(sLithoName, sID));
        }

        private void btnMud_Click(object sender, EventArgs e)
        {
            sLithoName = "泥岩";
            if (this.tbxPatternNameMud.Text.Trim() != "") sLithoName = this.tbxPatternNameMud.Text;
            sID = "401";
            viewPattern(sLithoName, getDef4MudStone(sLithoName, sID));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sLithoName = "细砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            string sID = "103";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnQuartzSand_Click(object sender, EventArgs e)
        {
            sLithoName = "石英砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "107";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sLithoName = "中砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "102";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnHLSSand_Click(object sender, EventArgs e)
        {
            sLithoName = "海绿石砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "109";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnFeSand_Click(object sender, EventArgs e)
        {
            sLithoName = "铁质砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "108";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void cbbPatternLimesBackColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbPatternLimesBackColor);
        }

        private void btnFenSand_Click(object sender, EventArgs e)
        {
            sLithoName = "粉砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "104";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnZhongxiSand_Click(object sender, EventArgs e)
        {
            sLithoName = "中细砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "105";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnFenXiSand_Click(object sender, EventArgs e)
        {
            sLithoName = "粉细砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "106";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnFSZMud_Click(object sender, EventArgs e)
        {
            sLithoName = "粉砂质泥岩";
            if (this.tbxPatternNameMud.Text.Trim() != "") sLithoName = this.tbxPatternNameMud.Text;
            sID = "402";
            viewPattern(sLithoName, getDef4MudStone(sLithoName, sID));
        }

        private void cbbPatternMudBackColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbPatternMudBackColor);
        }

        private void cbbInnerColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbInnerColor);
        }

        private void btnShale_Click(object sender, EventArgs e)
        {
             sLithoName = "页岩";
            if (tbxPatternNameShale.Text.Trim() != "") sLithoName = tbxPatternNameShale.Text;
            sID = "301";
            viewPattern(sLithoName, getDef4ShaleStone(sLithoName, sID));
        }


        void addDefShaleStone(string sLithoName, string sID)
        {
            int iHeightPattern = Convert.ToInt16(nUDPatternShaleHeight.Value);
            int iWidthPattern = iHeightPattern*2;
            string sBackColor = cPublicMethodBase.getRGB(cbbPatternShaleBackColor.BackColor);
            cSVGXEPatternShale.addDef2Ink(sLithoName,sID, iWidthPattern, iHeightPattern, sBackColor);
        }

        XElement getDef4ShaleStone(string sLithoName, string sID)
        {
            int iHeightPattern = Convert.ToInt16(this.nUDPatternMudHeight.Value);
            int iWidthPattern = iHeightPattern*2;
            string sBackColor = cPublicMethodBase.getRGB(this.cbbPatternMudBackColor.BackColor);
            return cSVGXEPatternShale.lithoPatternShaleDefs(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor);
        }

        private void btnSandShale_Click(object sender, EventArgs e)
        {
            sLithoName = "砂质页岩";
            if (tbxPatternNameShale.Text.Trim() != "") sLithoName = tbxPatternNameShale.Text;
            sID = "302";
            viewPattern(sLithoName, getDef4ShaleStone(sLithoName, sID));
        }

        private void btnSZmud_Click(object sender, EventArgs e)
        {
            string sLithoName = "砂质泥岩";
            if (this.tbxPatternNameMud.Text.Trim() != "") sLithoName = this.tbxPatternNameMud.Text;
            string sID = "403";
            viewPattern(sLithoName, getDef4MudStone(sLithoName, sID));
        }

        private void btnHZmud_Click(object sender, EventArgs e)
        {
            string sLithoName = "灰质泥岩";
            if (this.tbxPatternNameMud.Text.Trim() != "") sLithoName = this.tbxPatternNameMud.Text;
            string sID = "406";
            viewPattern(sLithoName, getDef4MudStone(sLithoName, sID));
        }

        private void cbbGravelBackcolor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbGravelBackcolor);
        }

        private void btnMidGravel_Click(object sender, EventArgs e)
        {
            sLithoName = "中砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID = "503";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }
        private void btnHugeGravel_Click(object sender, EventArgs e)
        {
             sLithoName = "巨砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID="501";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }

        XElement getDef4GravelStone(string sLithoName, string sID)
        {
            int iHeightPattern = Convert.ToInt16(nUDPatternGravelHeight.Value);
             int iWidthPattern = iHeightPattern*2;
            string sBackColor = cPublicMethodBase.getRGB(this.cbbGravelBackcolor.BackColor);
            return cSVGXEPatternGravel.lithoPatternDefsGravel(sLithoName, sID, iWidthPattern, iHeightPattern, sBackColor,hasSplit);
        }

        private void btnCuGravel_Click(object sender, EventArgs e)
        {
           sLithoName = "粗砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID = "502";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }

        private void btnXiGravel_Click(object sender, EventArgs e)
        {
            sLithoName = "细砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID = "504";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }

        private void btnMudGravel_Click(object sender, EventArgs e)
        {
            sLithoName = "泥砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID = "506";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }

        private void btnTriGravel_Click(object sender, EventArgs e)
        {
            sLithoName = "角砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID = "507";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }

        private void btnTuffTriGravel_Click(object sender, EventArgs e)
        {
            sLithoName = "凝灰质角砾岩";
            if (this.tbxPatternNameGravel.Text.Trim() != "") sLithoName = tbxPatternNameGravel.Text;
            sID = "513";
            viewPattern(sLithoName, getDef4GravelStone(sLithoName, sID));
        }

        private void btnTortSand_Click(object sender, EventArgs e)
        {
           sLithoName = "玄武质砂岩";
            if (this.tbxPatternNameSand.Text.Trim() != "") sLithoName = tbxPatternNameSand.Text; 
            sID = "127";
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnGypsumMud_Click(object sender, EventArgs e)
        {
            sLithoName = "石膏质泥岩";
            if (this.tbxPatternNameMud.Text.Trim() != "") sLithoName = this.tbxPatternNameMud.Text;
            sID = "409";
            viewPattern(sLithoName, getDef4MudStone(sLithoName, sID));
        }

        private void btnAsphaltShale_Click(object sender, EventArgs e)
        {
            sLithoName = "沥青质页岩";
            if (tbxPatternNameShale.Text.Trim() != "") sLithoName = tbxPatternNameShale.Text;
            sID = "305";
            viewPattern(sLithoName, getDef4ShaleStone(sLithoName, sID));
        }

        private void btnOoliteLimes_Click(object sender, EventArgs e)
        {
           sLithoName = "鲕粒灰岩";
            if (this.tbxPatternNameHuiyan.Text.Trim() != "") sLithoName = tbxPatternNameHuiyan.Text; 
            sID = "224";
            viewPattern(sLithoName, getDef4Limestone(sLithoName, sID));
          
        }

      private void button3_Click(object sender, EventArgs e)
        {
            string sLithoName = "中砂岩";
            int iWidthPattern = 5;
            int iHeightPattern = 5;
            string sBackColor = cPublicMethodBase.getRGB(cbbPatternSandBackColor.BackColor);

            string filePathSVGMap = Path.Combine(cProjectManager.dirPathMap, sLithoName + ".svg");

            cSVGDocPatternSand cLithoPattern = new cSVGDocPatternSand( 0, 0);
            for (int i = 1; i < 5; i++)
            {
                string dRect = "M" + (50 * i).ToString()+" " + (50 * i).ToString() + "h50 v20 h-50 z";
                XmlElement lithoElement = cLithoPattern.addLithoPatternSand(sLithoName, iWidthPattern, iHeightPattern, sBackColor, 50*i,80*i,30,20);
                cLithoPattern.addgElement2BaseLayer(lithoElement, 0, 0);
            }
            cLithoPattern.makeSVGfile(filePathSVGMap);
            FormWebNavigation formSVGView = new FormWebNavigation(filePathSVGMap);
            formSVGView.Show();
           
        }

            //先保存图片 再填充预览，最后生成配置存到inkscape的系统定义中去
        private void btnPatternView_Click(object sender, EventArgs e)
        {
            SolidBrush backBrush = new SolidBrush(this.cbbPatternSandBackColor.BackColor);
           
            int height =Convert.ToInt16( this.nUDPatternShaleHeight.Value);
            int width = height * 2;
            Bitmap bmp = new Bitmap(width, height);
            SolidBrush brush = new SolidBrush( this.cbbInnerColor.BackColor);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(backBrush, 0, 0, width, height);
                g.FillEllipse(brush, width/2, height/2,3,3);
            }
           
            string fileTempPng=Path.Combine( cProjectManager.dirPathTemp,numfilePathTemp.ToString()+"pattern.png");
            if (File.Exists(fileTempPng)) File.Delete(fileTempPng);
            numfilePathTemp++;
            bmp.Save(fileTempPng, ImageFormat.Png);
            Image myImage = Image.FromFile(fileTempPng);
            TextureBrush myTextureBrush = new TextureBrush(myImage); 

            Graphics gPanel=this.panelPatternView.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, this.panelPatternView.Width, this.panelPatternView.Height);
            gPanel.FillRectangle(myTextureBrush, rect);
            //以上是gdi方式

        }


        private void btn_CalConfig_Click(object sender, EventArgs e)
        {
        
        }

        private void nUDSandRadius_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbPatternShaleBackColor_Click(object sender, EventArgs e)
        {
            cPublicMethodForm.setComboBoxBackColorByColorDialog(cbbPatternShaleBackColor);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            SolidBrush backBrush = new SolidBrush(this.cbbPatternSandBackColor.BackColor);
            int height = Convert.ToInt16(this.nUDPatternShaleHeight.Value);
            int width = height * 2;
            Bitmap bmp = new Bitmap(width, height);
            SolidBrush brush = new SolidBrush(this.cbbInnerColor.BackColor);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(backBrush, 0, 0, width, height);
                g.FillEllipse(brush, width / 2, height / 2, 3, 3);
            }

            string fileTempPng = Path.Combine(cProjectManager.dirPathTemp, numfilePathTemp.ToString() + "pattern.png");
            if (File.Exists(fileTempPng)) File.Delete(fileTempPng);
            numfilePathTemp++;
            bmp.Save(fileTempPng, ImageFormat.Png);
            Image myImage = Image.FromFile(fileTempPng);
            TextureBrush myTextureBrush = new TextureBrush(myImage);

            Graphics gPanel = this.panelPatternView.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, this.panelPatternView.Width, this.panelPatternView.Height);
            gPanel.FillRectangle(myTextureBrush, rect);
        }

        void viewPattern(string sLithoName,XElement def) 
        {
            this.lblPatternName.Text = sLithoName;
            string filepatternTemp = Path.Combine(cProjectManager.dirPathTemp, "patternView.svg");
            if (File.Exists(filepatternTemp)) File.Delete(filepatternTemp);
            cBaseMapSVG svgPattern = new cBaseMapSVG(200, 300, 0, 0);
            XmlElement gRect = svgPattern.svgDoc.CreateElement("rect");
            gRect.SetAttribute("x", "0");
            gRect.SetAttribute("y", "0");
            gRect.SetAttribute("width", webBrowserPatternView.Width.ToString());
            gRect.SetAttribute("height", webBrowserPatternView.Height.ToString());
            string sURL = "url(#" + sLithoName.GetHashCode().ToString().Remove(0, 1) + ")";
            gRect.SetAttribute("fill", sURL);
            gRect.SetAttribute("stroke-width", "0.1");
            gRect.SetAttribute("stroke", "black");
            svgPattern.svgRoot.AppendChild(gRect);
            svgPattern.makeSVGfile(filepatternTemp);

            XDocument xDoc = XDocument.Load(filepatternTemp);
            XElement xroot = xDoc.Root;

            XNamespace xn = "http://www.w3.org/2000/svg";
            XElement textXE = new XElement(xn + "text", new XAttribute("xmlns", "http://www.w3.org/2000/svg"));

            if (xroot != null)
            {
                // bool x=xroot.HasElements("defs");
                XElement xdefs = xroot.Element("{http://www.w3.org/2000/svg}" + "defs");
                if (xdefs != null) xdefs.Add(def);
             
                xDoc.Save(filepatternTemp);
            }
            this.webBrowserPatternView.Navigate(new Uri(filepatternTemp));
        
        }


        private void btn_PatternView_Click(object sender, EventArgs e)
        {
            viewPattern(sLithoName, getDef4SandStone(sLithoName, sID));
        }

        private void btnAdd2Ink_Click(object sender, EventArgs e)
        {
            if(tbcPattern.SelectedTab==tbgPatternSand) addDef4SandStone(sLithoName, sID);
            if (tbcPattern.SelectedTab ==tbgPatternGravel) addDefGravelStone(sLithoName, sID);
            if (tbcPattern.SelectedTab == tbgPatternMud) addDef4MudStone(sLithoName, sID);
            if (tbcPattern.SelectedTab == tbgPatternShale) addDefShaleStone(sLithoName, sID);
            if (tbcPattern.SelectedTab == tbgPatternTSY)  addDef4Limestone(sLithoName, sID);
        }

        private void cbxHasSplitLine_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHasSplitLine.Checked == true) hasSplit = true;
            else hasSplit = false;
        }

    }
}
