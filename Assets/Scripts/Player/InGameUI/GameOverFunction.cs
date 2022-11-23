using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameoverPopup;
    public void OnRestartBtnClick()
    {
        gameoverPopup.SetActive(false);
        Singletone.Instance.saveData.playerPos = new Vector2(0, 0);
        Singletone.Instance.InitUserData();
        Singletone.Instance.SceneChanger("MapText");
        // SceneManager.LoadScene("MapTest");
    }

    public void OnGoMainBtnClick()
    {
        GameController.goMainScene();
    }

    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}
