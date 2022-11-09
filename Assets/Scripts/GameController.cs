using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameoverPopup;
    public static float playTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        Time.timeScale = 1; // 시간을 흐르게 하는 요소.
        Timer.rTime = playTime;
        SceneManager.LoadScene("MapTest");
    }
}
