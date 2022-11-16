using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    TextDatas textDatas;

    [Serializable]
    class TextData {
        public int id;
        public string[] text;
    }

    class TextDatas {
        public TextData[] data;
    }

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        string filepath = "Assets/Resources/Json/talkMessage.json";
        string json = File.ReadAllText(filepath);
        textDatas = JsonUtility.FromJson<TextDatas>(json);

        for (int i = 0; i < textDatas.data.Length; i++) {
            talkData.Add(textDatas.data[i].id, textDatas.data[i].text);
        }
        // talkData.Add(1, new string[] { "안녕?", "이 곳에 처음 왔구나?" });
        // talkData.Add(2, new string[] { "정체 모를 무언가.", "개발자 녀석이 테스트를 위해 배치한 듯 하다." });
        // talkData.Add(3, new string[] { "과제는 다했니?", "연구실에 관심있다면 오거라." });
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
