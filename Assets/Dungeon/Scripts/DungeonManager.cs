using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    List<DungeonDataStruct> dungeonData;

    [SerializeField]
    SelectStateProcess selectStateProcess;

    //processに処理クラスを全てまとめたいなら、
    //DungeonStateEnumにSelectなどの問題タイプ + Connectなどの前準備の状態
    //その必要がないなら問題のタイプの処理の辞書と前準備などの処理を分けるべきかも
    Dictionary<DungeonStateEnum, BaseDungeonProcess> processes;

    private void Awake()
    {
        processes = new Dictionary<DungeonStateEnum, BaseDungeonProcess>();
    }
    void Start()
    {
        this.SetProcessesDictionary();
    }

    public void SetDungeonData(List<DungeonDataStruct> dungeonData)
    {
        this.dungeonData = dungeonData;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(dungeonData[0].question_type);
            BaseDungeonProcess typeProcess = processes[(DungeonStateEnum)dungeonData[0].question_type];

            typeProcess.PickUpNeedData(dungeonData[0]);
        }  
    }

    public void SetProcessesDictionary()
    {
        processes.Add(DungeonStateEnum.Select, selectStateProcess);
    }
}
