using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReceiveData
{
    //jsonデータをデシリアライズ
    public abstract BaseReceiveData Deserialize(string jsonData);
}
