using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add(1, new string[] { "안녕?", "이 곳에 처음 왔구나?" });
        talkData.Add(2, new string[] { "정체 모를 무언가.", "개발자 녀석이 테스트를 위해 배치한 듯 하다." });
        talkData.Add(3, new string[] { "과제는 다했니?", "연구실에 관심있다면 오거라." });
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
