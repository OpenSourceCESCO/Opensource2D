using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamPlayerMovement : MonoBehaviour
{
    public float speed = 10000f;

    void Start()
    {

    }
    void Update()
    {
        float moveX, moveY;
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(moveX, moveY) * Time.deltaTime * speed);
    }

}
