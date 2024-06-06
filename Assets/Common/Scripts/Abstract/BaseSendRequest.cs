using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public abstract class BaseSendRequest : MonoBehaviour
{
    [SerializeField]
    HttpClient httpClient;
    [SerializeField]
    protected string urlEndPoint;
    //通信を要求するメソッド
    public abstract void SendRequest();
    //通信成功時のコールバック
    protected abstract void SuccessCallback(string jsonData);
    //通信失敗時のコールバック
    protected void FailedCallback(string jsonData, long statusCode)
    {
        switch (statusCode)
        {
            case 422:
                this.Code422Handler(jsonData);
                break;
        }
    }
    //422エラー(バリデートエラー)の時の処理
    protected virtual void Code422Handler(string jsonData)
    {

    }
    //Postリクエスト送信をHttpClientに要求
    protected void RequestPostToServer(string jsonData)
    {
        StartCoroutine(httpClient.PostCoroutine(urlEndPoint, jsonData, this.SuccessCallback, this.FailedCallback));
    }

    //Getリクエスト送信をHttpClientに要求
    protected void RequestGetToServer(string jsonData)
    {
        StartCoroutine(httpClient.GetCoroutine(urlEndPoint, jsonData, this.SuccessCallback, this.FailedCallback));
    }
}
