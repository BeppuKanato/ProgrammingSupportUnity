using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
public class User : BaseSqliteModel
{
    [PrimaryKey]
    public int id { get; private set; }
    public string name { get; private set; }
    public string email { get; private set; }
    public string remember_token {  get; private set; }

    //パラメータのないコンストラクタ
    public User()
    {

    }

    public User(int id, string name, string email, string remember_token)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.remember_token = remember_token;
    }
}



