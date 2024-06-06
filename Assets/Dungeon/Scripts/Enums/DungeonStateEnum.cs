using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DungeonStateEnum
{
    None = -1,
    Connect = 0,    //データをサーバーから受け取る
    Select = 1,     //select形式の問題
    Input = 2,      //input形式の問題
    Fill = 3,       //Fill形式の問題
}