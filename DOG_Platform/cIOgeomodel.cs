using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cIOgeomodel
    {
        string geoText = "!xuleo'geomeling\r\n";

        //写出mesh参数
        public void outputGridPara()
        {
            cGeomodelData geomodelData = new cGeomodelData(cProjectData.projectMesh);
            geoText = geoText + "Xsize:\t" + cProjectData.projectMesh.iXsize.ToString() + "\tYsize:\t" + cProjectData.projectMesh.iYsize.ToString() + "\r\n";
            geoText = geoText + "Xstep:\t" + cProjectData.projectMesh.dXstep.ToString() + "\tYstep:\t" + cProjectData.projectMesh.dYstep.ToString() + "\r\n";
            geoText = geoText + "Xmin:\t" + cProjectData.projectMesh.dXmin.ToString() + "\tYmin:\t" + cProjectData.projectMesh.dYmin.ToString() + "\r\n";
            for (int i = 0; i < cProjectData.projectMesh.iXsize; i++)
                for (int j = 0; j < cProjectData.projectMesh.iYsize; j++)
                    geoText = geoText + geomodelData.ddZelevation[i, j].ToString() + "\t";
        }
        public void readText()
        {
            //using (StreamReader sr = new StreamReader(cProject.filePathLayerDataDic, Encoding.UTF8))
            //{
            //    String line;
            //    int iLine = 0;
            //    while ((line = sr.ReadLine()) != null)  //delete the line whose legth is 0
            //    {
            //        iLine++;
                   
            //        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

            //    }
            //}
        }
        public void writeText()
        {
            outputGridPara();
            
            string filePath = cProjectManager.dirPathTemp+ "123.txt";
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.Write(geoText);
            sw.Close();
            MessageBox.Show("建模数据整理完成");
           
        }

        //对地质模型的第一次生成的层位数据进行处理，在能确认缺失的地层填充数据
        //从第一次数据的末行处理，末行-999不能代表缺失，可能是未钻遇，中间段的-999是缺失，砂厚，有效厚、地层厚0，其它值-999，插值用
        void afterDealGeomodelData()
        {

            List<string> ltStrLine = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(cProjectManager.dirPathUsedProjectData + "geoModelLayerDataStep1.txt"))
                {
                    String line;
                    int iLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLine++;
                        if (iLine > 0)
                        {
                            ltStrLine.Add(line);

                        }
                    }
                }
                StreamWriter sw = new StreamWriter(cProjectManager.dirPathUsedProjectData + "geoModelLayerData.txt", false, Encoding.UTF8);
                for (int i = ltStrLine.Count - 1; i >= 0; i = i - 1)
                {
                    string sLine = ltStrLine[i];
                    string[] splitCurrent;
                    splitCurrent = sLine.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (splitCurrent.Length <= 4 && i < ltStrLine.Count - 1) //从后往前找到-999标号的层
                    {
                        string[] splitNextLine = ltStrLine[i + 1].Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitNextLine.Length > 4 && splitNextLine[0] == splitCurrent[0])
                        {
                            List<string> ltStrWrited = new List<string>();
                            ltStrWrited.Add(splitCurrent[0]);
                            ltStrWrited.Add(splitCurrent[1]);
                            ltStrWrited.Add(splitNextLine[2]); //x
                            ltStrWrited.Add(splitNextLine[3]); //y
                            ltStrWrited.Add(splitNextLine[4]); //ds1
                            ltStrWrited.Add(splitNextLine[4]);//ds2
                            ltStrWrited.Add("0"); //shahou
                            ltStrWrited.Add("0"); //youxiaohoudu
                            ltStrWrited.Add("-999"); //kxd
                            ltStrWrited.Add("-999"); //stl
                            ltStrWrited.Add("-999"); //bhd
                            ltStrLine[i] = string.Join("\t", ltStrWrited.ToArray());
                        }

                    }
                }

                foreach (string sLine in ltStrLine)
                {
                    sw.WriteLine(sLine);
                }
                sw.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }
    }
}
