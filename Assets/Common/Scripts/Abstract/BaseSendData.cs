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
    //�N���X�f�[�^���V���A���C�Y
    public string Serialize()
    {
        string jsonData = JsonUtility.ToJson(this);

        return jsonData;
    }
}