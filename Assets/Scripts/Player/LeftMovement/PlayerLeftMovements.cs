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
    public int moveLeft = 2;

    // Start is called before the first frame update
    void Start()
    {
        print(moveLeft);
        player = GameObject.FindWithTag("Player");
        move = this.transform.Find("Move").gameObject.GetComponent<Slider>();
        additionalMove = this.transform.Find("AdditionalMove").gameObject.GetComponent<Slider>();

        move.value = sliderFactor * moveLeft;
        additionalMove.value = sliderFactor * additionalMoveLeft;
        // 회전 시 모양이 이상하게 변하여 해결할때 까지는 임시보류
/*         if (moveLeft < initMoveValue)
        { // 기본 행동력이 까임에 따라 추가 행동력의 위치 변화
            additionalMove.transform.Rotate(new Vector3(0, 0, 30 * (initMoveValue - moveLeft)));
        } */
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 위치를 따라가도록 설정
        this.transform.position = player.transform.position;
    }

    public void ReduceSlider()
    {
        if (additionalMoveLeft > 0) additionalMove.value = sliderFactor * --additionalMoveLeft;
        else if (moveLeft > 0) move.value = sliderFactor * --moveLeft;
    }
}
