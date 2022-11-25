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
            if (manager.talkIndex == 0 && scanObject.GetComponent<ObjData>().id == 2000)
            {
                SkipWeeks(scanObject.GetComponent<ObjData>().id);
                return;
            }
            if (manager.talkIndex == 0 && itrManager.itrActionIndex == 0)
            {
                print(string.Format("{0} {1}", leftMove.moveLeft, leftMove.additionalMoveLeft));

                if (leftMove.moveLeft != 0) leftMove.ReduceSlider();
                else if (leftMove.moveLeft == 0)
                {
                    // TODO : 상호작용이 불가능하다는 UI 띄우는 코드 실행

                    // 대화한 object가 강의실 책상이거나 침대일 경우 실행
                    SkipWeeks(scanObject.GetComponent<ObjData>().id);
                }
            }
        }

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test용도
    }

    void SkipWeeks(int objectID)
    {
        float additionalFactor = 0.7f;
        print(string.Format("{0} {1}", weekSkipObject.Contains(objectID), weekSkipObject.Count));
        if (!weekSkipObject.Contains(objectID)) return;

        // 만약, scanObject가 침대라면 => 현재 남은 행동력의 n%를 다음 추가 행동력으로 할당
        // 현재 추가 행동력은 합하지 않음

        if (objectID == 2000) leftMove.InitSliderValue(6, (int)(leftMove.moveLeft * additionalFactor));
        else leftMove.InitSliderValue((int)Random.Range(1, 6), (int)Random.Range(1, 4));

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
