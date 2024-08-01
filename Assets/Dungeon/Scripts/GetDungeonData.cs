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

        receiveData.FormattingQuestionType();

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

    [Serializable]
    private class ReceiveData : BaseReceiveData
    {
        public List<DungeonDataStruct> root_key;
        const int QUESTION_TYPE_OFFSET = 100;

        public override BaseReceiveData Deserialize(string jsonData)
        {
            ReceiveData receiveData = (ReceiveData)JsonUtility.FromJson<ReceiveData>(jsonData);

            return receiveData;
        }
        //question_typeの値を列挙体の数値に合わせる
        public void FormattingQuestionType()
        {
            for (int i = 0; i < this.root_key.Count; i++)
            {
                root_key[i].question_type += QUESTION_TYPE_OFFSET;
            }
        }
    }
}