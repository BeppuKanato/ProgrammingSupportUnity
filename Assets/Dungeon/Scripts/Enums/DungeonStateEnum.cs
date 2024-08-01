using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DungeonStateEnum
{
    None = -1,
    Connect = 0,    //データをサーバーから受け取る
    Select = 101,     //select形式の問題
    Input = 102,      //input形式の問題
    Fill = 103,       //Fill形式の問題
}