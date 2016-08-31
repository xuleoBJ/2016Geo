using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;

namespace DOGPlatform
{
    class cProjectData
    {
        public static List<string> ltStrProjectJH = new List<string>();
        public static List<string> ltStrProjectXCM = new List<string>();
        public static List<string> ltStrProjectYM = new List<string>();
        public static List<string> ltStrProjectGlobeLog = new List<string>();
        
        public static string splitMark ="~#";
        public static string projectUnit = typeUnit.Metric.ToString();

        //工程井信息，非常重要，包含工程中井的所有经常检索的信息，比如wellPath,wellLogHead,仍需要修改
        public static List<ItemWell> ltProjectWell = new List<ItemWell>();

        public static cGridPara projectMesh = new cGridPara();
        public static double dfMapScale = 0.0;
        public static double dfMapXrealRefer = 0.0;
        public static double dfMapYrealRefer = 9000.0;

        public static string sAllLayer ="AllLayer";
        public static string sErrLineInfor = "";
        public static int INVALID = -999;
        public static string sTempTrackData = "";
        //记录iSectionCss是否被修改过，修改过为1。
        public static int iSectionCSSModified = 0;

        public static int setDefaultPageHeight()
        {
            return (int)ltProjectWell.Select(p => p.fWellBase).ToList().Max() + 100;
        }

        public static void clearProjectData()
        {
            ltStrProjectJH.Clear();
            ltStrProjectGlobeLog.Clear();
            ltStrProjectXCM.Clear();
            ltStrProjectYM.Clear();
            ltProjectWell.Clear();
            dfMapScale = 0.1;
            dfMapXrealRefer = 0.0;
            dfMapYrealRefer = 9000.0;

            sErrLineInfor = "";
            INVALID = -999;
            sTempTrackData = ""; 

        }

       
        public static void loadProjectData()
        {
            //ltStrProjectJH应用井名列表赋值
            try
            {   
                //从工程文件中，获取基本定位点信息 refX,refY,scale
                cfilePathProject.getProjectRefPointNode();
                getProjectJHFromXML();
                if (cProjectData.ltStrProjectJH.Count == 0)
                {
                    foreach (string _sJH in cIOinputWellHead.getLtStrJH()) ltStrProjectJH.Add(_sJH);
                    ltStrProjectJH.Sort();
                    setProjectWellsInfor();
                }
                cfilePathProject.getProjectUnitNode();
                getProjectLogSeriersFromXML();
                if (cProjectData.ltStrProjectGlobeLog.Count == 0) setProjectGlobalLogSeriers();
                getProjectXCMFromXML();
                getProjectYMFromXML();
                if (cProjectData.ltStrProjectYM.Count == 0) setProjectYM(cPublicMethodBase.getYMLastMonth(DateTime.Now.ToString("yyyyMM")));

                if (!Directory.Exists(cProjectManager.dirPathHis)) Directory.CreateDirectory(cProjectManager.dirPathHis);

                cProjectManager.initialCodeList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
       
        public static void getProjectJHFromXML()
        {
            cProjectData.ltStrProjectJH.Clear();
            cfilePathProject.getProjectJHFromNode();
            cProjectData.ltStrProjectJH.Sort();
        }
        public static void setProjectJH2XML()
        {
            cfilePathProject.setProjectJHNode();
        }

        public static void setProjectXCM2XML(string sFCFA)
        {
            cfilePathProject.setProjectLayerSeriersNode(sFCFA);
        }
        public static void getProjectXCMFromXML()
        {
            cProjectData.ltStrProjectXCM.Clear();
            cfilePathProject.getProjectLayerSeriersFromNode();
        }
        
      
        public static void setProjectYM(string yyyyMM)
        {
            setProjectYM(yyyyMM, DateTime.Now.ToString("yyyyMM"));
        }

        public static void setProjectYM(string minYM,string maxYM)
        {
            //ltStrProjectYM 生产年月列表赋值
            cProjectData.ltStrProjectYM.Clear();

            int iYMmin = int.Parse(minYM);
            int iYMmax = int.Parse(cPublicMethodBase.getYMLastMonth(maxYM)) ;

            while (iYMmin <= iYMmax)
            {
                if (iYMmin % 100 < 12)
                {
                    iYMmin = iYMmin + 1;
                }
                else
                {
                    iYMmin = iYMmin + 89;
                }
                cProjectData.ltStrProjectYM.Add(iYMmin.ToString());
            }

        }
     
        public static void setProjectWellsInfor()
        {
            ltProjectWell.Clear();
            foreach (string _sJH in ltStrProjectJH) 
            {
                ltProjectWell.Add(new ItemWell(_sJH));
            }
        }
        public static void getProjectLogSeriersFromXML()
        {
            cProjectData.ltStrProjectGlobeLog.Clear();
            cfilePathProject.getProjectLogSeriersFromNode();
        }

        public static void getProjectYMFromXML()
        {
            cProjectData.ltStrProjectYM.Clear();
            cfilePathProject.getProjectYMFromNode();
        }
       
         public static void setProjectGlobalLogSeriers()
        {
           ltStrProjectGlobeLog.Clear();
           foreach (string _sJH in ltStrProjectJH)
           {
               string _wellDir = Path.Combine(cProjectManager.dirPathWellDir, _sJH);

               foreach (string _item in Directory.GetFiles(_wellDir, "*" + cProjectManager.fileExtensionWellLog))
               {
                   string _log = Path.GetFileNameWithoutExtension(_item);
                   if (ltStrProjectGlobeLog.IndexOf(_log) < 0) ltStrProjectGlobeLog.Add(_log);
               }  
           }
        }

    }
}
