using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReceiveData
{
    //json�f�[�^���f�V���A���C�Y
    public virtual BaseReceiveData Deserialize(string jsonData) { return null; }
    //�����v�f��json�f�[�^���f�V���A���C�Y
    //public virtual List<BaseReceiveData> DeserializeToList(string jsonData) { return null; }
}
