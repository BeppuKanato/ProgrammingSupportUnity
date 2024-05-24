using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//UI�̕\����\�������C���ň���
public class TitleUIManager : MonoBehaviour
{
    [SerializeField]
    PopUpAnimatoins signInPopUp;    //�T�C���C���̓��͗p�|�b�v�A�b�v
    [SerializeField]
    PopUpAnimatoins signUpPopUp;    //�T�C���A�b�v�̓��͗p�|�b�v�A�b�v
    [SerializeField]
    PopUpAnimatoins authCodePopUp;  //�F�؃R�[�h���͗p�̃|�b�v�A�b�v
    [SerializeField]
    GameObject startButton;         //�Q�[�����J�n����{�^��
    [SerializeField]
    GameObject signIn_UpButton;     //�T�C���C���A�T�C���A�b�v�{�^��

    public void OpenSignInPopUp()
    {
        StartCoroutine(signInPopUp.OpenPopUpCoroutine());
    }
    public void CloseSignInPopUp()
    {
        StartCoroutine(signInPopUp.ClosePopUpCoruotine());
    }
    public void OpenSignUpPopUp()
    {
        StartCoroutine(signUpPopUp.OpenPopUpCoroutine());
    }
    public void CloseSignUpPopUp()
    {
        StartCoroutine(signUpPopUp.ClosePopUpCoruotine());
    }
    public void OpenAuthCodePopUp()
    {
        StartCoroutine(authCodePopUp.OpenPopUpCoroutine());
    }
    public void CloseAuthCodePopUp()
    {
        StartCoroutine(authCodePopUp.ClosePopUpCoruotine());
    }
    public void DisplaySingIn_UpButton()
    {
        signIn_UpButton.SetActive(true);
    }
    public void NonDisplaySignIn_UpButton()
    {
        signIn_UpButton.SetActive(false);   
    }
    public void DisplayStartButton()
    {
        startButton.SetActive(true);
    }
    public void NonDisplayStartButton()
    {
        startButton.SetActive(false);
    }
}
