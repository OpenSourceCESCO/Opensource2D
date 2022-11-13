using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveData data = Singletone.Instance.saveData;
        GameObject.FindGameObjectWithTag("Name").GetComponent<Text>().text = string.Format("{0}({1})", data.name, data.gender);
        GameObject.FindGameObjectWithTag("Grade").GetComponent<Text>().text = data.grade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
