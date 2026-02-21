using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float sprintSpeed = 20f;
    public float acceleration = 5f;

    [Header("Roll Settings")]
    public float rollSpeed = 60f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        HandleMovement();
        HandleRoll();
    }

    void HandleMovement()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        // Directional input relative to where the camera is facing
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) input += transform.forward;
        if (Input.GetKey(KeyCode.S)) input -= transform.forward;
        if (Input.GetKey(KeyCode.A)) input -= transform.right;
        if (Input.GetKey(KeyCode.D)) input += transform.right;
        if (Input.GetKey(KeyCode.Space)) input += transform.up;     // Up
        if (Input.GetKey(KeyCode.LeftControl)) input -= transform.up; // Down

        // Smoothly accelerate toward target velocity
        Vector3 targetVelocity = input.normalized * speed;
        velocity = Vector3.Lerp(velocity, targetVelocity, acceleration * Time.deltaTime);

        transform.position += velocity * Time.deltaTime;
    }

    void HandleRoll()
    {
        // Q / E to roll
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0f, 0f, rollSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0f, 0f, -rollSpeed * Time.deltaTime);
    }
}