using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public void GameStart()
    {
        // 이름에 띄어쓰기 금지!
        string name = GameObject.FindGameObjectWithTag("Name").GetComponent<InputField>().text.Replace(" ", "");
        if (name.CompareTo("") == 0)
        {
            GameObject.Find("Name").transform.Find("EnterUserNameErr").gameObject.SetActive(true);
            GameObject.Find("SetPopup").SetActive(false);
            return;
        }
        Singletone.Instance.saveData.name = name;

        Toggle[] activedGender = GameObject.FindGameObjectWithTag("Gender").GetComponentsInChildren<Toggle>();
        for (int i = 0; i < activedGender.Length; i++)
        {
            if (activedGender[i].isOn) Singletone.Instance.saveData.gender = activedGender[i].name.CompareTo("Man") == 0 ? "남" : "여";
        }

        Toggle[] activedGrade = GameObject.FindGameObjectWithTag("Grade").GetComponentsInChildren<Toggle>();

        Singletone.Instance.saveData.playerPos = new Vector2(0, 0);

        Singletone.Instance.InitUserData();

        SceneManager.LoadScene("MapTest");
    }
}
