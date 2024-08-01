using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DungeonStateEnum
{
    None,
    Connect,    //データをサーバーから受け取る
    Select,     //select形式の問題
    Input,      //input形式の問題
    Fill,       //Fill形式の問題
    ChangeQuestion,  //問題を変更する
    EndDungeon, //ダンジョン終了
}