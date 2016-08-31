import sys
sys.path.append("lib")
sys.path.append("lib//geoScape")
from geoScapeIO import *
import os
import codecs


print "当前路径:" + sProjectWellPath ##工程路径
print  "工作路径:" + os.getcwd()
print "当前井：" + sJH

## 以上代码不用修改

#for 循环语句示例 [x+y+3 for x,y in zip(a,b)]

## 利用SP计算泥质含量
##  此处改写代码

sLogName="SP"
SP=logData(sJH,sLogName,sProjectWellPath) ## 包括两个 double 型 List 列表变量， fListMD 和 fListValue
depth=SP.fListMD

SPsd=0     ## 纯砂岩处的测井响应值
SPsh=100   ## 纯泥岩处的测井响应值


deltaSP=[ ( SPsd - x ) / (SPsd-SPsh) for x in SP.fListValue]

c=2  ##新地层 c 取 3.7 老地层取 2
VshLog=  [ 100 * (2**x*c-1)/(2**c-1) for x in deltaSP]


## 以上是改写算法


## 以下代码输出到文件，并显示，不需要修改。
newLog=VshLog
print filePathLogTemp
tempWriter = codecs.open(filePathLogTemp, 'w', encoding="utf-8")
for i in range(len(depth)):
##   print i,depth[i],newLog[i]
   tempWriter.write( "{:.2f}\t{:.2f}\n".format(depth[i],newLog[i]))
tempWriter.close()   

print ("计算完成")