using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class ScenesChanger : MonoBehaviour
{
    string gamedataFileName = "GameData.json";
    public void GotoNGStart()
    {
        Singletone.Instance.SceneChanger("NewGameUI");
    }
    public void GotoMainScene()
    {
        Singletone.Instance.SceneChanger("StartUI");
    }
    public void GotoMaptest()
    {
        Singletone.Instance.SceneChanger("MapTest");
    }
    public void GotoSelectScene()
    {
        Singletone.Instance.SceneChanger("MapSelect");
    }
    public void SelectedMap()
    {
        GameObject clickBtn = EventSystem.current.currentSelectedGameObject;
        SceneManager.LoadScene(clickBtn.name);
    }
    public void OnResumeBtnClick()
    {
        string filePath = Application.persistentDataPath + "/" + gamedataFileName;
        if (File.Exists(filePath))
        {
            Singletone.Instance.InitUserData();
            Singletone.Instance.LoadGameData();
            Singletone.Instance.SceneChanger("MapTest");
        }
    }
}
