using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedHanlers : MonoBehaviour
{
    //404エラー時の処理
    public void Code404Handler()
    {
        Debug.Log("サービスは終了しました");
    }
    //422エラー(,バリデーションエラーの時の処理)
    public string Code422Handler(string messageJson)
    {
        Debug.Log("送信データに問題があります");

        return messageJson;
    }
}
