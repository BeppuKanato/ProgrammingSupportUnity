using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DungeonDataStruct
{
    public int dungeon_id;
    public string dungeon_name;
    public string dungeon_description;
    public int question_id;
    public int question_type;
    public string question_description;
    public string question_content;
    public List<string> branch_content;
    public int answers_id;
    public List<string> answer_content;
    public List<int> blank_number;

}
