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
        SaveLoad.Instance.data.playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        GameObject time = GameObject.Find("Timer");
        SaveLoad.Instance.data.leftTime = Timer.rTime;
        SaveLoad.Instance.SaveGameData();
    }

    public void OnGoMainBtnClick() {
        GameController.goMainScene();
    }

    public void OnExitBtnClick() {
        Application.Quit();
    }
}
