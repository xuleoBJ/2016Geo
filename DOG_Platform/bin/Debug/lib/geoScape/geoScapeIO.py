# -*- coding: cp936 -*-
import os
import shutil

class logData():
    def __init__(self,sJH,sLogName,dirWell):
        self.wellName=sJH
        self.sLogName=sLogName
        self.fListMD=[]           ##MD
        self.fListValue=[]        ##Value
        logFile=os.path.join(dirWell,sJH,sLogName+'.log')
        if os.path.exists(logFile):
            fileOpened=open(logFile,'r')
            lineIndex=0
            for line in fileOpened.readlines():
                lineIndex=lineIndex+1
                splitLine=line.split()
                if line!="" and lineIndex>=4 and len(splitLine)>=2:
                     self.fListMD.append(float(splitLine[0]))
                     self.fListValue.append(float(splitLine[1]))
            print "井："+sJH +"曲线 "+sLogName+"数据读取完成"
        else:
            print logFile+"数据文件不存在。"
    def printResult(self):
        print("ok")
