using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStateProcess : BaseDungeonProcess
{
    protected override void Start()
    {
        this.state = DungeonStateEnum.Connect;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override int Process()
    {
        this.nextState = this.DecideNextState();
        Debug.Log($"next = {nextState}");
        return base.Process();
    }

    public override void Exit() 
    {
        base.Exit();
    }

    /// <summary>
    /// éüÇÃèÛë‘Ç÷êiÇﬁèàóùÇ≈Ç∑
    /// </summary>
    protected DungeonStateEnum DecideNextState()
    {
        DungeonStateEnum result = this.state;
        if (this.dungeonManager.SetedDungeonData())
        {
            switch ((QuestionTypeEnum)this.dungeonManager.GetNowQuestion().question_type)
            {
                case QuestionTypeEnum.Select:
                    result = DungeonStateEnum.Select;
                    break;
                case QuestionTypeEnum.Fill:
                    result = DungeonStateEnum.Fill;
                    break;
                case QuestionTypeEnum.Input:
                    result = DungeonStateEnum.Input; 
                    break; 
            }
        }
        return result;
    }
}
