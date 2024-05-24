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
    TitleUIManager titleUIManager;

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

    //�{�^���������ꂽ���ʐM���s��
    protected override void SendRequest()
    {
        Debug.Log("signUP");
        SendData sendData = new SendData(this.nameInput.text, this.emailInput.text, this.passwordInput.text, this.checkPassordInput.text);
        string sendJson = sendData.Serialize();

        this.RequestPostToServer(sendJson);
    }
    //�ʐM�������̃R�[���o�b�N
    protected override void SuccessCallback(string jsonData)
    {
        Debug.Log("�ʐM�ɐ������܂���");
        //�|�b�v�A�b�v�������I�ɕ���

        titleUIManager.CloseSignUpPopUp();
        titleUIManager.OpenAuthCodePopUp();
    }

    protected override void Code422Handler(string jsonData)
    {
        ValidateErrorData receiveData = new ValidateErrorData();
        receiveData = (ValidateErrorData)receiveData.Deserialize(jsonData);

        SetValidateErrorMessages(receiveData);
    }

    //�o���f�[�V�����̃G���[���b�Z�[�W��\��
    void SetValidateErrorMessages(ValidateErrorData receiveData)
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
    private class ValidateErrorData : BaseReceiveData
    {
        public string[] name;
        public string[] email;
        public string[] password;
        public string[] checkPassword;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            Debug.Log(jsonData);
            ValidateErrorData receiveData = JsonUtility.FromJson<ValidateErrorData>(jsonData);

            return receiveData;
        }
    }
}
