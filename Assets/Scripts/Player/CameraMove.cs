using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    // public GameObject player;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        Vector3 t = spawnPoint.transform.position;
        transform.position = new Vector3(t.x, t.y, transform.position.z);
    }

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
