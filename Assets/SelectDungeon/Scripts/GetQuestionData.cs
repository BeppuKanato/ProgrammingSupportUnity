using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//public class GetQuestionData : BaseSendRequest
//{
//    public override void SendRequest()
//    {
//        SendData sendData = new SendData("1");
//        string sendJson = sendData.Serialize();

//        Debug.Log(sendJson);

//        this.RequestPostToServer(sendJson);
//    }

//    protected override void SuccessCallback(string jsonData)
//    {
//        Debug.Log("í êMÇ…ê¨å˜ÇµÇ‹ÇµÇΩ");

//        DungeonData dungeonData = new DungeonData();

//        dungeonData = (DungeonData)dungeonData.Deserialize(jsonData);

//        Debug.Log(dungeonData.root_key[0].question_content);

//        foreach(string content in dungeonData.root_key[0].branch_content)
//        {
//            Debug.Log(content);
//        }
//    }

//    [Serializable]
//    private class SendData : BaseSendData
//    {
//        public string id;

//        public SendData(string id)
//        {
//            this.id = id;
//        }
//    }

//    [Serializable]
//    private class ReceiveData 
//    {
//        public int dungeon_id;
//        public string dungeon_name;
//        public string dungeon_description;
//        public int question_id;
//        public int question_type;
//        public string question_description;
//        public string question_content;
//        public List<string> branch_content;
//        public int answers_id;
//        public string answer_content;
//        public List<int> blank_number;
//    }

//    [Serializable]
//    private class DungeonData : BaseReceiveData 
//    {
//        public List<ReceiveData> root_key;

//        public override BaseReceiveData Deserialize(string jsonData)
//        {
//            DungeonData receiveData = (DungeonData)JsonUtility.FromJson<DungeonData>(jsonData);

//            return receiveData;
//        }
//    }
//}