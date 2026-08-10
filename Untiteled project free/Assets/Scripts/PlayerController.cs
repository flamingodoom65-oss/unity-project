using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 7.5f;
    private float jumpForce = 200f;
    private bool isGrounded = false;
    private float sprintVal = 1f;
    public float stamina = 100;
    public float staminaDrain = 10f;
    public float hunger = 100;
    public float hungerDrain = 2f;
    public float thirst = 100;
    public float thirstDrain = 3f;
    public Canvas canvas;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;

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
        hungerText.text = "Hunger: " + Mathf.Round(hunger);
        thirstText.text = "Thirst: " + Mathf.Round(thirst);
        if (hunger > 0)
        {
            hunger-=Time.deltaTime*hungerDrain;
        }
        if (thirst > 0)
        {
            thirst -= Time.deltaTime*thirstDrain;
        }

       
        if (Input.GetKey(KeyCode.LeftShift)&&stamina>0&&(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)))
        {
            sprintVal = 1.5f;
            stamina -= Time.deltaTime*staminaDrain;
        }
        else
        {
            sprintVal = 1f;
            if (stamina < 100)
            {
                stamina+=Time.deltaTime*staminaDrain/4;               
            }
            
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
