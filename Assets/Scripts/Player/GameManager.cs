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

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        // Talk(objData.id);
        Talk(objData.id);
        //talkText.text = "�̰��� �̸��� " + scanObject.name + "�̶�� �Ѵ�.";
        talkPanel.SetActive(isAction);
    }

    void Talk(string id) // overloading test
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;  //��ȭ ���� �� �ε��� �ʱ�ȭ
            return;
        }
        talkText.text = talkData;
        isAction = true;
        talkIndex++;
    }
}
