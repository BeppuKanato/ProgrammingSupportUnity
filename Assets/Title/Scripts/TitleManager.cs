using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    TitleUIManager titleUIManager;
    [SerializeField]
    AutoSignIn autoSignIn;
    [SerializeField]
    TMP_Text statusText;        //状態を表示するテキスト

    private void Start()
    {
        StartCoroutine(autoSignIn.GetUserDataCotourine());
    }
    //認証に成功した場合のUI表示
    public void SetUIAtSeccessAuth(string name)
    {
        titleUIManager.DisplayStartButton();
        statusText.text = $"ようこそ{name}さん";
    }
    //認証に失敗した場合のUI表示
    public void SetUIAtFailedAuth()
    {
        titleUIManager.DisplaySingIn_UpButton();
        statusText.text = "ユーザ認証に失敗しました、再度サインインしてください";
    }
}
