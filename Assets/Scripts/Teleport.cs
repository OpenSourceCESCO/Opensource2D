using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    public GameObject portal;

    private float moveFactor = 0.1f;

    private float[] axis = new float[2];

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            axis[0] = Input.GetAxisRaw("Horizontal");
            axis[1] = Input.GetAxisRaw("Vertical");

            axis[0] = axis[0] < 0 ? axis[0] - moveFactor : axis[0] + moveFactor;
            axis[1] = axis[1] < 0 ? axis[1] - moveFactor : axis[1] + moveFactor;

            player.transform.position = new Vector2(portal.transform.position.x + axis[0], portal.transform.position.y + axis[1]);
            // player.transform.position = portal.transform.position;
            print("enter!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
}
