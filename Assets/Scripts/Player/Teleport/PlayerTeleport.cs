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
                Invoke("WaitForIt", 0.1f);
                // invoke, coroutine 등을 쓰지 않으면 플레이어가 무한 텔레포트 된다...
                // 위의 update 때문인듯
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Portal")) {
            if (collision.gameObject != null && currentTeleporter == null) {
                currentTeleporter = collision.gameObject;
            }
        }
    }

    void WaitForIt() {
        // yield return new WaitForSeconds(1);
        currentTeleporter = null;
    }
}
