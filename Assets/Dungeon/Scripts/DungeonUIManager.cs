using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//共通するUIの処理を行う
public class DungeonUIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text descriptionText;       //問題の説明を表示するテキスト
    [SerializeField]
    TMP_Text questionContentText;   //問題内容を表示するテキスト

    [SerializeField]
    RectTransform scrollViewContent;   //ScrollViewのContentのRectTransform
    
    //問題の説明テキストを設定する
    public void SetDescriptionText(string description)
    {
        this.descriptionText.SetText(description);
    }
    //問題の説明テキストをリセットする
    public void ResetDescriptionText()
    {
        this.descriptionText.SetText("");
    }

    //問題内容のテキストを設定する
    public void SetQuestionContentText(string content)
    {
        this.questionContentText.SetText(content);

        scrollViewContent.sizeDelta = new Vector2(this.questionContentText.preferredWidth, this.questionContentText.preferredHeight);
    }
    //問題内容のテキストをリセットする
    public void ResetQuestionContentText()
    {
        this.questionContentText.SetText("");
    }
}
