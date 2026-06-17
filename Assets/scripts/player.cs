using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

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
    public string[] flags = new string[] { };
    private void Awake()
    {
        text.dialogEnd += textend;
        rspeed = speed;
    }
    void Update()
    {

        


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
        //if (s.triggerId == "checkon")
        //{
            
        //    GameManager.Instance.checkon = true;
        //    GameManager.Instance.show2();
        //}
        //if (s.triggerId == "first" && GameManager.Instance.checkon == false)
        //{
        //    GameManager.Instance.first = true;
        //    GameManager.Instance.show();
        //}

        s = null;
        rspeed = speed;
        text = null;


    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "key")
        {
            haskey = true;
            Destroy(col.gameObject);

        }
        if (col.tag == "dialog")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (s == null)
                {
                    s = col.GetComponent<TrigerSettings>();
                }

                if (s.dialog)
                {
                    if(text == null)
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
                else if(s.itemPuckUp)
                {
                    GameManager.Instance.item1 = true;
                }

            }
        }




    }
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "dialog")
    //    {

    //        if (s == null)
    //        {
    //            s = col.GetComponent<dialogTriggerSettings>();
    //        }
    //        if (Input.GetKey(KeyCode.E))
    //        {
    //            text.pushText(s.startIndex, s.maxIndex);
    //        }
    //    }
    //}



}