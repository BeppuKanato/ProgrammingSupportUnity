using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    //�������̃f���Q�[�g
    public delegate void SuccessDelegate(string responceJson);
    //���s���̃f���Q�[�g
    public delegate void FailedDelegate(string responceJson, long statusCode);

    public string baseURL = "http://localhost/api/";

    FailedHanlers errorHandlers = new FailedHanlers();

    //http�̃|�X�g���\�b�h�����s
    public IEnumerator PostCoroutine(string urlEndPoint, string jsonData, SuccessDelegate successCallback, FailedDelegate failedCallback)
    {
        Debug.Log(jsonData);
        ////json�f�[�^���o�C�g�f�[�^�ɕϊ�
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

        string url = baseURL + urlEndPoint;

        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, "application/json"))
        {
            www.uploadHandler = new UploadHandlerRaw(jsonBytes);
            www.downloadHandler = new DownloadHandlerBuffer();

            Coroutine checkProgressCoroutine = StartCoroutine(CheckProgressCoroutine(www));

            //�|�X�g���N�G�X�g�𑗐M
            yield return www.SendWebRequest();

            //�ʐM�I��
            AfterConnectHandler(www, successCallback, failedCallback);

            //�i���\���R���[�`�����I��
            StopCoroutine(checkProgressCoroutine);
        }
    }
    //http��Get���\�b�h�����s
    public IEnumerator GetCoroutine(string urlEndPoint, string jsonData, SuccessDelegate successCallBack, FailedDelegate failedCallBack)
    {
        //json�f�[�^���o�C�g�f�[�^�ɕϊ�
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
        //url
        string url = baseURL + urlEndPoint;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.uploadHandler = new UploadHandlerRaw(jsonBytes);
            www.downloadHandler = new DownloadHandlerBuffer();

            //�|�X�g���N�G�X�g�𑗐M
            yield return www.SendWebRequest();

            //�ʐM�I��
            AfterConnectHandler(www, successCallBack, failedCallBack);
        }
    }

    //���M������̏���
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
    //�ʐM�������̏���
    private void SuccessHandler(string responceJson, SuccessDelegate successCallBack)
    {
        Debug.Log(responceJson);
        successCallBack(responceJson);
    }

    //�ʐM���s���̏���
    private void FaildHandler(UnityWebRequest www, FailedDelegate failCallBack)
    {
        switch(www.responseCode)
        {
            //�T�C�g�����݂��Ȃ��G���[
            case 404:
                break;
            //���͂��ꂽ��񂪐������Ȃ���
            case 422:
                string messageJson = errorHandlers.Code422Handler(www.downloadHandler.text);
                failCallBack(messageJson, www.responseCode);
                break;
            default:
                Debug.Log("�΍􂵂Ă��Ȃ���O���������܂���");
                Debug.Log($"�X�e�[�^�X�R�[�h = {www.responseCode}");
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
