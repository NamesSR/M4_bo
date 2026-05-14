using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float smoothfactor = 20f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpFores = 2f;
    Vector3 dir;

   [SerializeField] Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0f, z).normalized;
        velocity.x = Mathf.Lerp(velocity.x, move.x * speed, Time.deltaTime * smoothfactor);
        velocity.z = Mathf.Lerp(velocity.z, move.z * speed, Time.deltaTime * smoothfactor);
      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpFores * -2f * gravity);
            Debug.Log("jump");
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
       
    }
}