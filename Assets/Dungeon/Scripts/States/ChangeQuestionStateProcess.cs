using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeQuestionStateProcess : BaseDungeonProcess
{
    protected override void Start()
    {
        this.state = DungeonStateEnum.ChangeQuestion;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override int Process()
    {
        this.nextState = this.DecideNextState();

        return base.Process();
    }
    public override void Exit() 
    {
        base.Exit();
    }

    private DungeonStateEnum DecideNextState()
    {
        DungeonStateEnum result = this.state;
        this.nextQuestionType = this.dungeonManager.GetNextQuestionType();
        switch (nextQuestionType)
        {
            case QuestionTypeEnum.Select:
                result = DungeonStateEnum.Select;
                this.ChengeQuestionProcess();
                break;
            case QuestionTypeEnum.Input:
                result = DungeonStateEnum.Input;
                this.ChengeQuestionProcess();
                break;
            case QuestionTypeEnum.Fill:
                result = DungeonStateEnum.Fill;
                this.ChengeQuestionProcess();
                break;
            case QuestionTypeEnum.None:
                result = DungeonStateEnum.None;
                break;
        }
        return result;
    }

    /// <summary>
    /// ñ‚ëËÇéüÇ…êiÇﬂÇÈ
    /// </summary>
    private void ChengeQuestionProcess()
    {
        this.dungeonManager.IncrementQuestionIndex();
    }
}
