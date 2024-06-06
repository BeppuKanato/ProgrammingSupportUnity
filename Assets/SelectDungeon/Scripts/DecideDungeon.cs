using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideDungeon : MonoBehaviour
{
    [SerializeField]
    DungeonIDScriptable dungeonIDScriptable;

    public void Deceide(string id)
    {
        dungeonIDScriptable.dungeonId = id;
    }
}
