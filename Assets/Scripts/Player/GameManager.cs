using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isTalkAction;
    public int talkIndex;
    public TalkManager talkManager;
    public InteractionManager itrManager;
    GameObject gameoverPopup;
    GameObject pausePopup;
    public static bool isPausePopup;

    void Start()
    {
        Time.timeScale = 1;
        isPausePopup = false;

        Transform ingameUI = GameObject.FindGameObjectWithTag("InGameUI").transform;
        gameoverPopup = ingameUI.Find("GameOver").gameObject;
        pausePopup = ingameUI.Find("Pause").gameObject;

        // Time.timeScale = 1;
        Vector2 playerInitPos = Singletone.Instance.saveData.playerPos;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(playerInitPos.x, playerInitPos.y);
    }

    void Update()
    {
        if (isPausePopup) return;
        if (gameoverPopup.activeSelf) return;
        if (isTalkAction) return;

        if (Singletone.Instance.playerStats["grade"] == 5 && Singletone.Instance.playerStats["weeks"] == 1)
        {
            
            gameoverPopup.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPausePopup = true;
            pausePopup.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id);
        //talkText.text = "�̰��� �̸��� " + scanObject.name + "�̶�� �Ѵ�.";
        talkPanel.SetActive(isTalkAction);
    }

    void Talk(int id) // overloading test
    {
        int itrTalkIndex = itrManager.GetItrIndex(id);  //상호작용 index 넘겨주기
        string talkData = talkManager.GetTalk(id + itrTalkIndex, talkIndex);  //json에 있는 idx를 최종적으로 넘겨주기

        if (talkData == null)
        {
            isTalkAction = false;
            talkIndex = 0;  //��ȭ ���� �� �ε��� �ʱ�ȭ
            itrManager.CheckItr(id);
            return;
        }
        talkText.text = talkData;
        isTalkAction = true;
        talkIndex++;
    }
}
