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
        //DBへ接続
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
    }

    //Insertを実行
    //exeUpdate = trueの場合はデータが存在している時はUpdateを実行する
    public void DBInsert(BaseSqliteModel data, bool exeUpdate = true)
    {
        _connection.CreateTable(data.GetType());
        try
        {
            _connection.Insert(data);
        }
        //一意制エラーが発生した場合
        catch (SQLiteException ex) when (ex.Result == SQLite3.Result.Constraint)
        {
            //updateを許可されている場合はupdate
            if (exeUpdate) 
            {
                _connection.Update(data);
            }
        }
    }
    //InsertAllを実行
    public void DBInsertAll(List<BaseSqliteModel> data)
    {
        _connection.CreateTable(data.GetType());
        _connection.InsertAll(data);
    }
    //Updateを実行
    public void DBUpdate(BaseSqliteModel data)
    {
        _connection.Update(data);
    }
    //データを一覧で取得
    public List<T> DBSelectAll<T>() where T : new()
    {
        return _connection.Table<T>().ToList();
    }
}
