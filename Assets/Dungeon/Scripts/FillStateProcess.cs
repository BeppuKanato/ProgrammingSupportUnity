using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillStateProcess : BaseDungeonProcess
{
    //穴の個数分の回答入力用テキスト
    List<TMP_InputField> answerFields;
    //穴の番号のリスト
    List<int> blanckNumbers;

    //InputFieldの表示非表示を設定する
    private void SetEnableAnserFields()
    {
        //入力フィールドの個数ループ
        for (int i = 0; i < answerFields.Count; i++)
        {
            //入力フィールドよりも必要な回答が多い場合
            if (answerFields.Count < this.blanckNumbers.Count)
            {
                Debug.LogError("穴の数が上限を超えています");
                break;
            }
            //i番目の回答が必要な時
            if (i < this.blanckNumbers.Count)
            {
                answerFields[i].enabled = true;
            }
            else
            {
                answerFields[i].enabled = false;
            }
        }
    }
    //Fill形式で必要なデータを取り出す
    public override void PickUpNeedData(DungeonDataStruct dungeonData)
    {
        base.PickUpNeedData(dungeonData);

        Debug.Log("Fill形式のデータを取得します");
        this.blanckNumbers = new List<int>(dungeonData.blank_number);

        this.SetEnableAnserFields();
    }
}
