using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedHanlers : MonoBehaviour
{
    //404�G���[���̏���
    public void Code404Handler()
    {
        Debug.Log("�T�[�r�X�͏I�����܂���");
    }
    //422�G���[(,�o���f�[�V�����G���[�̎��̏���)
    public string Code422Handler(string messageJson)
    {
        Debug.Log("���M�f�[�^�ɖ�肪����܂�");

        return messageJson;
    }
}
