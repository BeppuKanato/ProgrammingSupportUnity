using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubmitSignIn :BaseSendRequest
{ 
    [SerializeField]
    PopUpAnimatoins popUpPanel;

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
        StartCoroutine(popUpPanel.ClosePopUpCoruotine());
    }

    protected override void Code422Handler(string jsonData)
    {
        ReceiveData receiveData = new ReceiveData();
        receiveData = (ReceiveData)receiveData.Deserialize(jsonData);

        SetValidateErrorMessages(receiveData);
    }

    //バリデーションのエラーメッセージを表示
    void SetValidateErrorMessages(ReceiveData receiveData)
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
    private class ReceiveData : BaseReceiveData
    {
        public string[] email;
        public string[] password;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            ReceiveData receiveData = (ReceiveData)JsonUtility.FromJson<ReceiveData>(jsonData);

            return receiveData;
        }
    }
}
