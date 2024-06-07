using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDungeonProcess : MonoBehaviour, StateProcessInterface
{
    [SerializeField]
    DungeonUIManager dungeonUIManager;              //ダンジョンシーンで共通のUIの処理を行う
    [SerializeField]
    DungeonStateEnum state;                         //クラスが処理を担当する状態
    [SerializeField]
    protected DungeonStateEnum nextState;           //Process処理で返す状態

    [SerializeField]
    protected List<string> answerContents;          //答えの文字列リスト

    [SerializeField]
    protected QuestionTypeEnum nextQuestionType;    //次の問題の形式

    public virtual void Enter()
    {
        //processで返す状態を自分に設定
        //状態の変更が無い場合は次の状態が自分になるように
        nextState = state;
    }

    public virtual int Process()
    {
        return (int)this.nextState;
    }

    public virtual void Exit()
    {

    }

    public virtual int GetState()
    {
        return (int)this.state;
    }

    //次の状態を決定する、状態列挙体のint型を返す
    protected int DecideNextState()
    {
        DungeonStateEnum result = DungeonStateEnum.None;
        switch (nextQuestionType)
        {
            case QuestionTypeEnum.Select:
                result = DungeonStateEnum.Select;
                break;
            case QuestionTypeEnum.Input:
                result = DungeonStateEnum.Input;
                break;
            case QuestionTypeEnum.Fill:
                result = DungeonStateEnum.Fill;
                break;
        }

        return (int)result;
    }

    //必要な情報を問題データから抜き出す
    public virtual void PickUpNeedData(DungeonDataStruct dungeonData)
    {
        this.answerContents = new List<string>(dungeonData.answer_content);

        this.SetDescription(dungeonData.question_description);
        this.SetQuestionContent(dungeonData.question_content);
    }

    //Descriptionを設定
    private void SetDescription(string description)
    {
        this.dungeonUIManager.SetDescriptionText(description);
    }
    //QuestinoContentを設定
    private void SetQuestionContent(string content)
    {
        this.dungeonUIManager.SetQuestionContentText(content);
    }
}
