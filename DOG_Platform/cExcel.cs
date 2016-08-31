using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace DOGPlatform
{
    class cExcel
    {
        //导出到Excel方法
        //public bool ExportDataGridviewExcel(DataGridView gridview, bool isShowExcel)
        //{
        //    if (gridview.Rows.Count == 0)
        //    {
        //        return false;
        //    }
        //    //建立Excel对象
        //    Excel.Application excel = new Excel.Application();
        //    excel.Application.Workbooks.Add(true);
        //    excel.Visible = isShowExcel;
        //    //生成字段名称
        //    for (int i = 0; i < gridview.Columns.Count; i++)
        //    {
        //        excel.Cells[1, i + 1] = gridview.Columns[i].HeaderText;
        //    }
        //    //填充数据
        //    for (int i = 0; i < gridview.Rows.Count - 1; i++)
        //    {
        //        for (int j = 0; j < gridview.Columns.Count; j++)
        //        {
        //            if (gridview[j, i].ValueType == typeof(string))
        //            {
        //                excel.Cells[i + 2, j + 1] = "" + gridview[j, i].Value.ToString();
        //            }
        //            else
        //            {
        //                excel.Cells[i + 2, j + 1] = gridview[j, i].Value.ToString();
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}
