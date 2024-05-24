using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public abstract class BaseHomeProcess : MonoBehaviour, StateProcessInterface
{
    [SerializeField]
    GameObject buttons;     //�\������{�^�����q�Ɏ��I�u�W�F�N�g
    [SerializeField]
    HomeUIStateEnum state;  //�N���X��������S��������

    [SerializeField]
    Vector3 nonDisplayPos = new Vector3(-780, 0, 0);  //UI��\������ʒu
    [SerializeField]
    Vector3 displayPos = new Vector3(-420, 0, 0);     //��\���̎���UI�̈ʒu

    LerpAnims lerpAnims;
    [SerializeField]
    protected HomeUIStateEnum nextState; //Process�����ŕԂ����

    void Awake()
    {
        this.lerpAnims = new LerpAnims();
    }
    public virtual void Enter()
    {
        //process�ŕԂ���Ԃ������̏�Ԃɐݒ�
        nextState = state;
        buttons.SetActive(true);
        Debug.Log($"{lerpAnims}");
        StartCoroutine(this.lerpAnims.LerpLocalPositionCoroutine(nonDisplayPos, displayPos, buttons));
    }

    public virtual int Process()
    {
        return (int)this.nextState;
    }

    public virtual void Exit() 
    {
        buttons.SetActive(false);
    }

    public virtual int GetState()
    {
        return (int)this.state;
    }
}
