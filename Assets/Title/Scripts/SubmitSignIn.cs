using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SubmitSignIn :BaseSendRequest
{
    [SerializeField]
    TitleManager titleManager;
    [SerializeField]
    TitleUIManager titleUIManager;
    [SerializeField]
    SqliteManager sqliteManager;

    [SerializeField]
    TMP_InputField emailInput;
    [SerializeField]
    TMP_InputField passwordInput;

    [SerializeField]
    TMP_Text emailErrorText;
    [SerializeField]
    TMP_Text passwordErrorText;


    protected override void SendRequest()
    {
        SendData sendData = new SendData(emailInput.text, passwordInput.text);
        string sendJson = sendData.Serialize();

        this.RequestPostToServer(sendJson);
        Debug.Log("HttpClientへ要求");
    }

    protected override void SuccessCallback(string jsonData)
    {
        Debug.Log("通信に成功しました");
        //ポップアップを自動的に閉じる
        titleUIManager.CloseSignInPopUp();

        ResponceData responceData = new ResponceData();
        responceData = (ResponceData)responceData.Deserialize(jsonData);

        User userData = new User(int.Parse(responceData.id), responceData.name, responceData.email, responceData.remember_token);

        //ローカルのDBにユーザーデータを保存
        sqliteManager.DBInsert(userData);

        titleManager.SetUIAtSeccessAuth(responceData.name);
    }

    protected override void Code422Handler(string jsonData)
    {
        ValidateErrorData receiveData = new ValidateErrorData();
        receiveData = (ValidateErrorData)receiveData.Deserialize(jsonData);

        SetValidateErrorMessages(receiveData);
    }

    //バリデーションのエラーメッセージを表示
    void SetValidateErrorMessages(ValidateErrorData receiveData)
    {
        emailErrorText.text = receiveData.email == null ? "" : receiveData.email[0];
        passwordErrorText.text = receiveData.password == null ? "" : receiveData.password[0];
    }

    [Serializable]
    private class SendData : BaseSendData 
    {
        public string email;
        public string password;

        public SendData(string email, string password)
        {
            this.email = email;
            this.password = password;
        }       
    }
    [Serializable]
    private class ValidateErrorData : BaseReceiveData
    {
        public string[] email;
        public string[] password;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            ValidateErrorData receiveData = (ValidateErrorData)JsonUtility.FromJson<ValidateErrorData>(jsonData);

            return receiveData;
        }
    }
    [Serializable]
    private class ResponceData : BaseReceiveData
    {
        public string id;
        public string email;
        public string name;
        public string remember_token;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            ResponceData responceData = (ResponceData)JsonUtility.FromJson<ResponceData>(jsonData);

            return responceData;
        }
    }
}
