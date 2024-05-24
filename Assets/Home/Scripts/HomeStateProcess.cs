using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeStateProcess : BaseHomeProcess
{
    //次の状態をLearningModeにするメソッド
    public void ChangeNextStateToLearnMode()
    {
        this.nextState = HomeUIStateEnum.LerningMode;
        Debug.Log("changeToLearning");
    }

    //次の状態をConnectModeにするメソッド
    public void ChangeNextStateToConnection()
    {
        this.nextState = HomeUIStateEnum.Connection;
    }
}
