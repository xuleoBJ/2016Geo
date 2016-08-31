# -*- coding: cp936 -*-
import os
import shutil


if __name__=="__main__":
    
    sourceDirPath="砂岩"

    fileWrited_txtLog=open("newItemCode.txt",'w')
    fileNames=os.listdir(sourceDirPath)
    for wellItem in fileNames:
        print ('doing'+'-'*10,wellItem)
        words=[]
        words.append("rock")
        fileNameWithoutExtention=wellItem[:-4]

        words.append( fileNameWithoutExtention)
        words.append("num")
      
        words.append(fileNameWithoutExtention)
        words.append("83")
        words.append(fileNameWithoutExtention)
        fileWrited_txtLog.write("\t".join(words)+"\n")

    fileWrited_txtLog.close()    

    print("处理完毕")
