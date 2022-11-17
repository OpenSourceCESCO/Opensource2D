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
        SceneManager.LoadScene("NewGameUI");
    }
    public void GotoMainScene()
    {
        SceneManager.LoadScene("StartUI");
    }
    public void GotoMaptest()
    {
        SceneManager.LoadScene("MapTest");
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
    public void OnResumeBtnClick() {
        string filePath = Application.persistentDataPath + "/" + gamedataFileName;
        if (File.Exists(filePath)) {
            Singletone.Instance.InitUserData();
            Singletone.Instance.LoadGameData();
            SceneManager.LoadScene("MapTest");
            
        }
    }
}
