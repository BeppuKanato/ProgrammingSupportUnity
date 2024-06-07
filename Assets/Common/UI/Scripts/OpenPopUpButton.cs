using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopUpButton : MonoBehaviour
{
    [SerializeField]
    PopUpAnimatoins popUpPanel;
    //ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Ìˆ—
    public void OpenPopUp()
    {
        //UI¶¬
        StartCoroutine(popUpPanel.OpenPopUpCoroutine());
    }
}
