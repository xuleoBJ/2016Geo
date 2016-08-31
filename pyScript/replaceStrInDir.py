# -*- coding: cp936 -*-
import os
import shutil

def funReplace(filePathSource,filePathWrited):
        fileOpened_forwardLog=open(filePathSource,'r')
        s=fileOpened_forwardLog.read()
        s=s.replace("width=\"210mm\"","width=\"200\"")
        s=s.replace("height=\"297mm\"","height=\"300\"")
        s=s.replace("0 0 744.09448819 1052.3622047","0 0 200 300")
        fileWrited_txtLog=open(filePathWrited,'w')
        fileWrited_txtLog.write(s)
        fileOpened_forwardLog.close()
        fileWrited_txtLog.close()
    

if __name__=="__main__":
    
    sourceDirPath="source"
    goalDirPath='New'
    
    print ('prepare: ',goalDirPath)
    if os.path.exists(goalDirPath):
        shutil.rmtree(goalDirPath)
    os.mkdir(goalDirPath)

    ##  把操作目录下文件存入filenameslist
    fileNames=os.listdir(sourceDirPath)
    for wellItem in fileNames:
        print ('doing'+'-'*10,wellItem)
        fileOpened=sourceDirPath+'\\'+wellItem
        ## new name
        fileWrited=goalDirPath+'\\'+wellItem
        funReplace(fileOpened,fileWrited)
        

    print("处理完毕")
