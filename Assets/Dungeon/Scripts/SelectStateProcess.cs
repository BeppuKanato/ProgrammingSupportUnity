using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectStateProcess : BaseDungeonProcess
{
    [SerializeField]
    List<TMP_Text> branchButtonTexts;     //�I��p�̃{�^��
    [SerializeField]
    List<string> branchContents;    //�I�����̓��e�̕�����

    public override void Enter()
    {
        base.Enter();
    }

    //�I�����̃{�^���������ꂽ�Ƃ��̏���
    public void OnClickBranchButton(TMP_Text buttonText)
    {
        //�����ꂽ�{�^���̕����Ɛ����̕����񂪓�����
        if (buttonText.text == this.answerContents[0])
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
        }
    }

    //�I�����̃{�^���̃e�L�X�g��ݒ肷��
    private void FillBranchText()
    {
        for (int i = 0; i < branchButtonTexts.Count; i++)
        {
            //�I�����̓��e������ꍇ
            if (i < branchContents.Count)
            {
                branchButtonTexts[i].SetText(branchContents[i]);
                branchButtonTexts[i].gameObject.SetActive(true);
            }
            //�I�����̓��e�������ꍇ
            else
            {
                branchButtonTexts[i].gameObject.SetActive(false);
            }
        }
    }

    //Select�`���̖��ŕK�v�ȃf�[�^�����o��
    public override void PickUpNeedData(DungeonDataStruct dungeonData)
    {
        base.PickUpNeedData(dungeonData);

        this.branchContents = new List<string>(dungeonData.branch_content);

        FillBranchText();
    }
}
