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
        talkData.Add(1, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���?" });
        talkData.Add(2, new string[] { "��ü �� ����.", "������ �༮�� �׽�Ʈ�� ���� ��ġ�� �� �ϴ�." });
        talkData.Add(3, new string[] { "������ ���ߴ�?", "�����ǿ� �����ִٸ� ���Ŷ�." });
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
