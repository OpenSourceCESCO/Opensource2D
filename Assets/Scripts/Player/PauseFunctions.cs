using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public GameObject pausePopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnResumeBtnClick() {
        GameController.isPausePopup = !GameController.isPausePopup;
        Time.timeScale = 1;
        pausePopup.SetActive(false);
    }

    public void OnSaveBtnClick() {
        print("미구현");
    }

    public void OnGoMainBtnClick() {
        GameController.goMainScene();
    }

    public void OnExitBtnClick() {
        Application.Quit();
    }
}
