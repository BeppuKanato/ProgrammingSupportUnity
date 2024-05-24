using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IntStack
{
    public int ERROR_NUMBER = -99;
    List<int> stack;

    public IntStack()
    {
        stack = new List<int>();
    }

    //�X�^�b�N�Ƀv�b�V������
    public void Push(int n)
    {
        stack.Add(n);
    }

    //�X�^�b�N����|�b�v����
    public int Pop()
    {
        if (stack.Count < 1)
        {
            Debug.LogError("�X�^�b�N�͋�ł�");
            return this.ERROR_NUMBER;
        }

        int result = stack.Last();
        stack.RemoveAt(stack.Count - 1);

        return result;
    }
    //�X�^�b�N�����Z�b�g����
    public void ResetStack()
    {
        stack.Clear();
    }
    //�X�^�b�N�̓��e��Ԃ�
    public List<int> GetStackContent()
    {
        return new List<int>(stack);
    }
    //�X�^�b�N�̒�����Ԃ�
    public int GetStackCount()
    {
        return stack.Count;
    }
}
