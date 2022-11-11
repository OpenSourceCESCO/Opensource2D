using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float h, v;
    Rigidbody2D rigid;
    Animator anim;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(h, v) * Time.deltaTime * speed);

        //Animation
        anim = GetComponent<Animator>();
        anim.SetInteger("Moveh",(int)h);
        anim.SetInteger("Movev",(int)v);
    }

/*     private void FixedUpdate() {
        rigid.velocity = new Vector2(h, v) * speed;    
    } */
}
