using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ԃł̏�����`�C���^�[�t�F�[�X
public interface StateProcessInterface
{
    public void Enter();    //��Ԃɓ��������̏���
    public int Process();  //��Ԓ��̏���
    public void Exit();     //��Ԃ��I�����鎞�̏���
    public int GetState();  //��Ԃ�Ԃ�
}
