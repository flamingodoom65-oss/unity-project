using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IInteractable
{
    private PlayerController playerScript;
    public float appleHungerGain = 20f;
    public float waterThristGain = 30f;
    public void Interact()
    {
        Debug.Log("Interacting...");
        if (gameObject.name.Equals("Cube"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
        if (gameObject.name.Equals("Apple"))
        {
            Debug.Log("Apple");
            if(playerScript.hunger <= (100-appleHungerGain))
            {
                playerScript.hunger +=appleHungerGain;
            }
            else
            {
                playerScript.hunger = 101f;
            }
        }
        if (gameObject.name.Equals("Water"))
        {
            Debug.Log("Water");
            if(playerScript.thirst<= (100 - waterThristGain))
            {
                playerScript.thirst += waterThristGain;

            }
            else
            {
                playerScript.thirst = 101f;
            }

        }
        
    }
    public void Start()
    {
        GameObject target = GameObject.Find("Player");
        playerScript = target.GetComponent<PlayerController>();
    }
    
}
