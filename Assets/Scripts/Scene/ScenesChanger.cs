using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScenesChanger : MonoBehaviour
{
    public float stageTime;
    public GameObject stageNumObject;
    public void GotoNGStart()
    {
        SceneManager.LoadScene("NewGameUI");
    }
    public void GotoMainScene()
    {
        SceneManager.LoadScene("StartUI");
    }
    public void GotoMaptest()
    {
        SceneManager.LoadScene("MapTest");
        DontDestroyOnLoad(stageNumObject);
    }
    public void GotoSelectScene()
    {
        SceneManager.LoadScene("MapSelect");
    }
    public void SelectedMap()
    {
        GameObject clickBtn = EventSystem.current.currentSelectedGameObject;
        SceneManager.LoadScene(clickBtn.name);
    }
}
