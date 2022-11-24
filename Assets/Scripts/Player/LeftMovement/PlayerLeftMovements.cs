using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLeftMovements : MonoBehaviour
{
    GameObject player;

    Slider additionalMove, move;
    float sliderFactor = 0.08333f;
    int initMoveValue = 6;
    public int additionalMoveLeft = 4;
    public int moveLeft = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        move = this.transform.Find("Move").gameObject.GetComponent<Slider>();
        additionalMove = this.transform.Find("AdditionalMove").gameObject.GetComponent<Slider>();

        move.value = sliderFactor * moveLeft;
        additionalMove.value = sliderFactor * additionalMoveLeft;
        if (moveLeft < 6) {
            additionalMove.transform.Rotate(new Vector3(0, 0, 30 * (initMoveValue - moveLeft)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
    }

    public void ReduceSlider() {
        if (additionalMoveLeft > 0) additionalMove.value = sliderFactor * --additionalMoveLeft;
        else if (moveLeft > 0) move.value = sliderFactor * --moveLeft;
    }
}
