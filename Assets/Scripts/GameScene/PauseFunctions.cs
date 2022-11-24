using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public GameObject pausePopup;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void OnResumeBtnClick()
    {
        GameManager.isPausePopup = !GameManager.isPausePopup;
        Time.timeScale = 1;
        pausePopup.SetActive(false);
    }

    public void OnSaveBtnClick()
    {
        Singletone.Instance.saveData.playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        Singletone.Instance.SaveGameData();
    }

    public void OnGoMainBtnClick()
    {
        Singletone.Instance.SceneChanger("StartUI");
    }

    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}
