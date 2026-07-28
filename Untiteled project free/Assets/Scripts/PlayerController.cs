using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 7.5f;
    private float jumpForce = 200f;
    private bool isGrounded = false;
    private float sprintVal = 1f;
    private float stamina = 100;
    private float staminaDrain = 10f;
    public Canvas canvas;
    public TextMeshProUGUI staminaText;
    private Rigidbody rb;

    
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            isGrounded = true;
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaText.text = "Stamina: " + Mathf.Round(stamina);

        // if(Input.GetKey(KeyCode.W)){
        //     transform.position += new Vector3(0,0,speed*Time.deltaTime);

        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     transform.position += new Vector3(0,0,-speed*Time.deltaTime);
        // } 
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.position += new Vector3(speed*Time.deltaTime,0,0);
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.position += new Vector3(-speed*Time.deltaTime,0,0);
        // }
        if (Input.GetKey(KeyCode.LeftShift)&&stamina>0)
        {
            sprintVal = 1.5f;
            stamina -= Time.deltaTime*staminaDrain;
        }
        else
        {
            sprintVal = 1f;
        }
        if (sprintVal < 0)
        {
            sprintVal = 0f;

        }
        if (Input.GetKey(KeyCode.Space)&&isGrounded)
        {
            
            rb.AddForce(0,jumpForce,0);
            isGrounded = false;

            
        }
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += transform.forward;

        if (Input.GetKey(KeyCode.S))
            move -= transform.forward;

        if (Input.GetKey(KeyCode.D))
            move += transform.right;

        if (Input.GetKey(KeyCode.A))
            move -= transform.right;

        move.Normalize();

        transform.position += move * speed * Time.deltaTime*sprintVal;
        
        
        
    }
}
