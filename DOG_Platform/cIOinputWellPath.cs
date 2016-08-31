using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cIOinputWellPath
    {
        public static void creatWellGeoHeadFile(string sJH, string filePath, string sFirstLine)
        {
            List<string> ltStrHeadColoum = new List<string>();
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("X");
            ltStrHeadColoum.Add("Y");
            ltStrHeadColoum.Add("Z");
            ltStrHeadColoum.Add("MD");
            ltStrHeadColoum.Add("INCL(°)");
            ltStrHeadColoum.Add("AZIM(°)");
            ltStrHeadColoum.Add("DX");
            ltStrHeadColoum.Add("DY");
            ltStrHeadColoum.Add("TVD");
            ltStrHeadColoum.Add("CalcDLS");
            cIOGeoEarthText.creatFileGeoHeadText(filePath, sFirstLine, ltStrHeadColoum);
        }

        public static void creatVerticalWellPathGeoFile(string sJH)
        {
            ItemWellHead wellHead = cIOinputWellHead.getWellHeadByJH(sJH);
            ItemDicWellPath wellPathTop = new ItemDicWellPath(wellHead);
            ItemDicWellPath wellPathBottom = new ItemDicWellPath(wellHead);
            wellPathBottom.dfZ = wellPathTop.dfZ - wellHead.fWellBase;
            wellPathBottom.f_md = wellHead.fWellBase;
            wellPathBottom.f_TVD = wellHead.fWellBase;
            List<ItemDicWellPath> listItem = new List<ItemDicWellPath>();
            listItem.Add(wellPathTop);
            listItem.Add(wellPathBottom);
            creatWellGeoFile(sJH, listItem);
        }


        public static void creatWellGeoFile(string _sJH)
        {
            List<float> fListMD = new List<float>();
            List<float> fListInc = new List<float>();
            List<float> fListAzimuth = new List<float>();

            ItemWellHead wellHead = cIOinputWellHead.getWellHeadByJH(_sJH);
            string inputFilePath =
                       Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellPath);
            if (File.Exists(inputFilePath))
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    String line;
                    int _indexLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine >=1 )
                        {
                            fListMD.Add(float.Parse(split[1]));
                            fListInc.Add(float.Parse(split[2]));
                            fListAzimuth.Add(float.Parse(split[3]));
                        }
                    }
                }
            }
            if (fListMD.Count > 2)
            {
                List<ItemDicWellPath> itemsWellPath = phzqf2Struct(_sJH, fListMD, fListInc, fListAzimuth);
                creatWellGeoFile(_sJH, itemsWellPath);
            }
          
        }

        public static void creatWellGeoFile(string sJH, List<ItemDicWellPath> listWellPath)
        {
            ItemWellHead wellHead = cIOinputWellHead.getWellHeadByJH(sJH);
            string filePath = Path.Combine(cProjectManager.dirPathWellDir, wellHead.sJH, cProjectManager.fileNameWellPath);
            string sFirstLine = cProjectManager.fileNameWellPath + wellHead.sJH + " " + wellHead.dbX.ToString() + " " + wellHead.dbY.ToString() + " " + wellHead.fKB.ToString();
            creatWellGeoHeadFile(wellHead.sJH, filePath, sFirstLine);
            List<string> ltStrLine = new List<string>();
            foreach (ItemDicWellPath _item in listWellPath)
            {
                ltStrLine.Add(ItemDicWellPath.item2string(_item));
            }
            cIOGeoEarthText.addDataLines2GeoEarTxt(filePath, ltStrLine);
        }


        public static void creatInputFile(string _sJH, List<string> listLinesInput)
        {
            string inputFilePath =
                        Path.Combine(cProjectManager.dirPathWellDir, _sJH, cProjectManager.fileNameInputWellPath);
            cIOBase.write2file(listLinesInput, inputFilePath);
        }
        public static void creatUserInputFileHead(string sJH)
        {
            string inputFilePath =
                        Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameInputWellPath);
            List<string> ltStrHeadColoum = new List<string>();
            ltStrHeadColoum.Add("井号");
            ltStrHeadColoum.Add("测深m");
            ltStrHeadColoum.Add("井斜角Incl(°)");
            ltStrHeadColoum.Add("方位角Azim(°)");
            string sFirstLine = "userInput $WellPath";
            cIOGeoEarthText.creatFileGeoHeadText(inputFilePath, sFirstLine, ltStrHeadColoum);
        }
      

        //平衡正切法计算井斜 输入必须是角度格式flist 和petrel对过 最后一个值 狗腿度没有计算。
        public static List<ItemDicWellPath> phzqf2Struct(string sJH, double dbX, double dbY, float fKB, List<float> fListMD, List<float> fListInc, List<float> fListAzimuth)
        { 
            List<ItemDicWellPath> returnListWellPathItem = new List<ItemDicWellPath>();
            if (fListMD.Count > 0)
            {
                double _tvd = fListMD[0]; //海拔向下为正 第一个点md=tvd
                double _y = 0; //偏移Y
                double _x = 0;//偏移X
                float _dls = 0; //狗腿度
                for (int i = 0; i < fListMD.Count; i++)
                {
                    if (i > 0)
                    {
                        float fLength = fListMD[i] - fListMD[i - 1];
                        float i1 = Convert.ToSingle(fListInc[i - 1] * Math.PI / 180.0);
                        float a1 = Convert.ToSingle(fListAzimuth[i - 1] * Math.PI/ 180.0);
                        float i2 = Convert.ToSingle(fListInc[i] * Math.PI / 180.0);
                        float a2 = Convert.ToSingle(fListAzimuth[i] * Math.PI / 180.0);

                        //        ## a1 上测点井斜 b1 上测点方位
                        _tvd = _tvd + 0.5 * fLength * (Math.Cos(i2) + Math.Cos(i1));
                        _y = _y + 0.5 * fLength * (Math.Sin(i1) * Math.Cos(a1) + Math.Sin(i2) * Math.Cos(a2));
                        _x = _x + 0.5 * fLength * (Math.Sin(i1) * Math.Sin(a1) + Math.Sin(i2) * Math.Sin(a2));
                        //注释为中国算法
                        //if (fLength != 0)
                        //    _dls = 30 / fLength * (float)
                        //            (180/Math.PI*Math.Pow(
                        //                     Math.Pow(( i1-i2),2) + Math.Pow( Math.Sin((i1+i2)/2) * (a2 - a1),2) ,0.5
                        //            )
                        //        );
                        if (fLength != 0)
                            _dls = 30 / fLength * (float)
                                ( 180/Math.PI*
                                    Math.Acos(
                                             (Math.Cos(i1) * Math.Cos(i2) + Math.Sin(i1) * Math.Sin(i2) * Math.Cos(a2 - a1))
                                    )
                                );
                    }
                    ItemDicWellPath sttWellPathItem = new ItemDicWellPath();
                    sttWellPathItem.sJH = sJH;
                    sttWellPathItem.dbX = dbX + _x;
                    sttWellPathItem.dbY = dbY + _y;
                    sttWellPathItem.dfZ = fKB - _tvd;
                    sttWellPathItem.f_md = fListMD[i];
                    sttWellPathItem.f_incl = fListInc[i];
                    sttWellPathItem.f_azim = fListAzimuth[i];
                    sttWellPathItem.f_dx = Convert.ToSingle(_x);
                    sttWellPathItem.f_dy = Convert.ToSingle(_y);
                    sttWellPathItem.f_TVD = Convert.ToSingle(_tvd);
                    sttWellPathItem.f_CalcDLS = _dls;
                    returnListWellPathItem.Add(sttWellPathItem);
                }

            }

            return returnListWellPathItem;
        }

        public static List<ItemDicWellPath> phzqf2Struct(string sJH,  List<float> fListMD, List<float> fListInc, List<float> fListAzimuth) 
        {
            ItemWellHead wellHead = cIOinputWellHead.getWellHeadByJH(sJH); 
            return phzqf2Struct(wellHead.sJH, wellHead.dbX, wellHead.dbY, wellHead.fKB, fListMD, fListInc, fListAzimuth);
        } 
        public static void updateWellgeoFile(string sJH, List<float> fListMD, List<float> fListInc, List<float> fListAzimuth)
        {
            List<ItemDicWellPath> itemsWellPath = phzqf2Struct(sJH, fListMD, fListInc, fListAzimuth);
            creatWellGeoFile(sJH, itemsWellPath); 
        }

        /// <summary>
        /// 从井文件夹读入用户输入的井斜原始4列数据，井号，深度，井斜角，方位角数据，更新井文件夹下的wellpath文件
        /// </summary>
        /// <param name="sJH"></param>
        public static void updateWellgeoFile(string sJH)
        {
            List<float> fListMD=new List<float>();
            List<float> fListInc=new List<float>();
            List<float> fListAzimuth=new List<float>();

            ItemWellHead wellHead = cIOinputWellHead.getWellHeadByJH(sJH);
            string inputFilePath =
                       Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameInputWellPath);
            if (File.Exists(inputFilePath))
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    String line;
                    int iStartLine = 4;
                    int _indexLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine == 1) continue;
                        else if (_indexLine == 2) iStartLine = 2 + int.Parse(split[0]);
                        else if (_indexLine > iStartLine)
                        {
                            fListMD.Add(float.Parse(split[1]));
                            fListInc.Add(float.Parse(split[2]));
                            fListAzimuth.Add( float.Parse(split[3]));
                        }
                    }
                }
            }
            if (fListMD.Count > 2)
            {
                List<ItemDicWellPath> itemsWellPath = phzqf2Struct(sJH, fListMD, fListInc, fListAzimuth);
                creatWellGeoFile(sJH, itemsWellPath);
            }
        }

        public static void readInput2Project(string userInputText, string sProjectInputText)
        {
            //first 需要验证文件格式是否正确，数据格式是否正确，不正确应该放弃
        }

        public static List<ItemDicWellPath> readWellPath2Struct(string sJH)
        {
            List<ItemDicWellPath> returnListWellPathItem = new List<ItemDicWellPath>();

            string filePath = Path.Combine(cProjectManager.dirPathWellDir, sJH, cProjectManager.fileNameWellPath);
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line;
                    ItemDicWellPath sttWellPathItem = new ItemDicWellPath();
                    int iStartLine = 4;
                    int _indexLine = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        _indexLine++;
                        string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_indexLine == 1) continue;
                        else if (_indexLine == 2) iStartLine = 2 + int.Parse(split[0]);
                        else if (_indexLine > iStartLine)
                        {
                            sttWellPathItem.sJH = split[0];
                            sttWellPathItem.dbX = double.Parse(split[1]);
                            sttWellPathItem.dbY = double.Parse(split[2]);
                            sttWellPathItem.dfZ = double.Parse(split[3]);
                            sttWellPathItem.f_md = float.Parse(split[4]);
                            sttWellPathItem.f_incl = float.Parse(split[5]);
                            sttWellPathItem.f_azim = float.Parse(split[6]);
                            sttWellPathItem.f_dx = float.Parse(split[7]);
                            sttWellPathItem.f_dy = float.Parse(split[8]);
                            sttWellPathItem.f_TVD = float.Parse(split[9]);
                            sttWellPathItem.f_CalcDLS = float.Parse(split[10]);
                            returnListWellPathItem.Add(sttWellPathItem);
                        }

                    }
                }
            }


            return returnListWellPathItem;

        }

        public static ItemDicWellPath getWellPathItemByJHAndMD(string sJH, double fMD) 
        {
            return getWellPathItemByJHAndMD(readWellPath2Struct(sJH),(float) fMD); 
        }

        public static ItemDicWellPath getWellPathItemByJHAndMD(ItemWell curWell, float fMD) //算法需要验证和改进
        {
            return getWellPathItemByJHAndMD(curWell.WellPathList, (float)fMD);
        }

        public static ItemDicWellPath getWellPathItemByJHAndMD(List<ItemDicWellPath> listWellPathItem, float fMD) 
        {
            List<float> ltFloatMd = listWellPathItem.Select(p => p.f_md).ToList();
            int _iUp = 1;
            int _iDown = 0;

            if (fMD >= ltFloatMd[ltFloatMd.Count - 1])
            {
                _iUp = ltFloatMd.Count - 1;
                _iDown = _iUp - 1;
            }
            else if (fMD <= ltFloatMd[0])
            {

            }
            else
            {
                for (int i = 1; i < ltFloatMd.Count; i++)
                {
                    if (ltFloatMd[i] >= fMD && ltFloatMd[i - 1] <= fMD)
                    {
                        _iDown = i - 1;
                        _iUp = i;
                    }
                }
            }
            ItemDicWellPath itemDown = listWellPathItem[_iDown];
            ItemDicWellPath itemUp = listWellPathItem[_iUp];

            ItemDicWellPath returnWellPathItem = new ItemDicWellPath();

            returnWellPathItem.dbX = cInterpolation.linear(fMD, itemUp.f_md, itemUp.dbX, itemDown.f_md, itemDown.dbX);
            returnWellPathItem.dbY = cInterpolation.linear(fMD, itemUp.f_md, itemUp.dbY, itemDown.f_md, itemDown.dbY);
            returnWellPathItem.dfZ = cInterpolation.linear(fMD, itemUp.f_md, itemUp.dfZ, itemDown.f_md, itemDown.dfZ);
            returnWellPathItem.f_incl = cInterpolation.linear(fMD, itemUp.f_md, itemUp.f_incl, itemDown.f_md, itemDown.f_incl);
            returnWellPathItem.f_azim = cInterpolation.linear(fMD, itemUp.f_md, itemUp.f_azim, itemDown.f_md, itemDown.f_azim);
            returnWellPathItem.f_dx = cInterpolation.linear(fMD, itemUp.f_md, itemUp.f_dx, itemDown.f_md, itemDown.f_dx);
            returnWellPathItem.f_dy = cInterpolation.linear(fMD, itemUp.f_md, itemUp.f_dy, itemDown.f_md, itemDown.f_dy);
            returnWellPathItem.f_CalcDLS = cInterpolation.linear(fMD, itemUp.f_md, itemUp.f_CalcDLS, itemDown.f_md, itemDown.f_CalcDLS);
            returnWellPathItem.f_TVD = cInterpolation.linear(fMD, itemUp.f_md, itemUp.f_TVD, itemDown.f_md, itemDown.f_TVD);

            return returnWellPathItem; 
        
        }

        public static List<ItemDicWellPath> getWellPathItemListByJHAndMDList(string sJH, List<float> fListMD)
        {
            List<ItemDicWellPath> listReturnWellPath = new List<ItemDicWellPath>();

            List<ItemDicWellPath> listWellPath = readWellPath2Struct(sJH);
           
            foreach (float _fMD in fListMD)
            {
                ItemDicWellPath currentWellPath = getWellPathItemByJHAndMD(listWellPath, _fMD);
                listReturnWellPath.Add(currentWellPath);
            }
            return listReturnWellPath;

        }

        public static float getTVDByJHAndMD(string sJH, float fMD) //算法需要验证和改进
        {
            return getTVDByJHAndMD(sJH, fMD, readWellPath2Struct(sJH));
        }
        public static float getTVDByJHAndMD(ItemWell curWell, float fMD)
        {
            if(curWell!=null ) return getTVDByJHAndMD(curWell.sJH, fMD, curWell.WellPathList);
            else return fMD;
        }
        public static float getTVDByJHAndMD(string sJH, float fMD, List<ItemDicWellPath> listWellPathItem) //算法需要验证和改进
        {
            List<float> ltFloatMd = listWellPathItem.Select(p => p.f_md).ToList();
            List<float> ltFloatTVD = listWellPathItem.Select(p => p.f_TVD).ToList();
            int _iUp = 1;
            int _iDown = 0;

            if (fMD >= ltFloatMd[ltFloatMd.Count - 1])
            {
                _iUp = ltFloatMd.Count - 1;
                _iDown = _iUp - 1;
            }
            else if (fMD <= ltFloatMd[0])
            {
                
            }
            else{
                for (int i = 1; i < ltFloatMd.Count; i++)
                {
                    if (ltFloatMd[i] >= fMD && ltFloatMd[i - 1] <= fMD)
                    {
                        _iDown = i - 1;
                        _iUp = i;
                    }
                }
            }

            float f_TVD = cInterpolation.linear(fMD, ltFloatMd[_iUp], ltFloatTVD[_iUp], ltFloatMd[_iDown], ltFloatTVD[_iDown]);

            return f_TVD;
        }

        public static float getMDByJHAndTVD(string sJH, float fTVD, List<ItemDicWellPath> listWellPathItem) 
        {
            List<float> ltFloatMd = listWellPathItem.Select(p => p.f_md).ToList();
            List<float> ltFloatTVD = listWellPathItem.Select(p => p.f_TVD).ToList();
            int _iUp = 1;
            int _iDown = 0;

            if (fTVD >= ltFloatTVD[ltFloatTVD.Count - 1])
            {
                _iUp = ltFloatTVD.Count - 1;
                _iDown = _iUp - 1;
            }
            else if (fTVD <= ltFloatMd[0])
            {

            }
            else
            {
                for (int i = 1; i < ltFloatTVD.Count; i++)
                {
                    if (ltFloatTVD[i] >= fTVD && ltFloatTVD[i - 1] <= fTVD)
                    {
                        _iDown = i - 1;
                        _iUp = i;
                    }
                }
            }

            float f_MD = cInterpolation.linear(fTVD, ltFloatTVD[_iUp], ltFloatMd[_iUp], ltFloatTVD[_iDown],ltFloatMd[_iDown]);

            return f_MD; 
        }
    }
}
