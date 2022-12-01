using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

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

    Transform dialogueSystem;
    bool isSkipWeek;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        transform.position = spawnPoint.transform.position;

        Transform ingameUI = GameObject.FindGameObjectWithTag("InGameUI").transform;
        pausePopup = ingameUI.Find("Pause").gameObject;
        gameoverPopup = ingameUI.Find("GameOver").gameObject;

        dialogueSystem = GameObject.Find("DSParent").transform.Find("Dialogue System");
        dialogueSystem.GetComponent<DialogueRunner>().IsDialogueRunning = false;
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        eObjects = new EventableObjects();
        ending = new EndingFlags();

        isSkipWeek = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausePopup.activeSelf) return;
        if (gameoverPopup.activeSelf) return;



        if (dialogueSystem.GetComponent<DialogueRunner>().IsDialogueRunning)
        {
            return;
        }
        else
        {
            dialogueSystem.GetComponent<DialogueRunner>().Stop();
        }

        if (isSkipWeek)
        {
            isSkipWeek = false;
            SkipWeeks(-1);
            return;
        }

        // 플레이어의 이동 키 가져옴
        GetKeyOfPlayerMove();
        //����Ʈ
        PlayerTalk();

        if (Singletone.Instance.playerStats["grade"] == 5 && Singletone.Instance.playerStats["weeks"] == 1)
        {
            ending.ShowEndings(gameoverPopup);
        }

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test용도
    }

    public void GetSkipWeekFlag()
    {
        dialogueSystem.GetComponent<InMemoryVariableStorage>().TryGetValue<bool>("$skipWeek", out isSkipWeek);
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

    void PlayerTalk()
    {
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            if (eObjects.IsInSkipObject(scanObject.GetComponent<ObjData>().id) && !dialogueSystem.GetComponent<DialogueRunner>().IsDialogueRunning)
            {
                switch (eObjects.weekSkipObject[scanObject.GetComponent<ObjData>().id])
                {
                    case "bed":
                        dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("SkipWeek");
                        break;
                    case "professor":
                        dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("Professor");
                        break;
                    default:
                        break;
                }
                isSkipWeek = false;
                return;
            }
            // legacy script data
            if (manager.talkIndex == 0)
            {
                if (itrManager.itrActionIndex == 0)
                {
                    if (leftMove.moveLeft != 0)
                    {
                        AdjustStats(scanObject.GetComponent<ObjData>().id);
                        leftMove.ReduceSlider();
                    }
                }
            }
            try
            {
                if (leftMove.moveLeft != 0) manager.Action(scanObject);
            }
            catch
            {

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