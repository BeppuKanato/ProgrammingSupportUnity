using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//���ʂ���UI�̏������s��
public class DungeonUIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text descriptionText;       //���̐�����\������e�L�X�g
    [SerializeField]
    TMP_Text questionContentText;   //�����e��\������e�L�X�g

    [SerializeField]
    RectTransform scrollViewContent;   //ScrollView��Content��RectTransform
    
    //���̐����e�L�X�g��ݒ肷��
    public void SetDescriptionText(string description)
    {
        this.descriptionText.SetText(description);
    }
    //���̐����e�L�X�g�����Z�b�g����
    public void ResetDescriptionText()
    {
        this.descriptionText.SetText("");
    }

    //�����e�̃e�L�X�g��ݒ肷��
    public void SetQuestionContentText(string content)
    {
        this.questionContentText.SetText(content);

        scrollViewContent.sizeDelta = new Vector2(this.questionContentText.preferredWidth, this.questionContentText.preferredHeight);
    }
    //�����e�̃e�L�X�g�����Z�b�g����
    public void ResetQuestionContentText()
    {
        this.questionContentText.SetText("");
    }
}
