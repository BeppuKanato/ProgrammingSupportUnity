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
