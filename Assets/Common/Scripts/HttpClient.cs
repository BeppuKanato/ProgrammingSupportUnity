using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    //成功時のデリゲート
    public delegate void SuccessDelegate(string responceJson);
    //失敗時のデリゲート
    public delegate void FailedDelegate(string responceJson, long statusCode);

    public string baseURL = "http://localhost/api/";

    FailedHanlers errorHandlers = new FailedHanlers();

    //httpのポストメソッドを実行
    public IEnumerator PostCoroutine(string urlEndPoint, string jsonData, SuccessDelegate successCallback, FailedDelegate failedCallback)
    {
        Debug.Log(jsonData);
        ////jsonデータをバイトデータに変換
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

        string url = baseURL + urlEndPoint;

        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, "application/json"))
        {
            www.uploadHandler = new UploadHandlerRaw(jsonBytes);
            www.downloadHandler = new DownloadHandlerBuffer();

            Coroutine checkProgressCoroutine = StartCoroutine(CheckProgressCoroutine(www));

            //ポストリクエストを送信
            yield return www.SendWebRequest();

            //通信終了
            AfterConnectHandler(www, successCallback, failedCallback);

            //進捗表示コルーチンを終了
            StopCoroutine(checkProgressCoroutine);
        }
    }
    //httpのGetメソッドを実行
    public IEnumerator GetCoroutine(string urlEndPoint, string jsonData, SuccessDelegate successCallBack, FailedDelegate failedCallBack)
    {
        //jsonデータをバイトデータに変換
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
        //url
        string url = baseURL + urlEndPoint;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.uploadHandler = new UploadHandlerRaw(jsonBytes);
            www.downloadHandler = new DownloadHandlerBuffer();

            //ポストリクエストを送信
            yield return www.SendWebRequest();

            //通信終了
            AfterConnectHandler(www, successCallBack, failedCallBack);
        }
    }

    //送信完了後の処理
    private void AfterConnectHandler(UnityWebRequest www, SuccessDelegate successCallBack, FailedDelegate failCallBack)
    {
        if (www.result == UnityWebRequest.Result.Success)
        {
            this.SuccessHandler(www.downloadHandler.text, successCallBack);
        }
        else
        {
            this.FaildHandler(www, failCallBack);
        }
    }
    //通信成功時の処理
    private void SuccessHandler(string responceJson, SuccessDelegate successCallBack)
    {
        Debug.Log(responceJson);
        successCallBack(responceJson);
    }

    //通信失敗時の処理
    private void FaildHandler(UnityWebRequest www, FailedDelegate failCallBack)
    {
        switch(www.responseCode)
        {
            //サイトが存在しないエラー
            case 404:
                break;
            //入力された情報が正しくない時
            case 422:
                string messageJson = errorHandlers.Code422Handler(www.downloadHandler.text);
                failCallBack(messageJson, www.responseCode);
                break;
            default:
                Debug.Log("対策していない例外が発生しました");
                Debug.Log($"ステータスコード = {www.responseCode}");
                break;
        }
    }

    private IEnumerator CheckProgressCoroutine(UnityWebRequest www)
    {
        while (!www.isDone)
        {
            Debug.Log($"uploadProgress = {www.uploadProgress} downloadProgress = {www.downloadProgress}");
            float totalProgress = (www.uploadProgress + www.downloadProgress) / 2.0f;

            Debug.Log(totalProgress);

            yield return null;
        }
    }
}
