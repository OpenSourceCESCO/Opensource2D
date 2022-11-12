using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public GameObject pausePopup;

    public void OnResumeBtnClick() {
        GameController.isPausePopup = !GameController.isPausePopup;
        Time.timeScale = 1;
        pausePopup.SetActive(false);
    }

    public void OnSaveBtnClick() {
        GameObject player = GameObject.Find("Player");
        Singletone.Instance.saveData.playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        Singletone.Instance.saveData.leftTime = Timer.rTime;
        Singletone.Instance.SaveGameData();
    }

    public void OnGoMainBtnClick() {
        GameController.isPausePopup = !GameController.isPausePopup;
        GameController.goMainScene();
    }

    public void OnExitBtnClick() {
        Application.Quit();
    }
}