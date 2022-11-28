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
    EventableObjects eObjects;
    EndingFlags ending;
    GameObject pausePopup;
    GameObject gameoverPopup;

    GameObject spawnPoint;
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        transform.position = spawnPoint.transform.position;

        Transform ingameUI = GameObject.FindGameObjectWithTag("InGameUI").transform;
        pausePopup = ingameUI.Find("Pause").gameObject;
        gameoverPopup = ingameUI.Find("GameOver").gameObject;
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        eObjects = new EventableObjects();
        ending = new EndingFlags();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausePopup.activeSelf) return;
        if (gameoverPopup.activeSelf) return;

        // 플레이어의 이동 키 가져옴
        GetKeyOfPlayerMove();
        //����Ʈ
        IsPlayerOnTalk();

        if (Singletone.Instance.playerStats["grade"] == 5 && Singletone.Instance.playerStats["weeks"] == 1)
        {
            ending.ShowEndings(gameoverPopup);
        }

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test용도
    }

    void GetKeyOfPlayerMove()
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
    }

    void IsPlayerOnTalk()
    {
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            print(scanObject.name);
            try
            {
                if (leftMove.moveLeft != 0) manager.Action(scanObject);
            }
            catch
            {

            }
            if (manager.talkIndex == 0 && scanObject.GetComponent<ObjData>().id == -1)
            {
                SkipWeeks(scanObject.GetComponent<ObjData>().id);
                return;
            }
            if (manager.talkIndex == 0 && itrManager.itrActionIndex == 0)
            {

                if (leftMove.moveLeft != 0)
                {
                    AdjustStats(scanObject.GetComponent<ObjData>().id);
                    leftMove.ReduceSlider();
                }
                else if (leftMove.moveLeft == 0)
                {
                    // TODO : 상호작용이 불가능하다는 UI 띄우는 코드 실행

                    // 대화한 object가 강의실 책상이거나 침대일 경우 실행
                    SkipWeeks(scanObject.GetComponent<ObjData>().id);
                }
            }
        }
    }

    void AdjustStats(int objectID)
    {
        switch (eObjects.eventableObject[objectID])
        {
            case "homeDesk":
                Singletone.Instance.playerStats["int"] += (int)Random.Range(-1, 2);
                break;
            case "professor":
                Singletone.Instance.playerStats["pCommu"] += (int)Random.Range(-1, 3);
                Singletone.Instance.playerStats["int"] += (int)Random.Range(1, 3);
                break;
            case "girl":
                Singletone.Instance.playerStats["sCommu"] += (int)Random.Range(-1, 3);
                Singletone.Instance.playerStats["int"] += (int)Random.Range(0, 1);
                break;
            default:
                break;
        }
    }

    void RecoverStrength(int objectID)
    {
        float additionalFactor = 0.7f;
        // 만약, scanObject가 침대라면 => 현재 남은 행동력의 n%를 다음 추가 행동력으로 할당
        // 현재 추가 행동력은 합하지 않음
        switch (eObjects.weekSkipObject[objectID])
        {
            case "bed":
                leftMove.InitSliderValue(6, (int)(leftMove.moveLeft * additionalFactor));
                break;
            case "professor":
                leftMove.InitSliderValue(6);
                break;
            default:
                break;
        }
    }

    void SkipWeeks(int objectID)
    {
        print(string.Format("{0} {1}", eObjects.IsInSkipObject(objectID), eObjects.weekSkipObject.Count));
        if (!eObjects.IsInSkipObject(objectID)) return;

        RecoverStrength(objectID);

        Singletone.Instance.playerStats["weeks"] += 1;

        if ((Singletone.Instance.playerStats["weeks"] - 1) / 12 == 1)
        {
            Singletone.Instance.playerStats["grade"] += 1;
            Singletone.Instance.playerStats["weeks"] = 1;
        }

        transform.position = spawnPoint.transform.position;
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