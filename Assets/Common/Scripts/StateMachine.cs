using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IntStack stateHistory { get; private set; }  //遷移履歴を保存するスタック

    private void Start()
    {
        stateHistory = new IntStack();
    }
    //引数の処理クラスのProcessを実行
    public int ExecuteProcess(StateProcessInterface currentStateProcess)
    {
        return currentStateProcess.Process();
    }
    //currentからnextへの状態遷移に必要な処理を実行
    public void ChangeState(StateProcessInterface currentStateProess, StateProcessInterface nextStateProcess)
    {
        currentStateProess.Exit();                              //現在の状態の抜ける時の処理
        nextStateProcess.Enter();                               //次の状態の入る時の処理

        this.HandleStateHistory(currentStateProess.GetStateInt(), nextStateProcess.GetStateInt());
    }
    //履歴の更新の管理を行う
    private void HandleStateHistory(int currentStateInt, int nextStateInt)
    {
        //最新の履歴を取得
        int lastInt = this.stateHistory.GetStackContent().LastOrDefault();

        //次の状態と最新の状態が同じ場合、状態を戻すと判断
        if (nextStateInt != lastInt)
        {
            stateHistory.Push(currentStateInt);
        }
        else
        {
            stateHistory.Pop();
        }
    }
}
