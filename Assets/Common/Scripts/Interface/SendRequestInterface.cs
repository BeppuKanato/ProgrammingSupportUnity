using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SendRequestInterface
{
    //HttpClient�̃��\�b�h���Ăяo��(�ʐM�{��)
    public void SendRequest();
    //�������̃R�[���o�b�N
    public void SuccessCallback(string jsonData);
    //���s���̃R�[���o�b�N
    public void FailedCallback(string jsonData, long statusCode);
}
