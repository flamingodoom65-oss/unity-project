using System;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float interactionDistance;
    [SerializeField] private InputActionReference interactionReference;

    private void OnEnable()
    {
        interactionReference.action.Enable();
        interactionReference.action.started += PlayerInteracted;


        
    }
    private void OnDiable()
    {
        interactionReference.action.started -= PlayerInteracted;
        interactionReference.action.Disable();
    }
    private void PlayerInteracted(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Ray ray = new Ray(playerCamera.position,playerCamera.forward);
            if(!Physics.Raycast(ray, out RaycastHit hitInfo, interactionDistance)) return;
            if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObject))
            {
                interactableObject.Interact();
            }
            
        }
    }
}
