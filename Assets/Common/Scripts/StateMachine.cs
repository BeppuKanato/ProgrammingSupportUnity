using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IntStack stateHistory { get; private set; }  //�J�ڗ�����ۑ�����X�^�b�N
    //�ŏ��̏�Ԃł�Enter�����s����
    public void InitializeProcess(StateProcessInterface first)
    {
        stateHistory = new IntStack();
        first.Enter();
        stateHistory.Push(first.GetState());    //�����ɕۑ�
    }
    //��Ԃ̊Ǘ����s��
    public int StateManagement(StateProcessInterface current, StateProcessInterface next) 
    {
        //�^����ꂽ��Ԃ����ƂȂ�ꍇ
        if (current.GetState() != next.GetState())
        {
            current.Exit();
            next.Enter();

            stateHistory.Push(current.GetState()); //�����ɕۑ�

            return next.GetState();
        }
        //���݂̏�Ԃ̏��������s
        int nextState = current.Process();

        return nextState;
    }
}
