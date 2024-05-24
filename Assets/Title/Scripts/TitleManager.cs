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
    TMP_Text statusText;        //��Ԃ�\������e�L�X�g

    private void Start()
    {
        StartCoroutine(autoSignIn.GetUserDataCotourine());
    }
    //�F�؂ɐ��������ꍇ��UI�\��
    public void SetUIAtSeccessAuth(string name)
    {
        titleUIManager.DisplayStartButton();
        statusText.text = $"�悤����{name}����";
    }
    //�F�؂Ɏ��s�����ꍇ��UI�\��
    public void SetUIAtFailedAuth()
    {
        titleUIManager.DisplaySingIn_UpButton();
        statusText.text = "���[�U�F�؂Ɏ��s���܂����A�ēx�T�C���C�����Ă�������";
    }
}
