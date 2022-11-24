using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameManager manager;
    public InteractionManager itrManager;
    float h, v;
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;
    public PlayerLeftMovements leftMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = manager.isTalkAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isTalkAction ? 0 : Input.GetAxisRaw("Vertical");

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
            manager.Action(scanObject);
            if (manager.talkIndex == 0 && itrManager.itrActionIndex == 0)
            {
                leftMove.ReduceSlider();
            }
        }

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test용도

        if (leftMove.moveLeft == 0)
        {
            leftMove.InitSliderValue();
            Singletone.Instance.playerStats["weeks"] += 1;

            if ((Singletone.Instance.playerStats["weeks"] - 1) / 12 == 1)
            {
                Singletone.Instance.playerStats["grade"] += 1;
                Singletone.Instance.playerStats["weeks"] = 1;
            }
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
