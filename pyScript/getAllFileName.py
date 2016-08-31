# -*- coding: cp936 -*-
import os
import shutil


if __name__=="__main__":
    
    sourceDirPath="source"

    fileWrited_txtLog=open("outPut.txt",'w')
    fileNames=os.listdir(sourceDirPath)
    for wellItem in fileNames:
        fileWrited_txtLog.write(wellItem[:-4]+"\n")

    fileWrited_txtLog.close()    

    print("处理完毕")
