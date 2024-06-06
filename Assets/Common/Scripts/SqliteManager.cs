using SQLite4Unity3d;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class SqliteManager :MonoBehaviour
{
    private string dbName = "programing_suport";
    private SQLiteConnection _connection;

    private static SqliteManager _instance;

    private void Awake()
    {
        string dbFileName = $"/{dbName}.db";
        string dbPath = Application.persistentDataPath + $"{dbFileName}";
        //DB�֐ڑ�
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
    }

    //Insert�����s
    //exeUpdate = true�̏ꍇ�̓f�[�^�����݂��Ă��鎞��Update�����s����
    public void DBInsert(BaseSqliteModel data, bool exeUpdate = true)
    {
        _connection.CreateTable(data.GetType());
        try
        {
            _connection.Insert(data);
        }
        //��Ӑ��G���[�����������ꍇ
        catch (SQLiteException ex) when (ex.Result == SQLite3.Result.Constraint)
        {
            //update��������Ă���ꍇ��update
            if (exeUpdate) 
            {
                _connection.Update(data);
            }
        }
    }
    //InsertAll�����s
    public void DBInsertAll(List<BaseSqliteModel> data)
    {
        _connection.CreateTable(data.GetType());
        _connection.InsertAll(data);
    }
    //Update�����s
    public void DBUpdate(BaseSqliteModel data)
    {
        _connection.Update(data);
    }
    //�f�[�^���ꗗ�Ŏ擾
    public List<T> DBSelectAll<T>() where T : new()
    {
        return _connection.Table<T>().ToList();
    }
}
