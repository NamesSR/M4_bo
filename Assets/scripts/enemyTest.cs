using UnityEngine;
using UnityEngine.InputSystem.XR;

public class enemyTest : MonoBehaviour
{
    Vector3 verlosity;
    Vector3 dir;
    Transform player;
    public float speed = 5f;
    public float gravity = -9.81f;
    public CharacterController Controller;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verlosity.y < 0)
        {
            verlosity.y = -2f;
           
        }


        dir = player.position - transform.position;
        verlosity = dir.normalized * speed;
        verlosity.y += gravity * Time.deltaTime;
        Controller.Move(verlosity * Time.deltaTime);
    }
}
