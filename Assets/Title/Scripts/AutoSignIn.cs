using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoSignIn : BaseSendRequest
{
    [SerializeField]
    SqliteManager sqliteManager;
    [SerializeField]
    TitleUIManager titleUIManager;
    [SerializeField]
    TitleManager titleManager;

    User userData;

    //ユーザデータを取得するコルーチン
    public IEnumerator GetUserDataCotourine()
    {
        userData = sqliteManager.DBSelectAll<User>()[0];

        yield return new WaitUntil(() => userData != null);

        //データを取得できたら、コールバックを実行

        Debug.Log($"id = {userData.id}, remember_token = {userData.remember_token}");

        this.SendRequest();
    }

    //RememberTokenが正しいものかを確認
    public override void SendRequest()
    {
        SendData sendData = new SendData(userData.id.ToString(), userData.remember_token);
        string sendJson = sendData.Serialize();

        Debug.Log(sendJson);

        this.RequestPostToServer(sendJson);
    }
    //通信成功時のコールバック
    protected override void SuccessCallback(string jsonData)
    {
        titleManager.SetUIAtSeccessAuth(userData.name);
    }

    //通信失敗時のコールバック
    protected override void Code422Handler(string jsonData)
    {
        titleManager.SetUIAtFailedAuth();
    }

    [Serializable]
    private class SendData : BaseSendData
    {
        public string id;
        public string rememberToken;

        public SendData(string id, string rememberToken)
        {
            this.id = id;
            this.rememberToken = rememberToken;
        }
    }
}
