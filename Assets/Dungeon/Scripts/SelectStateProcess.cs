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

    public override void Enter()
    {
        base.Enter();
    }

    //選択肢のボタンが押されたときの処理
    public void OnClickBranchButton(TMP_Text buttonText)
    {
        //押されたボタンの文字と正解の文字列が同じ時
        if (buttonText.text == this.answerContents[0])
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
        }
    }

    //選択肢のボタンのテキストを設定する
    private void FillBranchText()
    {
        for (int i = 0; i < branchButtonTexts.Count; i++)
        {
            //選択肢の内容がある場合
            if (i < branchContents.Count)
            {
                branchButtonTexts[i].SetText(branchContents[i]);
                branchButtonTexts[i].gameObject.SetActive(true);
            }
            //選択肢の内容が無い場合
            else
            {
                branchButtonTexts[i].gameObject.SetActive(false);
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
