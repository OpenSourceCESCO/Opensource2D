using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public ScenesChanger sc;
    public GameObject stageNumObject;
    float timeFactor = 10f;
    // Start is called before the first frame update
    void Start()
    {
        sc.stageTime = 4 * timeFactor;
    }

    // Update is called once per frame
    public void OnClickToggle()
    {
        string nowbutton = EventSystem.current.currentSelectedGameObject.name;
        if      (nowbutton == "2nd") sc.stageTime = Int32.Parse(nowbutton.Substring(0, 1)) * timeFactor;
        else if (nowbutton == "4th") sc.stageTime = Int32.Parse(nowbutton.Substring(0, 1)) * timeFactor;
        else if (nowbutton == "5th") sc.stageTime = Int32.Parse(nowbutton.Substring(0, 1)) * timeFactor;
    }

    public void GameStart() {
        SceneManager.LoadScene("MapTest");
        DontDestroyOnLoad(stageNumObject);
    }


}
