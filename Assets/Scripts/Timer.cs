using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    public static float rTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        rTime = GameController.playTime;
        print(rTime);
    }

    // Update is called once per frame
    void Update()
    {
        rTime -= Time.deltaTime;
        if (rTime < 0f) rTime = 0;
        text.text = "Remain Time : " + (rTime); //Mathf.Ceil
    }
}
