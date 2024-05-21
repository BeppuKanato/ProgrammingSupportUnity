using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public abstract class BaseSendData
{
    //public int id;
    //protected BaseDataClass(int id)
    //{
    //    this.id = id;
    //}
    //クラスデータをシリアライズ
    public string Serialize()
    {
        string jsonData = JsonUtility.ToJson(this);

        return jsonData;
    }
}