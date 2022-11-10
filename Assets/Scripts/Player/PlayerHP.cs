using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    Slider playerHP;
    Transform fillArea;

    float v, h;
    float factor = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GetComponent<Slider>();
        fillArea = transform.Find("Fill Area");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP.value <= playerHP.minValue)    fillArea.gameObject.SetActive(false);
        else                                        fillArea.gameObject.SetActive(true);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            if (playerHP.value > playerHP.minValue) playerHP.value -= Time.deltaTime * factor;
        } else {
            if (playerHP.value < playerHP.maxValue) playerHP.value += Time.deltaTime * factor;
        }
    }
}
