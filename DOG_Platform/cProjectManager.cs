using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DOGPlatform.XML;
using System.Text.RegularExpressions;

namespace DOGPlatform
{
    class cProjectManager
    {
        public static string dirProject = Path.GetTempPath();
        public static string dirPathUserData = dirProject;
        public static string dirPathUsedProjectData = dirProject;
        public static string dirPathMap = dirProject;
        public static string dirPathLog = dirProject;
        public static string dirPathTemp = dirProject;
        public static string dirPathWellDir = dirProject;
        public static string dirPathLayerDir = dirProject;
        public static string dirPathTemplate = dirProject;
        public static string dirPathHis = dirProject;

        public static string filePathInkscape = @"C:\Program Files\Inkscape\inkscape.exe";                            
        public static string filePahtsvgPattern = @"C:\Program Files\\Inkscape\share\patterns\patterns.svg";
        public static string dirPahtInkExtension = @"C:\Program Files\Inkscape\share\extensions";

        public static List<string> ltStrMapSunit = new List<string> { typeUnit.Metric.ToString() , typeUnit.Field.ToString()};
        public static List<string> ltStrRulerType = new List<string> { "测深(md)", "垂深(TVD)" };
        public static List<string> ltStrMapMetricScale=new List<string>{"100","200","500","1000","2000","5000","10000","20000","50000","100000"};
        public static List<string> ltStrMapFieldScale = new List<string> { "250", "500", "1000", "2000", "5000", "10000", "20000", "50000", "100000"};

        public static List<string> ltStrTrackTypeIntervalProperty = new List<string> { TypeTrack.测井解释.ToString(), TypeTrack.含油级别.ToString(), TypeTrack.沉积旋回.ToString(), TypeTrack.描述.ToString(), TypeTrack.管柱.ToString() };
        
        public static string dirTemplateSysName = "templateSys";

        public static string filePathInputWellhead = Path.Combine(dirPathUserData, "$wellHead#.txt");

        public static string filePathRunInfor = Path.Combine(dirPathUserData, "#Infor.txt");
        public static string filePathVoi = Path.Combine(dirPathUsedProjectData, "Voi");

        public static string fileNameGE = "GE";
        public static string fileNameInputLayerDepth = "$inputLayerDepth#.txt";
        public static string fileNameInputJSJL = "$inputJSJL#.txt";
        public static string fileNameInputWellPath = "$inputWellPath#.txt";
        public static string fileNameInputWellPerforation = "$inputWellPeforation#.txt";
        public static string fileNameInputWellProfile = "$inputWellProfile#.txt";
        public static string fileNameInputWellLog = "$inputWellLog#";
        public static string fileNameInputWellProduct = "$inputWellProduct#";
        public static string fileNameInputWellInject = "$inputWellInject#";

        public static string fileNameInputFaults = "$inputFaults#";


        public static string fileNameWellPerforation = "#perforation#";
        public static string fileNameWellPath = "#wellPath#";
        public static string fileNameWellJSJL = "#JSJL#";
        public static string fileNameWellLayerDepth = "#layerDepth#";
        public static string fileNameWellProfile = "#injectProfile#";
        public static string fileExtensionWellLog = ".log";
        public static string fileExtensionDynamic = ".dym";
        
        public static string fileExtensionTemplate = ".xtl";
        public static string fileExtensionSectionGeo = ".xgl";
        public static string fileExtensionSectionFence = ".xfl";
        public static string fileExtensionSectionWell = ".xwl";
        public static string fileExtensionLayerMap = ".xml";

        public static string fileExtensionConnect = ".con";

        public static string filePathLogHeadDicProject = "";
        public static string filePathLayerDataDic = "";
        public static string filePathPerforationDic = "";
        public static string filePathLayerSplitFactorDic = "$LayerSplitFactorDic$.txt";
        public static string filePathInterLayerHeterogeneity = "";
        public static string filePathInnerLayerHeterogeneity = "";
        public static string filePathReserver =  "储量.txt";

        public static string filePathProject = "";
        public static string filePathLayerCss = "";
        public static string xmlConfigSection = "";
        public static string xmlConfigFenceDiagram = "";
        public static string xmlConfigProductMap = "";
        public static string xmlSectionCSS = "";

        public static List<ItemCode> ltCodeItem = new List<ItemCode>();
        public static Dictionary<string, string> dicColor = new Dictionary<string, string>();
        public static void initialCodeList()
        {
            dicColor.Clear();
            string filePathColor = Path.Combine(cProjectManager.dirPathUserData, "colorCode.txt");
            if (!File.Exists(filePathColor))
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code", "colorCode.txt"), filePathColor);
            if (File.Exists(filePathColor))
            {
                using (StreamReader sr = new StreamReader(filePathColor, System.Text.Encoding.UTF8))
                {
                    String line;
                    int _indexLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (split.Length >= 2) dicColor.Add(split[0],split[1]);
                    }
                }//end using 
            }//end if 

            string filePath = Path.Combine(cProjectManager.dirPathUserData, "ItemCode.txt");
            if (!File.Exists(filePath))
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code", "ItemCode.txt"), filePath); 
                if (File.Exists(filePath))
                {
                    ltCodeItem.Clear();
                    using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
                    {
                        String line;
                        int _indexLine = 0;
                        while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                        {
                            _indexLine++;
                            string[] split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (split.Length > 5)
                            {
                                ItemCode item = new ItemCode();
                                item.codeType = split[0];
                                item.chineseName = split[1];
                                item.sCode = split[2];
                                item.fileName = split[3];
                                item.scale =float.Parse(split[4])*0.01;
                                item.englishName = split[5];
                                ltCodeItem.Add(item);
                            }
                        }
                    }//end using 
                }//end if 
        }
        public static void updateProjectDirection(string openXMLFile)
        {
            cProjectManager.filePathProject = openXMLFile;
            cProjectManager.dirProject = Path.GetDirectoryName(openXMLFile);
           dirPathUserData =Path.Combine(dirProject, "$UserData#");
           dirPathUsedProjectData =Path.Combine( dirProject , "$UsedProjectData$");
           dirPathMap =Path.Combine (dirProject , "$Map$");
           dirPathWellDir = Path.Combine(dirProject, "$Well$");
           dirPathLayerDir = Path.Combine(dirProject, "$Layer$");
           dirPathTemp = Path.Combine(dirProject, "$Temp$");
           dirPathTemplate = Path.Combine(dirProject, "$Template$");
           dirPathHis = Path.Combine(dirProject, "$History$");

           filePathInputWellhead =Path.Combine(dirPathUserData ,  "$wellHead#.txt");

           filePathRunInfor = Path.Combine(dirPathUserData, "#Infor.txt");
           filePathVoi = Path.Combine(cProjectManager.dirPathUsedProjectData, "Voi");

           filePathLayerDataDic = Path.Combine(dirPathUsedProjectData, "$LayerDataDic$.txt");
           filePathLayerSplitFactorDic = Path.Combine(dirPathUsedProjectData, "$LayerSplitFactorDic$.txt");
           filePathInterLayerHeterogeneity = Path.Combine(dirPathUsedProjectData, "垂向非均质.txt");
           filePathInnerLayerHeterogeneity = Path.Combine(dirPathUsedProjectData, "层内非均质.txt");
           filePathReserver = Path.Combine(cProjectManager.dirPathUsedProjectData, "储量.txt");
           
 
            filePathLayerCss = Path.Combine(dirPathTemplate, "$ConfigLayerMap#.XML");
            xmlConfigSection = Path.Combine(dirPathTemplate, "$ConfigSection#.XML");
            xmlConfigFenceDiagram = Path.Combine(dirPathTemplate, "$ConfigFenceDiagram#.XML");
            xmlConfigProductMap = Path.Combine(dirPathTemplate, "$ConfigProductMap#.XML");
            xmlSectionCSS = Path.Combine(dirPathTemplate, "$SectionCss#.XML");
        }
      
        public  static bool creatProject()
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
                string newProjectFilePath = sfdProjectPath.FileName;
           
                cfilePathProject.creatProjectInforXML(newProjectFilePath);
                cProjectManager.updateProjectDirection(newProjectFilePath);
               
                if (Directory.Exists(dirPathUserData))
                {
                    Directory.Delete(dirPathUserData, true);
                }
                System.IO.Directory.CreateDirectory(dirPathUserData);

                List<string> ltStrDataSourceFiles = new List<string>();
                ltStrDataSourceFiles.Add(cProjectManager.filePathInputWellhead);
                ltStrDataSourceFiles.Add(cProjectManager.filePathRunInfor);

                foreach (string sItem in ltStrDataSourceFiles)
                {
                    FileStream fs = new FileStream(sItem, FileMode.Create);
                    fs.Close();
                }
                if (Directory.Exists(dirPathUsedProjectData)) Directory.Delete(dirPathUsedProjectData, true);
                Directory.CreateDirectory(dirPathUsedProjectData);

                if (Directory.Exists(dirPathMap)) Directory.Delete(dirPathMap, true);
                Directory.CreateDirectory(dirPathMap);

                if (!Directory.Exists(dirPathTemp)) Directory.CreateDirectory(dirPathTemp);

                if (!Directory.Exists(dirPathHis)) Directory.CreateDirectory(dirPathHis); 
          
                if (!Directory.Exists(dirPathTemplate)) Directory.CreateDirectory(dirPathTemplate);
                
                cProjectData.ltProjectWell.Clear();
                cProjectData.ltStrProjectJH.Clear();
                
                cProjectManager.initialCodeList();
                MessageBox.Show("项目建立。", "提示");
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 打开.xl文件 xml文件中读取，初始化项目数据
        /// </summary>
        /// <returns></returns>
        public static bool loadProject()
        {
            OpenFileDialog ofdProjectPath = new OpenFileDialog();

            ofdProjectPath.Title = " 打开项目：";
            ofdProjectPath.Filter = "xl文件|*.xl";
            //设置默认文件类型显示顺序 
            ofdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            ofdProjectPath.RestoreDirectory = true;

            if (ofdProjectPath.ShowDialog() == DialogResult.OK)
            {
                loadProject(ofdProjectPath.FileName);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool loadProject(string projectFile) 
        {
            //更新工程路径方向
            cProjectManager.updateProjectDirection(projectFile);
            //加载工程数据
            cProjectData.loadProjectData();
            //工程井信息加载
            cProjectData.setProjectWellsInfor();
            return true;
        }

        public static void  saveProject()
        {
            //save all staticData into project
            cfilePathProject.setProjectRefPointNode();
            cfilePathProject.setProjectJHNode();
            cfilePathProject.setProjectLogSeriersNode();
            cfilePathProject.setProjectYMNode();
            cfilePathProject.setProjectUnitNode(); 
        }
        public static void createWellDir(string sJH)
        {
            if (!Directory.Exists(cProjectManager.dirPathWellDir)) System.IO.Directory.CreateDirectory(cProjectManager.dirPathWellDir);

            string dirJH = Path.Combine(cProjectManager.dirPathWellDir, sJH);
            if (!Directory.Exists(dirJH)) Directory.CreateDirectory(dirJH); 
         
            string _fileWellPath = Path.Combine(dirPathWellDir, "#wellPath#");
            if (!File.Exists(_fileWellPath)) cIOinputWellPath.creatVerticalWellPathGeoFile(sJH);

            //单井图文件可以加，但是涉及到选模板的问题，在这里加不合适。

          
        }

        public static void delWellFromProject(string sJH) 
        {
            DialogResult dialogResult = MessageBox.Show("当前选中井为：" + sJH + "，确认删除且不可恢复？", "删除选中井", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cIOinputWellHead.deleteJHFromWellHead(sJH);
                cProjectData.ltStrProjectJH.Remove(sJH);
                string dirPath = Path.Combine(cProjectManager.dirPathWellDir, sJH);
                Directory.Delete(dirPath, true);
                cProjectData.setProjectWellsInfor(); 
            }
           
        }

        public static void updateWellInfor2Project(ItemWellHead sttNewWell)
        {
            cIOinputWellHead.updateWellHead(sttNewWell);
            cProjectManager.createWellDir(sttNewWell.sJH);
            if (cProjectData.ltStrProjectJH.IndexOf(sttNewWell.sJH)<0) cProjectData.ltStrProjectJH.Add(sttNewWell.sJH);
            cProjectData.setProjectWellsInfor();
            MessageBox.Show(sttNewWell.sJH + "入库成功。");
        }

        public static void createLayerDir()
        {
            if (!Directory.Exists(cProjectManager.dirPathLayerDir)) System.IO.Directory.CreateDirectory(cProjectManager.dirPathLayerDir);
          
            foreach (string _sXCM in cProjectData.ltStrProjectXCM)
            {
                string _dirXCM = Path.Combine(cProjectManager.dirPathLayerDir, _sXCM);
                if (!Directory.Exists(_dirXCM))
                {
                    Directory.CreateDirectory(_dirXCM);
                }
            }
        }

        public static void saveProeject2otherDirectionary() 
        {
            SaveFileDialog sfdProjectPath = new SaveFileDialog();
            //设置文件类型 
            sfdProjectPath.Title = " 请输入保存数据的位置：";
            sfdProjectPath.Filter = "xl文件|*.xl";
            //设置默认文件类型显示顺序 
            sfdProjectPath.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfdProjectPath.RestoreDirectory = true;
            if (sfdProjectPath.ShowDialog() == DialogResult.OK)
            {
                string newProjectFilePath = sfdProjectPath.FileName;
                string DestinationPath = Path.GetDirectoryName(newProjectFilePath);
                string SourcePath = dirProject;
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                string oldProjectName=Path.Combine(DestinationPath,Path.GetFileName(filePathProject));
                if (System.IO.File.Exists(newProjectFilePath)) System.IO.File.Delete(newProjectFilePath);
                System.IO.File.Move(oldProjectName, newProjectFilePath);
                MessageBox.Show("保存完毕。");
            }
        }

        public static List<string> getTemplateFileNameList() 
        {
            //如果没有模板文件，把系统模板的文件copy到这个目录下作为基本目标。
            string templateSysDirPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),cProjectManager.dirTemplateSysName);
            if (Directory.GetFiles(dirPathTemplate, "*" + fileExtensionTemplate).Count() == 0 && Directory.Exists(templateSysDirPath))
            {
                string[] templateFiles = Directory.GetFiles(templateSysDirPath, "*" + fileExtensionTemplate);
                foreach (string file in templateFiles)
                {
                    string templeFileName = Path.GetFileName(file);
                    File.Copy(file, Path.Combine(dirPathTemplate, templeFileName));
                }
            }
            string[] files = Directory.GetFiles(dirPathTemplate, "*" + fileExtensionTemplate);
            List<string> ltFileNameXTM = new List<string>();
            foreach (string file in files)
                ltFileNameXTM.Add(Path.GetFileName(file));
            return ltFileNameXTM; 
        }

        public static void save2ProjectResultMap(string inputFilePathSVG)
        {
            FormInputBox inputBox = new FormInputBox("请输入图名", "图名:");
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
               string sMapName = inputBox.ReturnValueStr.Trim();      
               save2ProjectResultMap( inputFilePathSVG,sMapName);
            }
        }

        public static void save2ProjectResultMap(string inputFilePathSVG,string fileNameMap)
        {
            if (fileNameMap != "")
                {
                    string filePathGoal = Path.Combine(cProjectManager.dirPathMap, fileNameMap + ".svg");
                    //读写
                    StreamWriter sw = new StreamWriter(filePathGoal, false, Encoding.UTF8);

                    using (StreamReader sr = new StreamReader(inputFilePathSVG, Encoding.UTF8))
                    {
                        string sContent = sr.ReadToEnd();
                        string pattern = "<script.*script>";
                        sContent = Regex.Replace(sContent, pattern, "");
                        //pattern = "onclick=\"getID(evt)\".";
                        //sContent=Regex.Replace(sContent, pattern, "");
                        sContent = sContent.Replace("onclick=\"getID(evt)\" ", "");
                        sw.Write(sContent);
                    }
                    sw.Close();
                    MessageBox.Show("成果图已经入库。");
                }
            }
       
    }
}
