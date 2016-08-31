import os
import shutil

class logData():
    def __init__(self,sLogName,dirLog):
        self.sLogName=sLogName
        self.fListMD=[]           ##MD
        self.fListValue=[]        ##Value
        stockDataFile=os.path.join(stockDirData,stockID+'.txt')
        if os.path.exists(stockDataFile):
            fileOpened=open(stockDataFile,'r')
            lineIndex=0
            for line in fileOpened.readlines():
                lineIndex=lineIndex+1
                splitLine=line.split()
                if lineIndex==1:
                    self.stockName=splitLine[1]
                    print "{},{}".format(self.stockID,self.stockName)
                if line!="" and lineIndex>=4 and len(splitLine)>=2:
                    self.fListMD.append(float(splitLine[0]))
                    self.fListValue.append((float(splitLine[1]))
            
        
