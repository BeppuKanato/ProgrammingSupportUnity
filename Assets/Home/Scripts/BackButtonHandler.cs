using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
    [SerializeField]
    HomeManager homeManager;
    //�߂�{�^���������ꂽ�Ƃ��̏���
    public void OnClickBackButton()
    {
        homeManager.ChangeToPreveState();
    }
}
