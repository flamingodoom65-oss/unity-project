using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Door Opened!"); // test message for now
        }
    }
}