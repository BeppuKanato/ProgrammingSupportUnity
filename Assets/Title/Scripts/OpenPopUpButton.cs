using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopUpButton : MonoBehaviour
{
    [SerializeField]
    PopUpAnimatoins popUpPanel;
    //ボタンが押された時の処理
    public void OpenPopUp()
    {
        //UI生成
        StartCoroutine(popUpPanel.OpenPopUpCoroutine());
    }
}
