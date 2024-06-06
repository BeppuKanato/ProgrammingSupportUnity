using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDungeonData : BaseSendRequest
{
    [SerializeField]
    DungeonManager dungeonManager;
    [SerializeField]
    DungeonIDScriptable dungeonIDScriptable;
    private void Start()
    {
        //シーンが始まった時にデータ取得
        SendRequest();
    }
    public override void SendRequest()
    {
        SendData sendData = new SendData(dungeonIDScriptable.dungeonId);
        string sendJson = sendData.Serialize();

        Debug.Log(sendJson);

        this.RequestPostToServer(sendJson);
    }

    protected override void SuccessCallback(string jsonData)
    {
        Debug.Log("通信に成功しました");

        ReceiveData receiveData = new ReceiveData();

        receiveData = (ReceiveData)receiveData.Deserialize(jsonData);

        dungeonManager.SetDungeonData(receiveData.root_key);

        Debug.Log(receiveData.root_key[0].question_id);
    }

    [Serializable]
    private class SendData : BaseSendData
    {
        public string id;

        public SendData(string id)
        {
            this.id = id;
        }
    }

    //[Serializable]
    //private class ReceiveData
    //{
    //    public int dungeon_id;
    //    public string dungeon_name;
    //    public string dungeon_description;
    //    public int question_id;
    //    public int question_type;
    //    public string question_description;
    //    public string question_content;
    //    public List<string> branch_content;
    //    public int answers_id;
    //    public string answer_content;
    //    public List<int> blank_number;
    //}

    [Serializable]
    private class ReceiveData : BaseReceiveData
    {
        public List<DungeonDataStruct> root_key;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            ReceiveData receiveData = (ReceiveData)JsonUtility.FromJson<ReceiveData>(jsonData);

            return receiveData;
        }
    }
}