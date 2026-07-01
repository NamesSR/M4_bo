using NUnit.Framework;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    float rspeed;
    public float gravity = -9.81f;
    public float smoothfactor = 20f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpFores = 2f;
    text text;
    public bool haskey = false;

    public bool indialog = false;
    [SerializeField] Vector3 velocity;
    Vector3 dir;
    float height = 0.5f;
    TrigerSettings s;
    float x;
    float z;
    bool isGrounded;
    bool specialTrigger = true;
    public GameObject torch;
    public bool invisneble = false;
    [SerializeField] Texture[] hpUI = new Texture[] { };
    [SerializeField] RawImage hpui2;

    private void Awake()
    {
        text.dialogEnd += textend;
        rspeed = speed;
        hpui2.texture = hpUI[GameManager.Instance.hp - 1];

    }
    void Update()
    {
        // warp tester
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    //warp(new Vector3(-16.68745f, 1.68568f, 28.57953f));
        //    warp(TriggerManager.instance.respawntarget(14));
        //    //controller.transform.position = new Vector3(-11.8f + 12, 1.68568f, 24.8f - 18);
        //    //Physics.SyncTransforms();




        //}
        if (GameManager.Instance.hp <= 0)
        {
            warp(TriggerManager.instance.respawntarget(GameManager.Instance.flag));
            GameManager.Instance.flag--;
            GameManager.Instance.enemyend();
            torch.SetActive(false);
            StopCoroutine(enemy23());
            GameManager.Instance.hp = 3;
            hpui2.texture = hpUI[GameManager.Instance.hp - 1];

        }

    }
    private void FixedUpdate()
    {

        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                controller.height = 0.25f;
                controller.center = new Vector3(0f, -0.15f, 0);
            }
            else if (controller.height < 0.5f && Input.GetKeyUp(KeyCode.LeftControl))
            {
                controller.height = height;
                controller.center = Vector3.zero;
            }
        }


        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");



        Vector3 move = new Vector3(x, 0f, z);//.normalized;
        velocity.x = Mathf.Lerp(velocity.x, move.x * rspeed, Time.deltaTime * smoothfactor);
        velocity.z = Mathf.Lerp(velocity.z, move.z * rspeed, Time.deltaTime * smoothfactor);


        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpFores * -2f * gravity);
            Debug.Log("jump");
        }
        velocity.y += gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);



    }
    void textend()
    {

        s = null;
        rspeed = speed;
        text = null;
        GameManager.Instance.flag++;
        TriggerManager.instance.ssd(GameManager.Instance.flag);
        specialTrigger = true;


    }
    

    IEnumerator ivisebles()
    {
        invisneble = true;
        yield return new WaitForSeconds(0.2f);
        invisneble = false;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Debug.Log("colision");
            if (invisneble == false)
            {
                GameManager.Instance.hp--;
                StartCoroutine(ivisebles());
                if (GameManager.Instance.hp > 0)
                {
                    hpui2.texture = hpUI[GameManager.Instance.hp - 1];

                }
                

            }
        }
        if (col.tag == "key")
        {
            haskey = true;
            Destroy(col.gameObject);

        }
        if (col.tag == "dialog")
        {
            if (GameManager.Instance.flag == 12 || GameManager.Instance.flag == 18 || GameManager.Instance.flag == 21)
            {
                if (s == null)
                {
                    s = col.GetComponent<TrigerSettings>();
                }

                if (s.dialog)
                {
                    if (specialTrigger)
                    {

                        if (text == null)
                        {
                            text = col.GetComponent<text>();
                        }
                        rspeed = 0;
                        text.pushText(s.dialogBox);
                        specialTrigger = false;

                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            text.pushText(s.dialogBox);
                        }
                    }
                }
                else if (s.enemy)
                {
                    if (specialTrigger)
                    {
                        GameManager.Instance.enemyshow12();
                        StartCoroutine(enemy23());
                        s = null;
                    }
                    specialTrigger = false;
                }
            }
            else
            {

                if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
                {
                    if (s == null)
                    {
                        s = col.GetComponent<TrigerSettings>();
                    }

                    if (s.dialog)
                    {
                        if (GameManager.Instance.flag == 16)
                        {
                            GameManager.Instance.setnight();
                        }
                        if (GameManager.Instance.flag == 23)
                        {
                            GameManager.Instance.setday();
                        }
                        if (text == null)
                        {
                            text = col.GetComponent<text>();
                        }
                        rspeed = 0;
                        text.pushText(s.dialogBox);

                    }
                    else if (s.simonSays)
                    {
                        GameManager.Instance.simonsays();
                        s = null;
                    }
                    else if (s.mirrorPuzzle)
                    {
                        GameManager.Instance.MirrorPuzzle();
                        s = null;
                    }
                    else if (s.collerConect)
                    {
                        GameManager.Instance.collerConectPuzzleFn();
                        s = null;
                    }
                    else if (s.keyDilePuzzle)
                    {
                        GameManager.Instance.KeyDilePuzzle();
                        s = null;
                    }
                    else if (s.itemPuckUp)
                    {
                        if (GameManager.Instance.flag == 19 && GameManager.Instance.hasTorch == false)
                        {
                            GameManager.Instance.hasTorch = true;
                            //torch.SetActive(true);
                        }
                        GameManager.Instance.item1 = true;
                        if (text == null)
                        {
                            text = col.GetComponent<text>();
                        }
                        rspeed = 0;
                        text.pushText(s.dialogBox);
                    }
                    else if (s.warp)
                    {

                        GameManager.Instance.flag++;
                        TriggerManager.instance.ssd(GameManager.Instance.flag);
                        s = null;
                    }
                    else if (s.enemy)
                    {

                        GameManager.Instance.enemyshow12();
                        StartCoroutine(enemy23());
                        s = null;
                    }
                    //else if (s.enemyend)
                    //{
                    //    GameManager.Instance.enemyend();
                    //}

                }
            }
        }




    }
    IEnumerator enemy23()
    {
        yield return new WaitForSeconds(30f);
        GameManager.Instance.burnenemy = true;
        torch.SetActive(true);
    }
    public void warp(Vector3 newPos)
    {

        transform.position = newPos;
        Physics.SyncTransforms();
    }



}