using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
    [SerializeField]
    HomeManager homeManager;
    //戻るボタンを押されたときの処理
    public void OnClickBackButton()
    {
        homeManager.ChangeToPreveState();
    }
}
