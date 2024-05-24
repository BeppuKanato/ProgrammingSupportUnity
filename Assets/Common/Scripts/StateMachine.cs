using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IntStack stateHistory { get; private set; }  //遷移履歴を保存するスタック
    //最初の状態でのEnterを実行する
    public void InitializeProcess(StateProcessInterface first)
    {
        stateHistory = new IntStack();
        first.Enter();
        stateHistory.Push(first.GetState());    //履歴に保存
    }
    //状態の管理を行う
    public int StateManagement(StateProcessInterface current, StateProcessInterface next) 
    {
        //与えられた状態がことなる場合
        if (current.GetState() != next.GetState())
        {
            current.Exit();
            next.Enter();

            stateHistory.Push(current.GetState()); //履歴に保存

            return next.GetState();
        }
        //現在の状態の処理を実行
        int nextState = current.Process();

        return nextState;
    }
}
