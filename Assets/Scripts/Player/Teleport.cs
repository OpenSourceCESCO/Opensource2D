using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    public GameObject portal;
    public float teleportTime = 0.1f; // 텔레포트 시 이동하는 시간 추가

    private float moveFactor = 0.1f;

    private float[] axis = new float[2];
    private float[] align = new float[2];

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            axis[0] = Input.GetAxisRaw("Horizontal");
            axis[1] = Input.GetAxisRaw("Vertical");

            align[0] = this.transform.position.x - player.transform.position.x;
            align[1] = this.transform.position.y - player.transform.position.y;

            axis[0] = axis[0] == 0 ? axis[0] - align[0] : axis[0] + align[0];
            axis[1] = axis[1] == 0 ? axis[1] - align[1] : (axis[1] < 0 ? axis[1] + align[1] - moveFactor : axis[1] + align[1] + moveFactor);

            player.transform.position = new Vector2(portal.transform.position.x + axis[0], portal.transform.position.y + axis[1]);

            Timer.rTime -= teleportTime; // 텔레포트 이동 시간. 타이머의 변수에 직접 적용
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
}
