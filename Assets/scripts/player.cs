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
    public text text;
    public bool haskey = false;
    Vector3 dir;
    float height = 0.5f;
    TrigerSettings s;
    public bool indialog = false;
    float x;
    float z;

    [SerializeField] Vector3 velocity;
    bool isGrounded;
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
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
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


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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