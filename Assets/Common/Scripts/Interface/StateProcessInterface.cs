using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状態での処理定義インターフェース
public interface StateProcessInterface
{
    public void Enter();    //状態に入った時の処理
    public int Process();  //状態中の処理
    public void Exit();     //状態が終了する時の処理
    public int GetState();  //状態を返す
}
