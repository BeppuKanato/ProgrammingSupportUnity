using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPopUpButton : MonoBehaviour
{
    [SerializeField]
    PopUpAnimatoins popUpPanel;
    //�{�^���������ꂽ���̏���
    public void OpenPopUp()
    {
        //UI����
        StartCoroutine(popUpPanel.OpenPopUpCoroutine());
    }
}
