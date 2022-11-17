using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    // Slider playerHP;
    // Transform fillArea;

    // float v, h;
    int minusCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        // playerHP = GetComponent<Slider>();
        // fillArea = transform.Find("Fill Area");
    }

    // Update is called once per frame
    void Update()
    {
        // if (playerHP.value <= playerHP.minValue)    fillArea.gameObject.SetActive(false);
        // else                                        fillArea.gameObject.SetActive(true);

        // if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
        //     if (playerHP.value > playerHP.minValue) playerHP.value -= Time.deltaTime * factor;
        // } else {
        //     if (playerHP.value < playerHP.maxValue) playerHP.value += Time.deltaTime * factor;
        // }

        if (Singletone.Instance.playerStats["health"] < 0) {
            return;
        }
        else if (Singletone.Instance.playerStats["health"] > 100) {
            return;
        }

        float time = Singletone.Instance.saveData.initTime - Timer.rTime;
        if (minusCnt == (int)(time / 5) - 1) {
            minusCnt++;
            Singletone.Instance.playerStats["health"] -= 10;
        }
    }
}
