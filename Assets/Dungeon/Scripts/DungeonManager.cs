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

    //process�ɏ����N���X��S�Ă܂Ƃ߂����Ȃ�A
    //DungeonStateEnum��Select�Ȃǂ̖��^�C�v + Connect�Ȃǂ̑O�����̏��
    //���̕K�v���Ȃ��Ȃ���̃^�C�v�̏����̎����ƑO�����Ȃǂ̏����𕪂���ׂ�����
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
