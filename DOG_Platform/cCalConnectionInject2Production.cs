using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace DOGPlatform
{
    class cCalConnectionInject2Production 
    {
        //1.根据层位选择井，油井存入一个列表ltStrJHOil,水井存入ltStrWater
        //2.根据时间，到射孔字典表里查 是否射孔，未射孔的从ltStr中删除
        //3.到小层数据表字典中查 是否有砂厚，没有砂厚的删除
        //4.假设其余所有水井与油井全建立关系
        //5.删除与断层线相交的组合
        //6.任意两条相交线段，保留距离短的
/// <summary>
/// 生成注采对应关系文件，格式采用geoEar格式
/// </summary>
/// <param name="ltStrJHwater"></param>
/// <param name="ltStrJHoil"></param>
/// <param name="selectedLayer"></param>
/// <param name="selectedYM"></param>
/// <param name="filePath"></param>
        public void generateConnectFile(string filePath,List<string> ltStrJHwater, List<string> ltStrJHoil, string selectedLayer, string selectedYM )
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            List<string> ltStrConnectJH = calConnection(selectedLayer, ltStrJHwater, ltStrJHoil);
            for (int i = 0; i < ltStrConnectJH.Count; i = i + 2)
            {
                List<string> ltStrWrited = new List<string>();
                ltStrWrited.Add(ltStrConnectJH[i]);
                ltStrWrited.Add(ltStrConnectJH[i + 1]);
                sw.WriteLine(string.Join("\t", ltStrWrited.ToArray()));
            }
            sw.Close();

        }

        bool bDistance(string sJHinj, string sJHpro) 
        {
            return true;
        }

        public bool bConnection(string sXCM, string sJHinj, string sJHpro)
        {
            bool returnConnect = true;

            float fMinWellDistance = 2000.0f;

            //井距太大
            if (bDistance(sJHinj, sJHpro)) { return false; } 

            //井间是否砂体尖灭

            //井间有断层不相连
            
            //是否同层射孔
            
            return returnConnect;
        }
        public List<string> calConnection(string sXCM, List<string> ltStrJHWater, List<string> ltStrJHOil)
        {
            List<string> ltStrResult = new List<string>();

            return ltStrResult;
        }

        //通过井型代码筛选井
        public List<string> get_ltStrJHByWellType(List<string> ltStrJH, string yyyymm, int iWellType)
        {
            List<string> ltStrJHSelected = new List<string>();

            return ltStrJHSelected;
        }

    }
}
