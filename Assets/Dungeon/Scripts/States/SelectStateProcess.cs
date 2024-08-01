using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectStateProcess : BaseDungeonProcess
{
    [SerializeField]
    List<TMP_Text> branchButtonTexts;     //選択用のボタン
    [SerializeField]
    List<string> branchContents;    //選択肢の内容の文字列

    [SerializeField]
    GameObject choiceParent;

    protected override void Start()
    {
        this.state = DungeonStateEnum.Select;
    }
    public override void Enter()
    {
        base.Enter();
        this.PickUpNeedData(this.dungeonManager.GetNowQuestion());

        this.choiceParent.SetActive(true);
    }

    public override void Exit() 
    {
        this.choiceParent.SetActive(false); 
        base.Exit();
    }

    //選択肢のボタンが押されたときの処理
    public void OnClickBranchButton(TMP_Text buttonText)
    {
        //押されたボタンの文字と正解の文字列が同じ時
        if (buttonText.text == this.answerContents[0])
        {
            this.ResultCorrect();
        }
        else
        {
            this.ResultInCorrect();
        }
    }

    //選択肢のボタンのテキストを設定する
    private void FillBranchText()
    {
        Debug.Log("ボタンのテキストを設定します");
        for (int i = 0; i < branchButtonTexts.Count; i++)
        {
            //選択肢の数がボタンの数より多い場合
            if (branchButtonTexts.Count < branchContents.Count)
            {
                Debug.LogError("選択肢の数が上限を超えています");
                break;
            }
            //選択肢の内容がある場合
            if (i < branchContents.Count)
            {
                branchButtonTexts[i].SetText(branchContents[i]);
                branchButtonTexts[i].gameObject.transform.parent.gameObject.SetActive(true);
                Debug.Log($"i = {i}, 選択肢 = {branchContents.Count}");
                Debug.Log($"{i < branchContents.Count}");
            }
            //選択肢の内容が無い場合
            else
            {
                branchButtonTexts[i].gameObject.transform.parent.gameObject.SetActive(false);

                Debug.Log($"オーバーしています i = {i}, 選択肢 = {branchContents.Count}");
            }
        }
    }

    //Select形式の問題で必要なデータを取り出す
    public override void PickUpNeedData(DungeonDataStruct dungeonData)
    {
        base.PickUpNeedData(dungeonData);

        this.branchContents = new List<string>(dungeonData.branch_content);

        FillBranchText();
    }
}
