using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    public enum TypeInputFile
    {
        井轨迹,
        分层数据,
        测井解释,
        射孔数据,
        吸水剖面,
    }

    public enum TypeConformity
    {
        整合 = 1,
        顶不整合 = 0,
        底不整合 = 2,
        顶底不整合 = 3
    }

    public enum typeUnit
    {
        Metric,
        Field
    }

    public enum typeLogFillMode
    {
         log,
         cutoff
    }
   
    public enum TypeWell
    {
        Undefined = 0,
        Propose = 1,
        Dry = 2,
        Oil = 3,
        MinorOil = 4,
        Gas = 5,
        MinorGas = 6,
        Platform = 8,
        Injectwater = 15,
        InjectGas = 16,
        DrillingWell = 18
    }

    public enum TypeLayer
    {
        LayerBase = 0,
        LayerWellPosition = 1,
        LayerValueText = 2,
        LayerValuePie = 3,
        LayerValueRect = 4,
        LayerPolyline = 5,
        LayerPolygon = 6,
        LayerGeoProperty = 7,
        LayerCoutour = 8,
        LayerHorizonalInterval=9,
        LayerDailyProduct, //日产注
        LayerSumProduct,  //累产注
        LayerBarGraph,
        LayerPieGraph,
        LayerJSJL,
        LayerLog
    }


    public enum TypeShowValue
    {
        value,
        rect,
        pie,
    }

    public enum LeftOrRight
    {
        left, right,
    }

    public enum TypeSectionTreeNode
    {
        Page,
        Ruler,
        WellName,
        LogCurve,
        Litho,
        Perforation,
        JSJL,
        Layer,
        WellConeRuler,
    }

    public enum TypeModeGeoOperate
    {
        none,
        connectTwo,
        channelLeft,
        channelRight,
        barLeft,
        barRight,
        pinchOutLeft,
        pinchOutRight,
        fault,
        revertFault
    }

    public enum TypeProjectNode
    {
        wells,
        well,
        wellTopDir,
        wellTop,
        layerMap,
        sectionWell,
        sectionWellDir,
        wellLogDir,
        logItem,
        sectionGeo,
        sectionGeoDir,
        sectionFence,
        sectionFenceDir,
        globalLog,
        globalLogDir,
        calResultText,
        svgMap,
        svgMapDir
    }

    public enum TypeGeoFile
    {
        projectDir,
        wellDir,
        well,
        layerMap,
        钻井,
        测井,
        录井,
        岩心,
        井身结构,
        分析化验,
        其它
    }
    public enum TypeTrack
    {
        深度尺,
        海拔尺,
        分层,
        曲线道,
        文本道,
        岩性层段,
        射孔道,
        测井解释,
        含油级别,
        沉积旋回,
        散点,
        符号,
        杆状,
        曲线,
        比例条,
        图片道,
        描述,
        组分,
        管柱,
        曲线填充
    }
   

    enum OpreateMode
    {
        Initial,
        Select,
        DrawLine,
        DrawPolygon
    }


    public enum textAlignMode
    {
        middleMiddle,
        leftUp
    }
  

    
}
