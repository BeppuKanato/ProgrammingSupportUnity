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

    //���[�U�f�[�^���擾����R���[�`��
    public IEnumerator GetUserDataCotourine()
    {
        userData = sqliteManager.DBSelectAll<User>()[0];

        yield return new WaitUntil(() => userData != null);

        //�f�[�^���擾�ł�����A�R�[���o�b�N�����s

        Debug.Log($"id = {userData.id}, remember_token = {userData.remember_token}");

        this.SendRequest();
    }

    //RememberToken�����������̂����m�F
    public override void SendRequest()
    {
        SendData sendData = new SendData(userData.id.ToString(), userData.remember_token);
        string sendJson = sendData.Serialize();

        Debug.Log(sendJson);

        this.RequestPostToServer(sendJson);
    }
    //�ʐM�������̃R�[���o�b�N
    protected override void SuccessCallback(string jsonData)
    {
        titleManager.SetUIAtSeccessAuth(userData.name);
    }

    //�ʐM���s���̃R�[���o�b�N
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
