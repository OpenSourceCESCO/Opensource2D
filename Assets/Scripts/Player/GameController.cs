using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameoverPopup;
    public static float playTime = 10f;
    public GameObject pausePopup;
    public static bool isPausePopup = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
            gameoverPopup.gameObject.SetActive(true);
        }
    }

    public void restartGame() {
        gameoverPopup.gameObject.SetActive(false);
        Singletone.Instance.saveData.leftTime = Singletone.Instance.saveData.initTime;
        Singletone.Instance.saveData.playerPos = new Vector2(0, 0);
        SceneManager.LoadScene("MapTest");
    }

    public static void goMainScene() {
        SceneManager.LoadScene("StartUI");
    }
}
