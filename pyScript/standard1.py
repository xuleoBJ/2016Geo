import sys
sys.path.append("lib")
sys.path.append("lib//geoScape")
from geoScapeIO import *
import os
import codecs

print "当前路径" + sProjectWellPath ##工程路径
print  "工作路径" + os.getcwd()

sJH="木100-2"
sLogName="GR"

fTop=0
fBot=1000
fMin=0
fMax=100

GR=logData(sJH,sLogName,sProjectWellPath)

newLog=[]

#[x+y+3 for x,y in zip(a,b)]

## GR 包括两个 double 型 List 列表变量， fListMD 和 fListValue
## 此处改写代码

newLog=[x+100 for x in GR.fListValue]

print(len(newLog),len(GR.fListMD))

## 以上是改写算法

## 输出到文件

print filePathLogTemp
tempWriter = codecs.open(filePathLogTemp, 'w', encoding="utf-8")
##print newLog
for i in range(len(GR.fListMD)):
##   print i,GR.fListMD[i],newLog[i]
   tempWriter.write( "{:.2f}\t{:.2f}\n".format(GR.fListMD[i],newLog[i]))
tempWriter.close()   

print ("计算完成")