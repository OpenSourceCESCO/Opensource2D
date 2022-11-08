using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    public float rTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        rTime -= Time.deltaTime;
        TimeChecher();
        text.text = "Remain Time : " + Mathf.Ceil(rTime);
    }

    private void TimeChecher() {
        if (rTime < 0) {
            rTime = 0;
            PlayerMovement.isEnd = true;
        }
    }
}
