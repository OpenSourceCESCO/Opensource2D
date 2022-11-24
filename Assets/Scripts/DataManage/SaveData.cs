using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable] // 직렬?��
public class SaveData
{
    public Vector2 playerPos;
    public string name;
    public string gender;
    public int currentGrade;
    public int currentWeek;
    public int additionalMoveLeft;
    public int moveLeft;
    public List<string> statNames = new List<string>();
    public List<float> statValues = new List<float>();
}

public class PlayerStat
{
    public string statName;
    public float statValue;
}