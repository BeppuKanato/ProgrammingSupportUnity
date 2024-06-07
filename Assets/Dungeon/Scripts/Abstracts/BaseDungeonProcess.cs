using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDungeonProcess : MonoBehaviour, StateProcessInterface
{
    [SerializeField]
    DungeonUIManager dungeonUIManager;              //�_���W�����V�[���ŋ��ʂ�UI�̏������s��
    [SerializeField]
    DungeonStateEnum state;                         //�N���X��������S��������
    [SerializeField]
    protected DungeonStateEnum nextState;           //Process�����ŕԂ����

    [SerializeField]
    protected List<string> answerContents;          //�����̕����񃊃X�g

    [SerializeField]
    protected QuestionTypeEnum nextQuestionType;    //���̖��̌`��

    public virtual void Enter()
    {
        //process�ŕԂ���Ԃ������ɐݒ�
        //��Ԃ̕ύX�������ꍇ�͎��̏�Ԃ������ɂȂ�悤��
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

    //���̏�Ԃ����肷��A��ԗ񋓑̂�int�^��Ԃ�
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

    //�K�v�ȏ�����f�[�^���甲���o��
    public virtual void PickUpNeedData(DungeonDataStruct dungeonData)
    {
        this.answerContents = new List<string>(dungeonData.answer_content);

        this.SetDescription(dungeonData.question_description);
        this.SetQuestionContent(dungeonData.question_content);
    }

    //Description��ݒ�
    private void SetDescription(string description)
    {
        this.dungeonUIManager.SetDescriptionText(description);
    }
    //QuestinoContent��ݒ�
    private void SetQuestionContent(string content)
    {
        this.dungeonUIManager.SetQuestionContentText(content);
    }
}
