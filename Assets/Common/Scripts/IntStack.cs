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

    //スタックにプッシュする
    public void Push(int n)
    {
        stack.Add(n);
    }

    //スタックからポップする
    public int Pop()
    {
        if (stack.Count < 1)
        {
            Debug.LogError("スタックは空です");
            return this.ERROR_NUMBER;
        }

        int result = stack.Last();
        stack.RemoveAt(stack.Count - 1);

        return result;
    }
    //スタックをリセットする
    public void ResetStack()
    {
        stack.Clear();
    }
    //スタックの内容を返す
    public List<int> GetStackContent()
    {
        return new List<int>(stack);
    }
    //スタックの長さを返す
    public int GetStackCount()
    {
        return stack.Count;
    }
}
