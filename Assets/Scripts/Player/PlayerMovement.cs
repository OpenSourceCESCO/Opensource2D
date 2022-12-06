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
    public PlayerLeftMovements leftMove;
    float h, v;
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;
    EventableObjects eObjects;
    EndingFlags ending;
    GameObject pausePopup;
    GameObject gameoverPopup;
    GameObject spawnPoint;

    GameObject Sprite;

    Transform dialogueSystem;
    GetValueInScripts yarnValueGetter;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        transform.position = spawnPoint.transform.position;

        Transform ingameUI = GameObject.FindGameObjectWithTag("InGameUI").transform;
        pausePopup = ingameUI.Find("Pause").gameObject;
        gameoverPopup = ingameUI.Find("GameOver").gameObject;

        dialogueSystem = GameObject.Find("DSParent").transform.Find("Dialogue System");
        dialogueSystem.GetComponent<DialogueRunner>().IsDialogueRunning = false;

        yarnValueGetter = dialogueSystem.GetComponent<GetValueInScripts>();
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        eObjects = new EventableObjects();
        ending = new EndingFlags();
        Sprite = GameObject.Find("DSParent/Dialogue System/Canvas/Sprite");
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

        // if (Singletone.Instance.playerStats["grade"] == 5 && Singletone.Instance.playerStats["weeks"] == 1)
        // {
        //     ending.ShowEndings(gameoverPopup);
        // }

        if (yarnValueGetter.isSkipWeek)
        {
            SkipWeeks(scanObject.GetComponent<ObjData>().id);
            return;
        }
        if (yarnValueGetter.isTalkEnd)
        {
            AdjustStats(scanObject.GetComponent<ObjData>().id);
            return;
        }

        // 플레이어의 이동 키 가져옴
        GetKeyOfPlayerMove();
        //����Ʈ
        PlayerTalk();

        if (Input.GetKeyDown("r")) leftMove.ReduceSlider(); // test용도
    }

    void GetKeyOfPlayerMove()
    {
        h = manager.isTalkAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isTalkAction ? 0 : Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(h, v) * Time.deltaTime * speed);

        //Animation
        /*anim = GetComponent<Animator>();
        anim.SetInteger("Moveh", (int)h);
        anim.SetInteger("Movev", (int)v);*/

        anim = GetComponent<Animator>();
        if (anim.GetInteger("Moveh") != h) {
            anim.SetBool("Flag", true);
            anim.SetInteger("Moveh", (int)h);
        }
        else if (anim.GetInteger("Movev") != v) {
            anim.SetBool("Flag", true);
            anim.SetInteger("Movev", (int)v);
        }
        else {
            anim.SetBool("Flag", false);
        }

        //Raycast Vector
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
            if (!dialogueSystem.GetComponent<DialogueRunner>().IsDialogueRunning)
            {
                if (eObjects.IsInSkipObject(scanObject.GetComponent<ObjData>().id))
                {
                    switch (eObjects.weekSkipObject[scanObject.GetComponent<ObjData>().id])
                    {
                        case "bed":
                            dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("SkipWeek");
                            break;
                        case "professor":
                            dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("Professor");
                            Sprite.GetComponent<Image>().sprite = Resources.Load("Image/prof_portrait", typeof(Sprite)) as Sprite;
                            break;
                        default:
                            break;
                    }
                    yarnValueGetter.isSkipWeek = false;
                    return;
                }
                if (leftMove.moveLeft > 0)
                {
                    switch (eObjects.eventableObject[scanObject.GetComponent<ObjData>().id])
                    {
                        case "girl":
                            dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("NPCGirlTalk");
                            break;
                        case "gem":
                            dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("Quest_object");
                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
        }
    }

    void AdjustStats(int objectID)
    {
        bool flag = true;
        if (!yarnValueGetter.isTalkEnd) return;
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
                flag = false;
                break;
        }
        if (flag) leftMove.ReduceSlider();
        yarnValueGetter.isTalkEnd = false;
    }

    void SkipWeeks(int objectID)
    {
        float additionalFactor = 0.7f;
        if (!eObjects.IsInSkipObject(objectID)) return;
        if (!yarnValueGetter.isSkipWeek) return;

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

        Singletone.Instance.playerStats["weeks"] += 1;

        if ((Singletone.Instance.playerStats["weeks"] - 1) / 12 == 1)
        {
            Singletone.Instance.playerStats["grade"] += 1;
            Singletone.Instance.playerStats["weeks"] = 1;
        }

        transform.position = spawnPoint.transform.position;
        yarnValueGetter.isSkipWeek = false;
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