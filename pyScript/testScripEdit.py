import sys
sys.path.append("lib")
sys.path.append("lib//geoScape")
from geoScapeIO import *
import os

print sProjectPath ##工程路径
print os.getcwd()

sJH="木100-2"
sLogName="GR"

GR=logData(sJH,sLogName,sProjectPath)

newFList=[]

## 此处改写代码

newFList=GR.fListValue

## 以上是改写算法

iMaxprintLine =  min([len(GR.fListMD),10])
for i in range(iMaxprintLine):
    print GR.fListMD[i],GR.fListValue[i],newFList[i]
print os.path.dirname(sProjectPath)