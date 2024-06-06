using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReceiveData
{
    //jsonデータをデシリアライズ
    public virtual BaseReceiveData Deserialize(string jsonData) { return null; }
    //複数要素のjsonデータをデシリアライズ
    //public virtual List<BaseReceiveData> DeserializeToList(string jsonData) { return null; }
}
