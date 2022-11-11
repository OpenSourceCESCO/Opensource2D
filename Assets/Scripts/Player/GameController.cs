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
        Time.timeScale = 1; // 시간을 흐르게 하는 요소.
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPausePopup) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                print("False");
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
        Timer.rTime = playTime;
        SceneManager.LoadScene("MapTest");
    }

    public static void goMainScene() {
        Destroy(GameObject.Find("StageNum"));
        SceneManager.LoadScene("StartUI");
    }
}
