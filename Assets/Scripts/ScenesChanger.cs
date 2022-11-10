using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    public void GotoNGStart()
    {
        SceneManager.LoadScene("NewGameUI");
    }
    public void GotoMainScene()
    {
        SceneManager.LoadScene("StartUI");
    }
    public void GotoMaptest()
    {
        SceneManager.LoadScene("MapTest");
    }
}