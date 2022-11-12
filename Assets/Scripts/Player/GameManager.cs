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
    // Start is called before the first frame update
    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
            talkPanel.SetActive(false);
        }
        else
        {
            isAction = true;
            talkPanel.SetActive(true);
            scanObject = scanObj;
            talkText.text = "�̰��� �̸��� " + scanObject.name + "�̶�� �Ѵ�.";
        }
        talkPanel.SetActive(isAction);
    }
}
