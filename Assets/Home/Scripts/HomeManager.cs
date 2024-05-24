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
        //ステートマシーンを実行、次に進む状態が返ってくる
        HomeUIStateEnum resultState = (HomeUIStateEnum)stateMachine.StateManagement(processes[currentState], processes[nextState]);

        //processの実行によって進む状態が変化した場合
        if (nextState != resultState)
        {
            //nextを次状態に設定
            nextState = resultState;
        }
        else
        {
            currentState = resultState;
        }
    }
    //辞書型配列にプロセスを設定
    private void SetProcessesDictionary()
    {
        processes.Add(HomeUIStateEnum.Home, homeStateProcess);
        processes.Add(HomeUIStateEnum.LerningMode, learningModeProcess);
    }

    //状態を一つ前に戻す
    public void ChangeToPreveState()
    {
        int nextStateInt = stateMachine.stateHistory.Pop();

        nextState = nextStateInt != stateMachine.stateHistory.ERROR_NUMBER ? (HomeUIStateEnum)nextStateInt : nextState;

        Debug.Log($"nextState = {nextState}");
    }
}
