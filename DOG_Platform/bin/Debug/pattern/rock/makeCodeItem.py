# -*- coding: cp936 -*-
import os
import shutil


if __name__=="__main__":
    
    sourceDirPath="砾岩"

    fileWrited_txtLog=open("newItemCode.txt",'w')
    fileNames=os.listdir(sourceDirPath)
    for wellItem in fileNames:
        print ('doing'+'-'*10,wellItem)
        words=[]
        words.append(sourceDirPath)
        
        fileNameWithoutExtention=wellItem[:-4]

        words.append( fileNameWithoutExtention)
        words.append(fileNameWithoutExtention)
      
        words.append(fileNameWithoutExtention)
        words.append("100")
        words.append(fileNameWithoutExtention)
        fileWrited_txtLog.write("\t".join(words)+"\n")

    fileWrited_txtLog.close()    

    print("处理完毕")
