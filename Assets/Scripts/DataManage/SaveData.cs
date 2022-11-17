using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable] // ì§ë ¬?™”
public class SaveData
{
    public float leftTime;
    public Vector2 playerPos;
    public string name;
    public string gender;
    public float initTime;
    public string grade;
    public List<string> statNames = new List<string>();
    public List<int> statValues = new List<int>();
}

public class PlayerStat {
    public string statName;
    public int statValue;
}