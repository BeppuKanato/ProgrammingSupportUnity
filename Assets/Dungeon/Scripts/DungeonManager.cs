using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    List<DungeonDataStruct> dungeonData = new List<DungeonDataStruct>();
    [SerializeField]
    StateMachine stateMachine;

    [SerializeField]
    ConnectStateProcess connectStateProcess;
    [SerializeField]
    SelectStateProcess selectStateProcess;
    [SerializeField]
    FillStateProcess fillStateProcess;
    [SerializeField]
    ChangeQuestionStateProcess changeQuestionStateProcess;

    Dictionary<DungeonStateEnum, BaseDungeonProcess> processes;

    [SerializeField]
    DungeonStateEnum currentState;

    int nowQuestionIndex;

    private void Awake()
    {
        processes = new Dictionary<DungeonStateEnum, BaseDungeonProcess>();
    }
    void Start()
    {
        this.SetProcessesDictionary();
        this.nowQuestionIndex = 0;

        currentState = DungeonStateEnum.Connect;
        processes[currentState].Enter();
    }

    public void SetDungeonData(List<DungeonDataStruct> dungeonData)
    {
        this.dungeonData = new List<DungeonDataStruct> (dungeonData);
    }

    // Update is called once per frame
    void Update()
    {
        DungeonStateEnum processResult = (DungeonStateEnum)stateMachine.ExecuteProcess(processes[currentState]);
        //Processを実行した結果、状態が変化する場合
        if ((DungeonStateEnum)processes[currentState].GetStateInt() != processResult)
        {
            Debug.Log($"current = {currentState}, result = {processResult}");
            //状態を変更する
            stateMachine.ChangeState(processes[currentState], processes[processResult]);
            currentState = processResult;
        }
    }

    public void SetProcessesDictionary()
    {
        processes.Add(DungeonStateEnum.Connect, connectStateProcess);
        processes.Add(DungeonStateEnum.Select, selectStateProcess);
        processes.Add(DungeonStateEnum.Fill, fillStateProcess);
        processes.Add(DungeonStateEnum.ChangeQuestion, changeQuestionStateProcess);
    }

    /// <summary>
    /// 現在の問題のデータを返します
    /// </summary>
    /// <returns>問題のデータ</returns>
    public DungeonDataStruct GetNowQuestion()
    {
        return this.dungeonData[this.nowQuestionIndex];
    }

    /// <summary>
    /// 次の問題の種類を返します
    /// </summary>
    /// <returns>次の問題の種類</returns>
    public QuestionTypeEnum GetNextQuestionType()
    {
        //問題が全て終了した場合
        if (this.nowQuestionIndex + 1 >= this.dungeonData.Count)
        {
            return QuestionTypeEnum.None;
        }

        return (QuestionTypeEnum)this.dungeonData[this.nowQuestionIndex + 1].question_type;
    }

    /// <summary>
    /// ダンジョン情報が登録済みかを返す
    /// </summary>
    /// <returns>登録済み = true, 未登録 = false</returns>
    public bool SetedDungeonData()
    {
        bool result = false;
        if (this.dungeonData.Count > 0)
        {
            result = true;
        }

        return result;
    }

    public void IncrementQuestionIndex()
    {
        this.nowQuestionIndex++;
    }
}
