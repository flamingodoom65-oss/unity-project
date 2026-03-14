using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class SpaceMovement : MonoBehaviour

{
    private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;


    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    float sprint = 1;
    

    public int jumpingforce = 300;

    private Vector3 lastPostion = new Vector3(0f,0f,0f);
  
    void Start()
    {
        controller = GetComponent<CharacterController>();


        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(sprint == 1f)
            {
                sprint = 1.5f;
                Debug.Log("1.5");
            }
            else
            {
                sprint = 1f;
                Debug.Log("1");
            }
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        ///if (Input.GetKey(KeyCode.W))
        ///{
            ///transform.position += transform.forward * speed * Time.deltaTime * sprint;
        ///}

        float x= Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x+transform.forward*z;///(right-red axis,forward = blue axis)
        controller.Move(move * speed * Time.deltaTime * sprint);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.5f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(lastPostion != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            
        }
        else
        {
            isMoving = false;
        }

        lastPostion = gameObject.transform.position;
        
    
    }

    
}