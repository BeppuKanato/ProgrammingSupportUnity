using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopUpButton : MonoBehaviour
{
    [SerializeField]
    PopUpAnimatoins popUpPanel;

    [SerializeField]
    float panelXScale = 0.7f;
    [SerializeField]
    float panelYScale = 0.7f;
    //ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Ìˆ—
    public void OpenPopUp()
    {
        //UI¶¬
        StartCoroutine(popUpPanel.OpenPopUpCoroutine(panelXScale, panelYScale));
    }
}
