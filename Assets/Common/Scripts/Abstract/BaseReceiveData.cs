using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReceiveData
{
    //json�f�[�^���f�V���A���C�Y
    public abstract BaseReceiveData Deserialize(string jsonData);
}
