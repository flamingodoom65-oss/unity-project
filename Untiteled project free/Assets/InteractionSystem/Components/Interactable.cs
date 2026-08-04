using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting...");
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        
    }
    
}
