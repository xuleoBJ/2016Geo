using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DigRobot;



namespace DOGPlatform
{
    class cMenuStripMain 
    {
        public MenuStrip menuStrip { get; set; }
        public cMenuStripMain(MenuStrip _menustrip)
        {
            this.menuStrip = _menustrip;
        }
        public void setupTsmiConfig()
        {
            ToolStripMenuItem tsmiConfig = new ToolStripMenuItem("配置");
            tsmiConfig.DropDownItems.Add(tsmiDebug);
            ToolStripMenuItem tsmiDataManager = new ToolStripMenuItem("数据管理");
            tsmiConfig.DropDownItems.Add(tsmiDataManager);
            tsmiDataManager.Click += new System.EventHandler(tsmiDataManager_Click);
            menuStrip.Items.Add(tsmiConfig);
        }
        public void tsmiDataManager_Click(object sender, EventArgs e) 
        {
            FormWellManager formDI = new FormWellManager();
            formDI.ShowDialog();
        }
      
        public ToolStripMenuItem tsmiDebug = new ToolStripMenuItem("配置调试");


       ToolStripMenuItem tsmiLithoPattern = new ToolStripMenuItem("岩相图元");
        private void tsmiLithoPattern_Click(object sender, EventArgs e)
        {
            FormPatternElement fpe = new FormPatternElement();
            fpe.Show();
        }

        public void setupTsmiDataAnalysis()
        {
             ToolStripMenuItem tsmiDataAnalysis = new ToolStripMenuItem("数据挖掘");
             ToolStripMenuItem tsmiPoleMap = new ToolStripMenuItem("极点图分析");
             tsmiPoleMap.Click += new System.EventHandler(tsmiPoleMap_Click);
             tsmiDataAnalysis.DropDownItems.Add(tsmiPoleMap);
             ToolStripMenuItem tsmiMapPieAna = new ToolStripMenuItem("井点图分析");
             tsmiMapPieAna.Click += new System.EventHandler(tsmiMapPieAna_Click);
             tsmiDataAnalysis.DropDownItems.Add(tsmiMapPieAna);
             menuStrip.Items.Add(tsmiDataAnalysis);
        }

         public void tsmiMapPieAna_Click(object sender, EventArgs e)
        {
            FormDataAnalysis formRoseMap = new FormDataAnalysis();
            formRoseMap.ShowDialog();
        }
           
       
        public void tsmiPoleMap_Click(object sender, EventArgs e)
        {
            FormDataAnalysis formRoseMap = new FormDataAnalysis();
            formRoseMap.ShowDialog();
        }
        public void setupTsmiGeoStatics()
        {
            ToolStripMenuItem tsmiGeoStatics = new ToolStripMenuItem("地质统计");
            menuStrip.Items.Add(tsmiGeoStatics);
        }
        public void setupTsmiTools()
        {
            ToolStripMenuItem tsmiTools = new ToolStripMenuItem("工具");
            tsmiTools.DropDownItems.Add(tsmiLithoPattern);
            tsmiLithoPattern.Click += new System.EventHandler(tsmiLithoPattern_Click);
            tsmiTools.DropDownItems.Add(tsmiDigger);
            tsmiDigger.Click += new System.EventHandler(tsmiDigger_Click);
            tsmiTools.DropDownItems.Add(tsmiCalArea);
            tsmiCalArea.Click += new System.EventHandler(tsmiCalArea_Click);
           

            tsmiTools.DropDownItems.Add(tsmiDataDeal);
            tsmiDataDeal.Click += new System.EventHandler(tsmiDataDeal_Click);

            tsmiTools.DropDownItems.Add(tsmiStrata);
            tsmiStrata.Click += new System.EventHandler(tsmiStrata_Click);

            tsmiTools.DropDownItems.Add(tsmiErrLog);
            tsmiErrLog.Click += new System.EventHandler(tsmiErrLog_Click);

            menuStrip.Items.Add(tsmiTools);
        }

        public ToolStripMenuItem tsmiStrata = new ToolStripMenuItem("颜色插件配置");
        public void tsmiStrata_Click(object sender, EventArgs e)
        {
            cInkExtensionColor.configStrataColorExtension();
            cInkExtensionColor.configReserverColorExtension();
            cInkExtensionColor.configFloodRegionColorExtension();
            MessageBox.Show("插件颜色配置完成。"); 
        }

        public ToolStripMenuItem tsmiErrLog = new ToolStripMenuItem("查看信息");
        public void tsmiErrLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", cProjectManager.filePathRunInfor);
        }

        public ToolStripMenuItem tsmiDigger = new ToolStripMenuItem("图像工具");
        public void tsmiDigger_Click(object sender, EventArgs e)
        {
            FormDigRobot _formDig = new FormDigRobot();
            _formDig.Show();
        }

        public ToolStripMenuItem tsmiCalArea = new ToolStripMenuItem("面积周长计算");
        public void tsmiCalArea_Click(object sender, EventArgs e)
        {
            FormCalArea _form= new FormCalArea();
            _form.Show();
        }

        public void setupTsmiWellGroup()
        {
            ToolStripMenuItem tsmiTools = new ToolStripMenuItem("井组分析");
            tsmiTools.DropDownItems.Add(tsmiWellGroupFence);
            tsmiWellGroupFence.Click += new System.EventHandler(tsmiWellGroupFence_Click);
            menuStrip.Items.Add(tsmiTools);
        }

        public ToolStripMenuItem tsmiWellGroupFence = new ToolStripMenuItem("井组栅状图");
        public void tsmiWellGroupFence_Click(object sender, EventArgs e)
        {
            FormSectionGroup formFD = new FormSectionGroup();
            formFD.Show();
        }
        public ToolStripMenuItem tsmiDataDeal = new ToolStripMenuItem("数据处理工具");
        public void tsmiDataDeal_Click(object sender, EventArgs e)
        {
            FormDataTableDeal _form = new FormDataTableDeal();
            _form.Show();
        }

        public void setupTsmiHelps()
        {
            ToolStripMenuItem tsmiHelps = new ToolStripMenuItem("帮助");
            ToolStripMenuItem tsmiVersion = new ToolStripMenuItem("版本");
            tsmiHelps.DropDownItems.Add(tsmiVersion);
            tsmiVersion.Click += new System.EventHandler(tsmiVersion_Click);
            tsmiHelps.DropDownItems.Add(tsmiHelp);
            menuStrip.Items.Add(tsmiHelps);
        }
        
        public void tsmiVersion_Click(object sender, EventArgs e)
        {
            FormCopyRight formCP = new FormCopyRight();
            formCP.ShowDialog();
        }
        public ToolStripMenuItem tsmiHelp = new ToolStripMenuItem("帮助");
      

    }
}
