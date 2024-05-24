using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SubmitAuthCode : BaseSendRequest
{
    [SerializeField]
    TitleUIManager titleUIManager;

    [SerializeField]
    TMP_InputField emailInput;
    [SerializeField]
    TMP_InputField codeInput;

    [SerializeField]
    TMP_Text emailErrorText;
    [SerializeField]
    TMP_Text codeErrorText;
    protected override void SendRequest()
    {
        SendData sendData = new SendData(emailInput.text, codeInput.text);

        string sendJson = sendData.Serialize();

        this.RequestPostToServer(sendJson);
    }

    protected override void SuccessCallback(string jsonData)
    {
        Debug.Log("í êMÇ…ê¨å˜ÇµÇ‹ÇµÇΩ");
        titleUIManager.CloseAuthCodePopUp();
    }

    protected override void Code422Handler(string jsonData)
    {
        ValidateErrorData receiveData = new ValidateErrorData();
        receiveData = (ValidateErrorData)receiveData.Deserialize(jsonData);

        SetValidateErrorMessage(receiveData);
    }

    void SetValidateErrorMessage(ValidateErrorData receiveData)
    {
        emailErrorText.text = receiveData.email == null ? "" : receiveData.email[0];
        codeErrorText.text = receiveData.code == null ? "" : receiveData.code[0];
    }

    [Serializable]
    private class SendData : BaseSendData
    {
        public string email;
        public string code;

        public SendData(string email, string code)
        {
            this.email = email;
            this.code = code;
        }
    }

    [Serializable]
    private class ValidateErrorData : BaseReceiveData
    {
        public string[] email;
        public string[] code;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            ValidateErrorData receiveData = (ValidateErrorData)JsonUtility.FromJson<ValidateErrorData>(jsonData);

            return receiveData;
        }
    }
}
