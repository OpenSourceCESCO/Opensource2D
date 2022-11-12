using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    float timeFactor = 10f;

    public void GameStart() {
        Singletone.Instance.saveData.playerName = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<InputField>().text;

        Toggle[] activedGender = GameObject.FindGameObjectWithTag("Gender").GetComponentsInChildren<Toggle>();
        for (int i = 0; i < activedGender.Length; i++) {
            if (activedGender[i].isOn) Singletone.Instance.saveData.gender = activedGender[i].name;
        }

        Toggle[] activedGrade = GameObject.FindGameObjectWithTag("Grade").GetComponentsInChildren<Toggle>();
        for (int i = 0; i < activedGrade.Length; i++) {
            if (activedGrade[i].isOn) {
                Singletone.Instance.saveData.initTime = Int32.Parse(activedGrade[i].name.Substring(0, 1)) * timeFactor;
                Singletone.Instance.saveData.leftTime = Singletone.Instance.saveData.initTime;
            }
        }

        Singletone.Instance.saveData.playerPos = new Vector2(0, 0);
        
        SceneManager.LoadScene("MapTest");
    }
}
