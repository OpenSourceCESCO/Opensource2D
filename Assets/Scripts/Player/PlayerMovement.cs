using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameManager manager;
    public GameObject leftMovement;
    float h, v;
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;

    Slider additionalMove, move;
    float sliderFactor = 0.08333f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        additionalMove = leftMovement.transform.Find("AdditionalMove").gameObject.GetComponent<Slider>();
        move = leftMovement.transform.Find("Move").gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(h, v) * Time.deltaTime * speed);

        //Animation
        anim = GetComponent<Animator>();
        anim.SetInteger("Moveh", (int)h);
        anim.SetInteger("Movev", (int)v);

        //����
        if (v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (h == 1)
        {
            dirVec = Vector3.right;
        }

        //����Ʈ
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            if (GameManager.talkIndex == 0)
            {
                if (additionalMove.value > sliderFactor - 0.001) additionalMove.value -= sliderFactor;
                else if (move.value > sliderFactor - 0.001) move.value -= sliderFactor;
            }
            manager.Action(scanObject);
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("QuestLayer"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
