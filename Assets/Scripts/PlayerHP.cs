using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    Slider playerHP;
    Transform fillArea;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GetComponent<Slider>();
        fillArea = transform.Find("Fill Area");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP.value <= playerHP.minValue) {
            print(string.Format("{0}, {1}", playerHP.minValue, playerHP.maxValue));
            fillArea.gameObject.SetActive(false);
        }
        else {
            fillArea.gameObject.SetActive(true);
        }
        // else GameObject.find("Fill Area").gameobject.SetActive(true);
    }
}
