using UnityEngine;
using UnityEngine.UI;  // ← legacy Text, no extra setup needed

public class InteractionSystem : MonoBehaviour
{
    [Header("Raycast Settings")]
    public Camera playerCamera;
    public float interactRange = 3f;
    public LayerMask interactableLayer;

    [Header("UI")]
    public Text promptText;  // ← changed from TextMeshProUGUI

    private Door currentDoor;

    void Update()
    {
        CheckForDoor();

        if (currentDoor != null && Input.GetKeyDown(KeyCode.E))
        {
            currentDoor.Open();
        }
    }

    void CheckForDoor()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            Door door = hit.collider.GetComponent<Door>();

            if (door != null && door.playerInRange)
            {
                currentDoor = door;
                ShowPrompt("[E] Open Door");
                return;
            }
        }

        currentDoor = null;
        HidePrompt();
    }

    void ShowPrompt(string message)
    {
        promptText.text = message;
        promptText.gameObject.SetActive(true);
    }

    void HidePrompt()
    {
        promptText.gameObject.SetActive(false);
    }
}