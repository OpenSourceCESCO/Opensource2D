using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TalkManager : MonoBehaviour
{
    Dictionary<string, string[]> talkData;
    TextDatas textDatas;

    [Serializable]
    class TextData
    {
        public string id;
        public string[] text;
    }

    class TextDatas
    {
        public TextData[] data;
    }

    void Awake()
    {
        talkData = new Dictionary<string, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        string filepath = "Assets/Resources/Json/talkMessage.json";
        string json = File.ReadAllText(filepath);
        textDatas = JsonUtility.FromJson<TextDatas>(json);

        for (int i = 0; i < textDatas.data.Length; i++)
        {
            talkData.Add(textDatas.data[i].id, textDatas.data[i].text);
        }
        // talkData.Add(1, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���?" });
        // talkData.Add(2, new string[] { "��ü �� ����.", "������ �༮�� �׽�Ʈ�� ���� ��ġ�� �� �ϴ�." });
        // talkData.Add(3, new string[] { "������ ���ߴ�?", "�����ǿ� �����ִٸ� ���Ŷ�." });
    }
    public string GetTalk(string id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
