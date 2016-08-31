import os
import sqlite3
import numpy as np

"""
how to restore log data in computer and get it feasible
1. database welllog store method: wellName_welllogName
"""
def createDataBase(dataBasePath):
    if not os.path.exists(dataBasePath):
        conn = sqlite3.connect(dataBasePath)
        cur = conn.cursor()

        sqlCreateTable_WellName_ID_map='''create table IF NOT EXISTS WellName_ID_map (wellName text PRIMARY KEY, well_ID)'''
        cur.execute(sqlCreateTable_WellName_ID_map)
        
        sqlCreateTable_WellHead='''create table IF NOT EXISTS wellhead (wellName text PRIMARY KEY, X real, Y real, KB real, TypeCode Integer)'''
        cur.execute(sqlCreateTable_WellHead)
        
        sqlCreateTable_WellTrajectory='''create table IF NOT EXISTS WellTrajectory  (wellName text PRIMARY KEY, X real, Y real, VDepth real)'''
        cur.execute(sqlCreateTable_WellTrajectory)
        
        sqlCreateTable_wellTop='''create table  IF NOT EXISTS welltop (wellName text , layerName text , topDepth real,
                       bottomDepth real,rank integer,primary key (wellName,layerName))'''
        cur.execute(sqlCreateTable_wellTop)
        
        sqlCreateTable_PerforationInfo='''create table  IF NOT EXISTS PerforationInfo (wellName text PRIMARY KEY, dateOfPerforation datetime, topDepth real,
                       bottomDepth real)'''
        cur.execute(sqlCreateTable_PerforationInfo)
        
        sqlCreateTable_InterpretationResult='''create table  IF NOT EXISTS InterpretationResult (wellName text, topDepth real, 
                       bottomDepth real, sandThickness real, payThickness real, pore real,
                       permeability real, oilSaturation real, jsjl interger, primary key (wellName))'''
        cur.execute(sqlCreateTable_InterpretationResult)

        sqlCreateTable_fault='''create table  IF NOT EXISTS fault ( x real, 
                       y real, z real, faultName text, faultType INTEGER )'''
        cur.execute(sqlCreateTable_fault)

        sqlCreateTable_InterpretationCode='''create table  IF NOT EXISTS InterpretationCode ( jsjl text, jsjlCode INTEGER )'''
        cur.execute(sqlCreateTable_fault)
       
        cur.close()
        conn.close()
        print("Database is created.")
    else:
        print("Database is exist.")


def importWellLogValue(_cur,_tableName,_depthvalue):
    _cur.executemany('REPLACE INTO %s VALUEs(?,?)',(_tableName,_depthvalue))

if __name__=="__main__":
    sCurrentPath=os.getcwd()
    print "database path:" +sCurrentPath
    dbBasePath=os.path.join(sCurrentPath,"logDB.db")
    createDataBase(dbBasePath)
    conn = sqlite3.connect(dbBasePath)
    cur = conn.cursor()
    sourceDirPath="_data\_log"
    fileNames=os.listdir(sourceDirPath)
    for fileItem in fileNames:
        log_tableName=fileItem.replace('.txt','')
        _fileOpened=os.path.join(sourceDirPath,fileItem)
        with open(_fileOpened,'r') as _file:
            firstLine = _file.readline()
        splitLogHead=firstLine.split()
        array=np.loadtxt(_fileOpened,skiprows=1)
        for i in range(1,len(splitLogHead)):
            tableName=log_tableName+splitLogHead[i]
            sql='''CREATE TABLE IF NOT EXISTS %s (DEPTH real,VALUE real)'''%tableName
##            print sql
            cur.execute(sql)
            rows=[]
            for j in range(array.shape[0]):
                rows.append((array[j,0],array[j,i]))
            sql='INSERT OR REPLACE INTO %s VALUES(?,?)'%tableName
            print sql
            cur.executemany(sql,rows)
    cur.close()
    conn.commit()
    conn.close()
