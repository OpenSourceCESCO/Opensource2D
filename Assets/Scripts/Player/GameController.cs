using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameObject gameoverPopup;
    GameObject pausePopup;
    public static bool isPausePopup; // 다른 함수에서도 사용해야 함
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPausePopup = false;

        Transform ingameUI = GameObject.FindGameObjectWithTag("InGameUI").transform;
        gameoverPopup = ingameUI.Find("GameOver").gameObject;
        pausePopup = ingameUI.Find("Pause").gameObject;

        // Time.timeScale = 1;
        Vector2 playerInitPos = Singletone.Instance.saveData.playerPos;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(playerInitPos.x, playerInitPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPausePopup) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                isPausePopup = true;
                pausePopup.SetActive(true);
                Time.timeScale = 0;
            }
        }
        EndTime();
    }

    void EndTime() {
        if (Timer.rTime <= 0) {
            Time.timeScale = 0;
            gameoverPopup.SetActive(true);
        }
    }

    public static void goMainScene() {
        SceneManager.LoadScene("StartUI");
    }
}
