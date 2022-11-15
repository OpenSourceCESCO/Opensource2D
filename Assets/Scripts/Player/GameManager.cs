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
    public int talkIndex;
    public TalkManager talkManager;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);
        //talkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        talkPanel.SetActive(isAction);
    }
    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;  //대화 종료 시 인덱스 초기화
            return;
        }
        talkText.text = talkData;
        isAction = true;
        talkIndex++;
    }
}
