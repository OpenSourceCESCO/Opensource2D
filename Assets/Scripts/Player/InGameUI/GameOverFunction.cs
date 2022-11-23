using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFunction : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gameoverPopup;
    void Start()
    {
        gameoverPopup = GameObject.FindGameObjectWithTag("InGameUI").transform.Find("GameOver").gameObject;
    }

    public void OnRestartBtnClick()
    {
        gameoverPopup.SetActive(false);
        Singletone.Instance.saveData.playerPos = new Vector2(0, 0);
        Singletone.Instance.InitUserData();
        SceneManager.LoadScene("MapTest");
    }
}
