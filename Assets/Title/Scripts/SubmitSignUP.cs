using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class SubmitSignUP : BaseSendRequest
{
    [SerializeField]
    PopUpAnimatoins popUpPanel;
    [SerializeField]
    PopUpAnimatoins authCodePopUp;

    [SerializeField]
    TMP_InputField emailInput;
    [SerializeField]
    TMP_InputField nameInput;
    [SerializeField]
    TMP_InputField passwordInput;
    [SerializeField]
    TMP_InputField checkPassordInput;

    [SerializeField]
    TextMeshProUGUI emailErrorText;
    [SerializeField]
    TextMeshProUGUI nameErrorText;
    [SerializeField]
    TextMeshProUGUI passwordErrorText;
    [SerializeField]
    TextMeshProUGUI checkPasswordErrorText;

    //ボタンが押された時通信を行う
    protected override void SendRequest()
    {
        Debug.Log("signUP");
        SendData sendData = new SendData(this.nameInput.text, this.emailInput.text, this.passwordInput.text, this.checkPassordInput.text);
        string sendJson = sendData.Serialize();

        this.RequestPostToServer(sendJson);
    }
    //通信成功時のコールバック
    protected override void SuccessCallback(string jsonData)
    {
        Debug.Log("通信に成功しました");
        //ポップアップを自動的に閉じる
        StartCoroutine(popUpPanel.ClosePopUpCoruotine());
        StartCoroutine(authCodePopUp.OpenPopUpCoroutine());
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
        nameErrorText.text = receiveData.name == null ? "" : receiveData.name[0];
        passwordErrorText.text = receiveData.password == null ? "" : receiveData.password[0];
        checkPasswordErrorText.text = receiveData.checkPassword == null ? "" : receiveData.checkPassword[0];
    }

    [Serializable]
    private class SendData : BaseSendData
    {
        public string name;
        public string email;
        public string password;
        public string checkPassword;

        public SendData(string name, string email, string password, string checkPassword)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.checkPassword = checkPassword;
        }
    }

    [Serializable]
    private class ReceiveData : BaseReceiveData
    {
        public string[] name;
        public string[] email;
        public string[] password;
        public string[] checkPassword;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            Debug.Log(jsonData);
            ReceiveData receiveData = JsonUtility.FromJson<ReceiveData>(jsonData);

            return receiveData;
        }
    }
}
