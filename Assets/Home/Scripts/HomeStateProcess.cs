using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomeStateProcess : BaseHomeProcess
{
    //���̏�Ԃ�LearningMode�ɂ��郁�\�b�h
    public void ChangeNextStateToLearnMode()
    {
        this.nextState = HomeUIStateEnum.LerningMode;
        Debug.Log("changeToLearning");
    }

    //���̏�Ԃ�ConnectMode�ɂ��郁�\�b�h
    public void ChangeNextStateToConnection()
    {
        this.nextState = HomeUIStateEnum.Connection;
    }
}
