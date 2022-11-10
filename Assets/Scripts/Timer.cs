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
        rTime = GameController.playTime;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        rTime -= Time.deltaTime;
        if (rTime < 0f) rTime = 0;
        text.text = string.Format("Remain Time : {0:0.00}", rTime);
    }
}
