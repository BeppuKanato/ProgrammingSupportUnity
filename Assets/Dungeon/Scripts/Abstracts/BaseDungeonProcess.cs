using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class BaseDungeonProcess : MonoBehaviour, StateProcessInterface
{
    [field: SerializeField]
    public DungeonManager dungeonManager { get; private set; }
    [SerializeField]
    DungeonUIManager dungeonUIManager;              //ダンジョンシーンで共通のUIの処理を行う
    [field: SerializeField]
    protected DungeonStateEnum state; //クラスが処理を担当する状態
    [SerializeField]
    protected DungeonStateEnum nextState;           //Process処理で返す状態

    [SerializeField]
    protected List<string> answerContents;          //答えの文字列リスト

    [SerializeField]
    protected QuestionTypeEnum nextQuestionType = QuestionTypeEnum.Input;    //次の問題の形式

    LerpAnims lerpAnims = new LerpAnims();

    [SerializeField]
    Image correctImage;
    [SerializeField]
    Image inCorrectImage;

    protected virtual void Start()
    {
        
    }
    public virtual void Enter()
    {
        this.nextState = state;
    }

    public virtual int Process()
    {
        return (int)this.nextState;
    }

    public virtual void Exit()
    {

    }

    public virtual int GetStateInt()
    {
        return (int)this.state;
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

    /// <summary>
    /// 回答が正解の場合の処理です
    /// </summary>
    protected void ResultCorrect()
    {
        Vector3 targetScale = new Vector3(2, 2);
        this.correctImage.gameObject.SetActive(true);
        StartCoroutine(this.lerpAnims.LerpScaleCoroutine(this.correctImage.gameObject.transform.localScale, targetScale, this.correctImage.gameObject, () =>
        {
            this.correctImage.gameObject.SetActive(false);
            this.correctImage.gameObject.transform.localScale = Vector3.zero;

            //次の状態に遷移する
            this.nextState = DungeonStateEnum.ChangeQuestion;
        }));
    }

    /// <summary>
    /// 回答が不正解の場合の処理です
    /// </summary>
    protected void ResultInCorrect()
    {
        Vector3 targetScale = new Vector3(2, 2);
        this.inCorrectImage.gameObject.SetActive(true);
        StartCoroutine(this.lerpAnims.LerpScaleCoroutine(this.inCorrectImage.transform.localScale, targetScale, this.inCorrectImage.gameObject, () =>
        {
            this.inCorrectImage.gameObject.SetActive(false);
            this.inCorrectImage.gameObject.transform.localScale = Vector3.zero;
        }));
    }
}
