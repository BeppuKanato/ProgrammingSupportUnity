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
    //�ʐM��v�����郁�\�b�h
    public abstract void SendRequest();
    //�ʐM�������̃R�[���o�b�N
    protected abstract void SuccessCallback(string jsonData);
    //�ʐM���s���̃R�[���o�b�N
    protected void FailedCallback(string jsonData, long statusCode)
    {
        switch (statusCode)
        {
            case 422:
                this.Code422Handler(jsonData);
                break;
        }
    }
    //422�G���[(�o���f�[�g�G���[)�̎��̏���
    protected virtual void Code422Handler(string jsonData)
    {

    }
    //Post���N�G�X�g���M��HttpClient�ɗv��
    protected void RequestPostToServer(string jsonData)
    {
        StartCoroutine(httpClient.PostCoroutine(urlEndPoint, jsonData, this.SuccessCallback, this.FailedCallback));
    }

    //Get���N�G�X�g���M��HttpClient�ɗv��
    protected void RequestGetToServer(string jsonData)
    {
        StartCoroutine(httpClient.GetCoroutine(urlEndPoint, jsonData, this.SuccessCallback, this.FailedCallback));
    }
}
