using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//UIの表示非表示をメインで扱う
public class TitleUIManager : MonoBehaviour
{
    [SerializeField]
    PopUpAnimatoins signInPopUp;    //サインインの入力用ポップアップ
    [SerializeField]
    PopUpAnimatoins signUpPopUp;    //サインアップの入力用ポップアップ
    [SerializeField]
    PopUpAnimatoins authCodePopUp;  //認証コード入力用のポップアップ
    [SerializeField]
    GameObject startButton;         //ゲームを開始するボタン
    [SerializeField]
    GameObject signIn_UpButton;     //サインイン、サインアップボタン

    [SerializeField]
    float panelXScale = 0.6f;
    [SerializeField]
    float panelYScale = 0.6f;

    public void OpenSignInPopUp()
    {
        StartCoroutine(signInPopUp.OpenPopUpCoroutine(panelXScale, panelYScale));
    }
    public void CloseSignInPopUp()
    {
        StartCoroutine(signInPopUp.ClosePopUpCoruotine());
    }
    public void OpenSignUpPopUp()
    {
        StartCoroutine(signUpPopUp.OpenPopUpCoroutine(panelXScale, panelYScale));
    }
    public void CloseSignUpPopUp()
    {
        StartCoroutine(signUpPopUp.ClosePopUpCoruotine());
    }
    public void OpenAuthCodePopUp()
    {
        StartCoroutine(authCodePopUp.OpenPopUpCoroutine(panelXScale, panelYScale));
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
