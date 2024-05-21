using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PopUpCloseButton : MonoBehaviour
{
    //ポップアップを閉じる
    public void ClosePopUp(PopUpAnimatoins popUpAnimations)
    {
        StartCoroutine(popUpAnimations.ClosePopUpCoruotine());
    }
}
