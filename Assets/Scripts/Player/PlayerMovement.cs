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

        //占쏙옙占쏙옙
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

        //占쏙옙占쏙옙트
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
                    // TODO : �긽�샇�옉�슜�씠 遺덇���뒫�븯�떎�뒗 UI �쓣�슦�뒗 肄붾뱶 �떎�뻾

                    // ����솕�븳 object媛� 媛뺤쓽�떎 梨낆긽�씠嫄곕굹 移⑤���씪 寃쎌슦 �떎�뻾
                    SkipWeeks(scanObject.GetComponent<ObjData>().id);
                }
            }
        }

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test�슜�룄
    }

    void SkipWeeks(int objectID)
    {
        float additionalFactor = 0.7f;
        print(string.Format("{0} {1}", weekSkipObject.Contains(objectID), weekSkipObject.Count));
        if (!weekSkipObject.Contains(objectID)) return;

        // 留뚯빟, scanObject媛� 移⑤���씪硫� => �쁽�옱 �궓��� �뻾�룞�젰�쓽 n%瑜� �떎�쓬 異붽�� �뻾�룞�젰�쑝濡� �븷�떦
        // �쁽�옱 異붽�� �뻾�룞�젰��� �빀�븯吏� �븡�쓬

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
