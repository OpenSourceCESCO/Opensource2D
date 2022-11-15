using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    void Start() {
        currentTeleporter = null;
    }
    // Start is called before the first frame update
    void Update() {
        if (currentTeleporter != null) {
            transform.position = currentTeleporter.GetComponent<Teleport>().GetDestination().position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Portal")) {
            if (currentTeleporter != null) {
                StartCoroutine(WaitForIt());
                print("Exited!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Portal")) {
            if (collision.gameObject != null && currentTeleporter == null) {
                currentTeleporter = collision.gameObject;
                print("entered!");
                // player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            }
        }
        // if (collision.tag == "Player") {
        //     axis[0] = Input.GetAxisRaw("Horizontal");
        //     axis[1] = Input.GetAxisRaw("Vertical");

        //     align[0] = this.transform.position.x - player.transform.position.x;
        //     align[1] = this.transform.position.y - player.transform.position.y;

        //     axis[0] = axis[0] == 0 ? axis[0] - align[0] : axis[0] + align[0];
        //     axis[1] = axis[1] == 0 ? axis[1] - align[1] : (axis[1] < 0 ? axis[1] + align[1] - moveFactor : axis[1] + align[1] + moveFactor);

        //     player.transform.position = new Vector2(portal.transform.position.x + axis[0], portal.transform.position.y + axis[1]);

        //     Timer.rTime -= teleportTime; // 텔레포트 이동 시간. 타이머의 변수에 직접 적용
        // }
    }

    IEnumerator WaitForIt() {
        yield return new WaitForSeconds(1);
        currentTeleporter = null;
    }
}
