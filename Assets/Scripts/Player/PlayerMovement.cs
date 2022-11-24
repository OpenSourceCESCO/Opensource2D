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
    List<int> weekSkipObject;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        weekSkipObject = new List<int>();
        AddWeekSkipObject();
    }

    void AddWeekSkipObject()
    {
        weekSkipObject.Add(2000);
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
            if (leftMove.moveLeft != 0) manager.Action(scanObject);
            if (manager.talkIndex == 0 && itrManager.itrActionIndex == 0)
            {
                if (leftMove.moveLeft != 0) leftMove.ReduceSlider();
                else if (leftMove.moveLeft == 0)
                {
                    // TODO : 상호작용이 불가능하다는 UI 띄우는 코드 실행

                    // 대화한 object가 강의실 책상이거나 침대일 경우 실행
                    SkipWeeks(scanObject);
                }
            }
        }

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test용도
    }

    void SkipWeeks(GameObject scanObject)
    {
        print(string.Format("{0} {1}", weekSkipObject.Contains(scanObject.GetComponent<ObjData>().id), weekSkipObject.Count));
        if (!weekSkipObject.Contains(scanObject.GetComponent<ObjData>().id)) return;

        leftMove.InitSliderValue();
        Singletone.Instance.playerStats["weeks"] += 1;

        if ((Singletone.Instance.playerStats["weeks"] - 1) / 12 == 1)
        {
            Singletone.Instance.playerStats["grade"] += 1;
            Singletone.Instance.playerStats["weeks"] = 1;
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
