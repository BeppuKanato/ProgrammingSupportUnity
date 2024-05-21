using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SendRequestInterface
{
    //HttpClientのメソッドを呼び出す(通信本体)
    public void SendRequest();
    //成功時のコールバック
    public void SuccessCallback(string jsonData);
    //失敗時のコールバック
    public void FailedCallback(string jsonData, long statusCode);
}
