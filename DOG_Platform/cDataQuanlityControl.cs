using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cDataQuanlityControl
    {
        

      
        //验证wellHead layerData数据是否唯一

        public void dataCheckWellHeadAndLayerUnique() 
        {

            cProjectData.sErrLineInfor= "";

            List<ItemWellHead> listWellHead = cIOinputWellHead.readWellHead2Struct();

            for (int i = 0; i < listWellHead.Count; i++)
            {
                ItemWellHead wellHead1 = listWellHead[i];
                for (int j = i + 1; j < listWellHead.Count; j++)
                {
                    ItemWellHead wellHead2=listWellHead[j];
                    if (wellHead1.sJH ==wellHead2.sJH)
                        cProjectData.sErrLineInfor += "wellHead  " + (i + 1).ToString() + "行" + wellHead1.sJH + "在行" + (j + 1).ToString() + "重复。\r\n";
                }
            }

         
            
            if (cProjectData.sErrLineInfor== "")
            {
                MessageBox.Show("井头文件和分层数据文件唯一。");
            }
            else
            {
                MessageBox.Show("数据有一些错误，请点击查看。");
                cPublicMethodForm.outputErrInfor2Text(cProjectData.sErrLineInfor);
                
            }
        }
        public string dataTypeValided4Float(string filepath,List<int>iListIndex)
        {
            string strReturnErrLine = "";
            string[] split;
            try
            {
                using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    String line;
                    int iLineNumber = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {   iLineNumber++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach(int iItem in iListIndex)
                        {
                            float fConvert=0;
                            if (float.TryParse(split[iItem], out  fConvert) == false)
                                strReturnErrLine += filepath + " " + iLineNumber.ToString() + "行" + (iItem + 1).ToString() + "\t列值 " 
                                    + split[iItem] + "\t非数字" + "\r\n";
                        }

                    }
                }
               
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return strReturnErrLine;
        }
        public string dataTypeValided4Int(string filepath, List<int> iListIndex)
        {
            string strReturnErrLine = "";
            string[] split;
            try
            {
                using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    String line;
                    int iLineNumber = 0;
                   
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineNumber++;
                        line=line.Replace("\r\n", "\t");
                        split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.None );
                        //检查数组是否越界！！！！
                        if (split.Count() < iListIndex.Max()+1) 
                        {
                            MessageBox.Show(filepath + "\t"+iLineNumber + "\t" + line);
                        }
                       
                        foreach (int iItem in iListIndex)
                        {
                    
                            int fConvert = 0;
                            if (int.TryParse(split[iItem], out  fConvert) == false)
                            {

                                strReturnErrLine += filepath + " " + iLineNumber.ToString() + "行" + (iItem + 1).ToString() + "列值"
                                    + split[iItem] + "\t非整数" + "\r\n";
                            }
        
                        }

                    }
                }

            }

            catch (Exception e)
            {
                
                MessageBox.Show(e.ToString());
            }
            return strReturnErrLine;
        }
        public string dataTypeValided4IntYYYYMM(string filepath, List<int> iListIndex)
        {
            string strReturnErrLine = "";
            string[] split;
            try
            {
                using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    String line;
                    int iLineNumber = 0;
                    while ((line = sr.ReadLine()) != null) //delete the line whose legth is 0
                    {
                        iLineNumber++;
                        split = line.Trim().Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (int iItem in iListIndex)
                        {
                            int iConvert = 0;
                            if (int.TryParse(split[iItem], out iConvert) )
                            {
                                if (iConvert % 100 > 12 || (iConvert / 100) < 1000)
                                    strReturnErrLine += filepath + " " + iLineNumber.ToString() + "行" + (iItem + 1).ToString() + "列值\t"
                            + split[iItem] + "\t非6位YYYYMM型年月" + "\r\n";
                            }
                            else
                            {
                              strReturnErrLine += filepath + " " + iLineNumber.ToString() + "行" + (iItem + 1).ToString() + "列值\t"
                                    + split[iItem] + "\t非6位YYYYMM型年月" + "\r\n";
                            }

                        }

                    }
                }

            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return strReturnErrLine;
        }
        public  bool dataCheckInputWellHead()
        {
            bool returnBool=false;
            cProjectData.sErrLineInfor= "";

            //定义列表存 文件中对应需要检验的列位置
            List<int> iColomnList = new List<int>();

            //wellHead 验证1，2，3列为float，其实，1，2为double，4为int
            iColomnList.Add(1);
            iColomnList.Add(2);
            iColomnList.Add(3);
            cProjectData.sErrLineInfor+= dataTypeValided4Float(cProjectManager.filePathInputWellhead, iColomnList);
            iColomnList.Clear();
            iColomnList.Add(4);
            cProjectData.sErrLineInfor+= dataTypeValided4Int(cProjectManager.filePathInputWellhead, iColomnList);
            if (cProjectData.sErrLineInfor== "") returnBool = true;
            else cPublicMethodForm.showErrInfor("数据有误");

            return returnBool;

        }
        //验证输入数据类型有效性类型
        public void dataCheckInputDataTypeValid()
        {
            cProjectData.sErrLineInfor= "";

            //定义列表存 文件中对应需要检验的列位置
             List<int> iColomnList=new List<int>();

            //wellHead 验证1，2，3列为float，其实，1，2为double，4为int
             iColomnList.Add(1);
             iColomnList.Add(2);
             iColomnList.Add(3);
             cProjectData.sErrLineInfor+= dataTypeValided4Float(cProjectManager.filePathInputWellhead, iColomnList);
             iColomnList.Clear();
             iColomnList.Add(4);
             cProjectData.sErrLineInfor+= dataTypeValided4Int(cProjectManager.filePathInputWellhead, iColomnList);
             
           

             cPublicMethodForm.showErrInfor("输入数据类型可以满足计算要求。");
   
        }
      
      
      

    
     
       
    }
}
