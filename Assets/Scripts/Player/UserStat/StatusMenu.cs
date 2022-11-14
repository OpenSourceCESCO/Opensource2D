using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform playerStat = GameObject.Find("PlayerStat").transform.Find("Background");
        SaveData data = Singletone.Instance.saveData;
        playerStat.Find("NameLayer").Find("UserName").gameObject.GetComponent<Text>().text = string.Format("{0}({1})", data.name, data.gender);
        playerStat.Find("GradeLayer").Find("UserGradeMAX").gameObject.GetComponent<Text>().text = data.grade;

        // GameObject.FindGameObjectWithTag("Name").GetComponent<Text>().text = string.Format("{0}({1})", data.name, data.gender);
        // GameObject.FindGameObjectWithTag("Grade").GetComponent<Text>().text = data.grade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
