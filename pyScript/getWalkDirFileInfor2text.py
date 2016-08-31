# -*- coding: utf-8 -*-

##在目录循环，输出包含的所有文件名
import shutil
import os,os.path

topDir="E:\sutan\Heglig Main"
def func(arg,dirname,names):
    for filespath in names:
        print os.path.join(dirname,filespath)

if __name__=="__main__":
    goalFilePath='result.txt'
    fileWrited=open(goalFilePath,'w')
    print "==========os.walk================"
    index = 1
    for root,subdirs,files in os.walk(topDir):
#       print "第",index,"层"
        index += 1
        for filepath in files:
            line= os.path.join(root,filepath)
            fileWrited.write(line+"\n")
        for sub in subdirs:
            line= os.path.join(root,sub)
#            fileWrited.write(line+"\n")
    fileWrited.close()
