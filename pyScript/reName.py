# -*- coding: cp936 -*-
import os
import shutil

def forward2txt(filePath_forwardLog,filePath_txtLog):
        fileOpened_forwardLog=open(filePath_forwardLog,'r')
        s=fileOpened_forwardLog.read()
        s=s.replace("patternSed","USGS")
        fileWrited_txtLog=open(filePath_txtLog,'w')
        fileWrited_txtLog.write(s)
        fileOpened_forwardLog.close()
        fileWrited_txtLog.close()
    

if __name__=="__main__":
    
    sourceDirPath="rock"
    goalDirPath='rockNew'
    
    print ('prepare: ',goalDirPath)
    if os.path.exists(goalDirPath):
        shutil.rmtree(goalDirPath)
    os.mkdir(goalDirPath)

    ##  把操作目录下文件存入filenameslist
    fileNames=os.listdir(sourceDirPath)
    for wellItem in fileNames:
        print ('doing'+'-'*10,wellItem)
        fileOpened=sourceDirPath+'\\'+wellItem
        fileWrited=goalDirPath+'\\'+wellItem.replace("patternSed","USGS")
        forward2txt(fileOpened,fileWrited)
        

    print("处理完毕")
