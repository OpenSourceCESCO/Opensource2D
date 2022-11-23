using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable] // 직렬?��
public class SaveData
{
    public Vector2 playerPos;
    public string name;
    public string gender;
    public string grade;
    public List<string> statNames = new List<string>();
    public List<int> statValues = new List<int>();
}

public class PlayerStat
{
    public string statName;
    public int statValue;
}