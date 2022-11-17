using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public static int talkIndex;
    public TalkManager talkManager;
    public InteractionManager itrManager;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);
        //talkText.text = "�̰��� �̸��� " + scanObject.name + "�̶�� �Ѵ�.";
        talkPanel.SetActive(isAction);
    }

    void Talk(int id) // overloading test
    {
        int itrTalkIndex = itrManager.GetItrIndex(id);  //상호작용 index 넘겨주기
        string talkData = talkManager.GetTalk(id + itrTalkIndex, talkIndex);  //json에 있는 idx를 최종적으로 넘겨주기

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;  //��ȭ ���� �� �ε��� �ʱ�ȭ
            itrManager.CheckItr(id);
            return;
        }
        talkText.text = talkData;
        isAction = true;
        talkIndex++;
    }
}
