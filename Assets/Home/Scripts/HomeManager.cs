using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [SerializeField]
    HomeUIStateEnum currentState;
    [SerializeField]
    HomeUIStateEnum nextState;

    [SerializeField]
    HomeStateProcess homeStateProcess;
    [SerializeField]
    LearningModeStateProcess learningModeProcess;
    [SerializeField]
    StateMachine stateMachine;

    Dictionary<HomeUIStateEnum, BaseHomeProcess> processes;
    // Start is called before the first frame update

    private void Awake()
    {
        processes = new Dictionary<HomeUIStateEnum, BaseHomeProcess>();
    }
    void Start()
    {
        SetProcessesDictionary();

        currentState = HomeUIStateEnum.Home;
        nextState = currentState;

        stateMachine.InitializeProcess(processes[currentState]);
    }
    void Update()
    {
        //�X�e�[�g�}�V�[�������s�A���ɐi�ޏ�Ԃ��Ԃ��Ă���
        HomeUIStateEnum resultState = (HomeUIStateEnum)stateMachine.StateManagement(processes[currentState], processes[nextState]);

        //process�̎��s�ɂ���Đi�ޏ�Ԃ��ω������ꍇ
        if (nextState != resultState)
        {
            //next������Ԃɐݒ�
            nextState = resultState;
        }
        else
        {
            currentState = resultState;
        }
    }
    //�����^�z��Ƀv���Z�X��ݒ�
    private void SetProcessesDictionary()
    {
        processes.Add(HomeUIStateEnum.Home, homeStateProcess);
        processes.Add(HomeUIStateEnum.LerningMode, learningModeProcess);
    }

    //��Ԃ���O�ɖ߂�
    public void ChangeToPreveState()
    {
        int nextStateInt = stateMachine.stateHistory.Pop();

        nextState = nextStateInt != stateMachine.stateHistory.ERROR_NUMBER ? (HomeUIStateEnum)nextStateInt : nextState;

        Debug.Log($"nextState = {nextState}");
    }
}
