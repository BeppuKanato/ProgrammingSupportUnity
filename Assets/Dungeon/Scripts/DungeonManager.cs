using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEditor;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    List<DungeonDataStruct> dungeonData;
    [SerializeField]
    StateMachine stateMachine;

    [SerializeField]
    SelectStateProcess selectStateProcess;
    [SerializeField]
    FillStateProcess fillStateProcess;

    //processに処理クラスを全てまとめたいなら、
    //DungeonStateEnumにSelectなどの問題タイプ + Connectなどの前準備の状態
    //その必要がないなら問題のタイプの処理の辞書と前準備などの処理を分けるべきかも
    Dictionary<DungeonStateEnum, BaseDungeonProcess> processes;

    DungeonStateEnum currentState;
    DungeonStateEnum nextState;
    private void Awake()
    {
        processes = new Dictionary<DungeonStateEnum, BaseDungeonProcess>();
    }
    void Start()
    {
        this.SetProcessesDictionary();

        currentState = DungeonStateEnum.Select;
        //currentState = nextState;
        nextState = currentState;
    }

    public void SetDungeonData(List<DungeonDataStruct> dungeonData)
    {
        this.dungeonData = dungeonData;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
        DungeonStateEnum resultState = (DungeonStateEnum)stateMachine.StateManagement(processes[currentState], processes[nextState]);

        //processの実行によって次の状態が変化した時
        if (nextState != resultState)
        {
            //nextStateを返ってきた状態に設定
            nextState = resultState;
        }
        else
        {
            currentState = resultState;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(dungeonData[0].question_type);
            BaseDungeonProcess typeProcess = processes[(DungeonStateEnum)dungeonData[0].question_type];

            typeProcess.PickUpNeedData(dungeonData[0]);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"次の状態 = {processes[(DungeonStateEnum)dungeonData[0].question_type].Process()}");
        }

    }

    public void SetProcessesDictionary()
    {
        processes.Add(DungeonStateEnum.Select, selectStateProcess);
        processes.Add(DungeonStateEnum.Fill, fillStateProcess);
    }
}
