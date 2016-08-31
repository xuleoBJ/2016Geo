using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DOGPlatform
{
    class cProject
    {
        public static string XMLproject = System.Environment.GetEnvironmentVariable("TEMP");
        public static string dirPathUserData = XMLproject;
        public static string dirPathUsedProjectData = XMLproject;
        public static string dirPathMap = XMLproject;
        public static string dirPathLog = XMLproject;
        public static string dirPathTemp = XMLproject;
        public static string dirPathWellDir = XMLproject;
        public static string dirPathTemplate = XMLproject;


        public static string filePathInputWellhead = dirPathUserData + "$wellHead#.txt";
        public static string filePathInputWellPath = dirPathUserData + "$wellPath#.txt";
        public static string filePathInputLayerSeriers = dirPathUserData + "$layerSerier#.txt";
        public static string filePathInputLayerDepth = dirPathUserData + "$layerDepth#.txt";
        public static string filePathInputJSJL = dirPathUserData + "$interpretation#.txt";
        public static string filePathFaultLines = dirPathUserData + "$faultLines#.txt";
        public static string filePathInputPerforation = dirPathUserData + "$perforationInfor#.txt";
        public static string filePathInputProductWellData = dirPathUserData + "$productionWellData#.txt";
        public static string filePathInputInjectWellData = dirPathUserData + "$injectionWellData#.txt";
        public static string filePathInputInjectionProfile = dirPathUserData + "$injectionProfile#.txt";
        public static string filePathErrInfor = dirPathUserData + "#err.txt";
        public static string filePathFaultPointsInWell = dirPathUserData + "$faultPointsInWell#.txt";


        public static string filePathLogHeadDicProject = "";
        public static string filePathLogHeadDicGlobe = "";

        public static string filePathLayerDataDic = "";
        public static string filePathPerforationDic = "";
        public static string filePathWellTypeDic = "";
        public static string filePathLayerSplitFactorDic = "";
        public static string dirPathWellProductionDic = "";
        public static string dirPathWellInjectionDic = "";
        public static string filePathWellPathDic = "";
        public static string filePathInterLayerHeterogeneity = "";
        public static string filePathInnerLayerHeterogeneity = "";
        public static string filePathWellNavigation = "";

        public static string XMLWellNavigation = "";
        public static string XMLConfigProject = "";
        public static string XMLConfigLayerMap = "";
        public static string XMLConfigSection = "";
        public static string XMLConfigFenceDiagram = "";
        public static string XMLConfigProductMap = "";
        public static string XMLConfigStratumSection = "";


        public static void updateProjectDirection()
        {
            cProject.dirPathUserData = cProject.XMLproject.Substring(0, cProject.XMLproject.LastIndexOf("\\") + 1) + "$UserData#\\";

            cProject.dirPathUsedProjectData = cProject.dirPathUserData.Replace("$UserData#", "$UsedProjectData$");
            cProject.dirPathMap = cProject.dirPathUserData.Replace("$UserData#", "$Map$");
            cProject.dirPathWellDir = cProject.dirPathUserData.Replace("$UserData#", "$Well$");
            cProject.dirPathLog = cProject.dirPathUserData.Replace("$UserData#", "$Log$");
            cProject.dirPathTemp = cProject.dirPathUserData.Replace("$UserData#", "$Temp$");
            cProject.dirPathTemplate = cProject.dirPathUserData.Replace("$UserData#", "$Template$");

            cProject.filePathInputWellhead = dirPathUserData + "$wellHead#.txt";
            cProject.filePathInputWellPath = dirPathUserData + "$wellPath#.txt";
            cProject.filePathInputJSJL = dirPathUserData + "$interpretation#.txt";
            cProject.filePathInputPerforation = dirPathUserData + "$perforationInfor#.txt";
            cProject.filePathInputLayerSeriers = dirPathUserData + "$layerSerier#.txt";
            cProject.filePathInputLayerDepth = dirPathUserData + "$layerDepth#.txt";
            cProject.filePathFaultLines = dirPathUserData + "$faultLines#.txt";
            cProject.filePathFaultPointsInWell = dirPathUserData + "$faultPointsInWell#.txt";
            cProject.filePathInputProductWellData = dirPathUserData + "$productionWellData#.txt";
            cProject.filePathInputInjectWellData = dirPathUserData + "$injectionWellData#.txt";
            cProject.filePathInputInjectionProfile = dirPathUserData + "$injectionProfile#.txt";
            cProject.filePathLayerSplitFactorDic = dirPathUsedProjectData + "$LayerSplitFactorDic$.txt";

            cProject.filePathWellNavigation = dirPathUserData + "$WellNavigation#.txt";

            cProject.filePathErrInfor = dirPathUserData + "#err.txt";

            cProject.filePathLogHeadDicProject = dirPathUserData + "$LogHeadProjectDic$.txt";
            cProject.filePathLogHeadDicGlobe = dirPathUsedProjectData + "$LogHeadGlobeDic$.txt";

            cProject.filePathLayerDataDic = dirPathUsedProjectData + "$LayerDataDic$.txt";
            cProject.filePathWellTypeDic = dirPathUsedProjectData + "$WellTypeDic$.txt";
            cProject.filePathPerforationDic = dirPathUsedProjectData + "$PerforationDic$.txt";
            cProject.filePathWellPathDic = dirPathUsedProjectData + "$WellPathDic$.txt";

            cProject.dirPathWellProductionDic = dirPathUsedProjectData + "$WellProductionDic$";
            cProject.dirPathWellInjectionDic = dirPathUsedProjectData + "$WellInjectionDic$";

            cProject.filePathInterLayerHeterogeneity = dirPathUsedProjectData + "$InterLayerHeterogeneity$.txt";
            cProject.filePathInnerLayerHeterogeneity = dirPathUsedProjectData + "$InnerLayerHeterogeneity$.txt";

            cProject.XMLWellNavigation = cProject.dirPathUsedProjectData + "$WellNavigation#.XML";
            cProject.XMLConfigProject = cProject.dirPathUsedProjectData + "$ConfigProject#.XML";
            cProject.XMLConfigLayerMap = cProject.dirPathTemp + "$ConfigLayerMap#.XML";
            cProject.XMLConfigSection = cProject.dirPathTemp + "$ConfigSection#.XML";
            cProject.XMLConfigFenceDiagram = cProject.dirPathTemp + "$ConfigFenceDiagram#.XML";
            cProject.XMLConfigProductMap = cProject.dirPathTemp + "$ConfigProductMap#.XML";
            cProject.XMLConfigStratumSection = cProject.dirPathTemp + "$ConfigStratumSection#.XML";
        }
        public static List<string> sListProjectJH = new List<string>();
        public static List<string> sListProjectXJH = new List<string>();
        public static List<string> sListProjectXCM = new List<string>();
        public static List<string> sListProjectYYYYMM = new List<string>();
        public static List<string> sListLogSeriers = new List<string>();
        public static List<ItemLogHeadInfor> itemListProjectLogHead = new List<ItemLogHeadInfor>();


        public static float fMapScale = 0.1F;
        public static double dfMapXrealRefer = 0.0;
        public static double dfMapYrealRefer = 9000.0;
         

        public static List<string> sListWorkFlow = new List<string>();
        public static string sErrLineInfor = "";

        public static int INVALID = -999;
        public static float fMaxValid_Pore = 40;
        public static float fMinValid_Pore = 0;
        public static float fMaxValid_So = 40;
        public static string sTrackData = "";
  

        public bool creatProject()
        {
            SaveFileDialog sfdProjectPath = new SaveFileDialog();
            //设置文件类型 
            sfdProjectPath.Title = " 请输入保存数据的位置：";
            sfdProjectPath.Filter = "xl文件|*.xl";
            //设置默认文件类型显示顺序 
            sfdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfdProjectPath.RestoreDirectory = true;
            //创建工程数据文件夹 
            if (sfdProjectPath.ShowDialog() == DialogResult.OK)
            {
                string mFilePath = sfdProjectPath.FileName;
                cProject.XMLproject = mFilePath;
                cXMLProject.creatProjectInforXML(mFilePath);
                string dirPathProjectDataSource = mFilePath.Replace(Path.GetFileName(mFilePath), "$UserData#");

                if (Directory.Exists(dirPathProjectDataSource))
                {
                    Directory.Delete(dirPathProjectDataSource, true);
                }
                System.IO.Directory.CreateDirectory(dirPathProjectDataSource);

                cProject.updateProjectDirection();
                List<string> sListDataSourceFiles = new List<string>();
                sListDataSourceFiles.Add(cProject.filePathInputWellhead);
                sListDataSourceFiles.Add(cProject.filePathInputWellPath);
                sListDataSourceFiles.Add(cProject.filePathLogHeadDicProject);
                sListDataSourceFiles.Add(cProject.filePathInputJSJL);
                sListDataSourceFiles.Add(cProject.filePathInputPerforation);
                sListDataSourceFiles.Add(cProject.filePathInputLayerSeriers);
                sListDataSourceFiles.Add(cProject.filePathInputLayerDepth);
                sListDataSourceFiles.Add(cProject.filePathInputProductWellData);
                sListDataSourceFiles.Add(cProject.filePathInputInjectWellData);
                sListDataSourceFiles.Add(cProject.filePathFaultLines);
                sListDataSourceFiles.Add(cProject.filePathFaultPointsInWell);
                sListDataSourceFiles.Add(cProject.filePathWellNavigation);
                sListDataSourceFiles.Add(cProject.filePathErrInfor);

                foreach (string sItem in sListDataSourceFiles)
                {
                    FileStream fs = new FileStream(sItem, FileMode.Create);
                    fs.Close();
                }

                string dirPathProjectUsedData = mFilePath.Substring(0, mFilePath.LastIndexOf("\\") + 1) + "$UsedProjectData$";
                if (Directory.Exists(dirPathProjectUsedData))
                {
                    Directory.Delete(dirPathProjectUsedData, true);
                }
                System.IO.Directory.CreateDirectory(dirPathProjectUsedData);

                string dirPathAchievementSource = mFilePath.Substring(0, mFilePath.LastIndexOf("\\") + 1) + "$Map$";
                if (Directory.Exists(dirPathAchievementSource))
                {
                    Directory.Delete(dirPathAchievementSource, true);
                }
                System.IO.Directory.CreateDirectory(dirPathAchievementSource);

                string dirPathTempFile = mFilePath.Substring(0, mFilePath.LastIndexOf("\\") + 1) + "$Temp$";
                if (!Directory.Exists(dirPathTempFile))
                {
                    System.IO.Directory.CreateDirectory(dirPathTempFile);
                }

                cFileOperateDicLogHeadGlobe.generateGlobeDicLog();
                string dirPathLog = mFilePath.Substring(0, mFilePath.LastIndexOf("\\") + 1) + "$Log$";
                if (!Directory.Exists(dirPathLog))
                {
                    System.IO.Directory.CreateDirectory(dirPathLog);
                }

                string dirPathTemplate = mFilePath.Substring(0, mFilePath.LastIndexOf("\\") + 1) + "$Template$";
                if (!Directory.Exists(dirPathTemplate))
                {
                    System.IO.Directory.CreateDirectory(dirPathTemplate);
                }


                cProject.updateProjectDirection();
                cProject.getProjectData();

                MessageBox.Show("项目建立。", "提示");
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool openExistProject()
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开项目：";
            ofdProjectPath.Filter = "xl文件|*.xl|所有文件|*.*\\";

            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            //创建工程数据文件夹 
            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                cProject.XMLproject = ofdProjectPath.FileName.ToString();
                cProject.updateProjectDirection();
                cProject.getProjectData();
                return true;
            }
            else
            {

                return false;
            }

        }
        public string saveProject()
        {
            MessageBox.Show("保存工程，把所有的主要是保存工作流，记录下工作流日志，全保存执行一下");
            return cProject.XMLproject;
        }

        public static void setProjectData()
        {
            //sListProjectJH应用井名列表赋值
            try
            {
                setProjectJH();
                setProjectXJH();
                setProjectLogSeriers();
                setProjectXCM();
                setProjectYM();
                setProjectLogHeadDic();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
  
        public static void getProjectData()
        {
            //sListProjectJH应用井名列表赋值
            try
            {
                getProjectJH();
                getProjectXJH();
                getProjectLogSeriers();
                getProjectLogHeadDic();
                getProjectXCM();
                getProjectYM();
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public static void setProjectLogHeadDic()
        {
            MessageBox.Show("setProjectLogHeadDic");
        }
        public static void getProjectLogHeadDic()
        {
            cFileOperateDicLogHeadProject fileProjectLogHead = new cFileOperateDicLogHeadProject();
            itemListProjectLogHead = fileProjectLogHead.itemsProjectLogHead;
        }
        public static void getProjectJH()
        {
            cProject.sListProjectJH.Clear();
            XDocument projectXML = XDocument.Load(cProject.XMLproject);
            try
            {
                XElement projectJH = projectXML.Element("Project").Element("ProjectJH");
                if (projectJH.Value != "")
                {
                    cProject.sListProjectJH = projectJH.Value.Split().ToList();
                }
                else
                {
                    saveXMLProjectJH();
                }
                cProject.sListProjectJH.Sort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void setProjectJH()
        {
            cProject.sListProjectJH.Clear();
            using (StreamReader sr = new StreamReader(cProject.filePathInputWellhead, System.Text.Encoding.Default))
            {

                int lineindex = 0;
                String line;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    lineindex++;
                    cProject.sListProjectJH.Add(line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                }
            }
            cProject.sListProjectJH.Sort();
            saveXMLProjectJH();
        }
        public static void saveXMLProjectJH()
        {
            XDocument projectXML = XDocument.Load(cProject.XMLproject);
            try
            {
                XElement projectJH = projectXML.Element("Project").Element("ProjectJH");
                projectJH.Value = string.Join("\t", cProject.sListProjectJH);
                //保存对xml的更改操作
                projectXML.Save(cProject.XMLproject);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void getProjectXCM()
        {
            cProject.sListProjectXCM.Clear();
            //sListProjectXCM小层名列表赋值
            using (StreamReader sr = new StreamReader(cProject.filePathInputLayerSeriers, System.Text.Encoding.Default))
            {
                int lineindex = 0;
                String line;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    lineindex++;
                    cProject.sListProjectXCM.Add(line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                }
            }

        }
        public static void setProjectXCM()
        {
           
        }
        public static void setProjectXJH()
        {
            cProject.sListProjectXJH.Clear();
            cProject.sListProjectXJH = cFileOperateInputWellPath.get_sListXJHfromWellPathInput();
            saveXMLProjectXJH();
        }
        public static void saveXMLProjectXJH()
        {
            XDocument projectXML = XDocument.Load(cProject.XMLproject);
            try
            {

                //将获得的节点集合中的每一个节点依次从它相应的父节点中删除
                XElement projectXJH = projectXML.Element("Project").Element("ProjectXJH");
                projectXJH.Value = string.Join("\t", cProject.sListProjectXJH);
                //保存对xml的更改操作
                projectXML.Save(cProject.XMLproject);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }
        public static List<string> getProjectXJH()
        {
            List<string> sListXJH = new List<string>();
            XDocument projectXML = XDocument.Load(cProject.XMLproject);
            try
            {

                XElement projectXJH = projectXML.Element("Project").Element("ProjectXJH");
                if (projectXJH.Value != "")
                {
                    cProject.sListProjectXJH = projectXJH.Value.Split().ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return sListXJH;

        }

        public static void getProjectYM()
        {
         
        }
        public static void setProjectYM()
        {
            //sListProjectYYYYMM 生产年月列表赋值
            cProject.sListProjectYYYYMM.Clear();
            List<string> sListTemp = new List<string>();
            using (StreamReader sr = new StreamReader(cProject.filePathInputPerforation, System.Text.Encoding.Default))
            {

                int lineindex = 0;
                String line;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    lineindex++;
                    sListTemp.Add(line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }
            }
            using (StreamReader sr = new StreamReader(cProject.filePathInputProductWellData, System.Text.Encoding.Default))
            {

                int lineindex = 0;
                String line;
                while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                {
                    lineindex++;
                    sListTemp.Add(line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                }
            }
            if (sListTemp.Count > 0)
            {
                int iYMmin = int.Parse(sListTemp.Min());
                int iYMmax = int.Parse(sListTemp.Max());

                while (iYMmin < iYMmax)
                {
                    if (iYMmin % 100 < 12)
                    {
                        iYMmin = iYMmin + 1;
                    }
                    else
                    {
                        iYMmin = iYMmin + 89;
                    }
                    cProject.sListProjectYYYYMM.Add(iYMmin.ToString());

                }
            }
        }

        public static void getProjectLogSeriers()
        {
            cProject.sListLogSeriers.Clear();
            cFileOperateDicLogHeadProject dicFile = new cFileOperateDicLogHeadProject();
            sListLogSeriers = dicFile.getLogNameList() ;
        }
        public static void setProjectLogSeriers()
        {

        }
        public static void setProjectJHMatchLog()
        {
            string filenameWrited = cProject.dirPathUsedProjectData + "Well_LogName.txt";
            StreamWriter sw = new StreamWriter(filenameWrited, false, Encoding.UTF8);
            string sWrited = "";
            try
            {
                string[] fileLogList = System.IO.Directory.GetFileSystemEntries(cProject.dirPathLog);
                foreach (string filePathLog in fileLogList)
                {
                    List<string> sListLogNames = new List<string>();
                    foreach (string sItem in cFileOperateInputLog.getLogSerierNamesFromTXTLog(filePathLog))
                    {
                        sListLogNames.Add(sItem);
                    }
                    sWrited += Path.GetFileName(filePathLog).Replace("_$#log", "") + "\t" + string.Join("\t", sListLogNames.ToArray()) + "\r\n";
                }
                sw.Write(sWrited);
                sw.Close();
            }
            catch(Exception e1)
            {
            
            }

        }
    }
}
