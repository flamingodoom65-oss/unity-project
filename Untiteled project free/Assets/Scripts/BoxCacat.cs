using UnityEngine;

public class BoxCacat : MonoBehaviour
{
    public int speed = 3;
    public float sprintValue = 0.7f;
    public float sprintValueChange = 0.3f;
    public int jumpingforce = 3;
    float sprint;
    bool canjump = false;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canjump = true;
        }
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = sprintValue + sprintValueChange;
        }
        else
        {
            sprint = sprintValue;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime * sprint;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime * sprint;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime * sprint;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime * sprint;
        }
        if (Input.GetKey(KeyCode.Space) && canjump)
        {
            canjump = false;
            GetComponent<Rigidbody>().AddForce(0,jumpingforce,0);
        }
        
    }
}
