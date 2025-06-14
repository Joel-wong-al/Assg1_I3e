using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    public int currentScore = 0;

    bool canInteract = false; //Wethere the player ca interact with this thing yet//

    PotionBehaviour potions; // Add the behaviour of the potions to the variable//

    DoorBehaviour door; // Add the behaviour of the door to the variable//

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI healthText;


    void Start()
    {
        scoreText.text = "SCORE: " + currentScore.ToString();

    }
    void OnInteract()
    {

        if (canInteract)
        {
            if (potions != null) // Allow the player to collect the potion//
            {
                potions.Collect(this);
                Debug.Log("Your current score is " + currentScore);
            }

            if (door != null)
            {
                
                if (door.gameObject.CompareTag("EscapeDoor"))// Check if the door is an escape door//
                {
                    if (currentScore >= 10) //Check if player has enough ponints to escape//
                    {
                        Debug.Log("Door is Open");
                        door.Interact();

                    }
                    else
                    {
                        Debug.Log("You need 10 points to escape");
                    }
                }
                else// Regular door, just open it
                {
                    
                    door.Interact();
                    Debug.Log("You have opened the door");
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))//Checking what this item is//
        {
            canInteract = true;//Let the system know that this item can be interacted with//
            potions = other.GetComponent<PotionBehaviour>();//Get the code to allow the collection and destruction of potion//
        }
        else if (other.CompareTag("door"))
        {
            canInteract = true;//allows for the player to open the door//
            door = other.GetComponent<DoorBehaviour>();//Get the code to allow the door to open//
        }
        else if (other.CompareTag("EscapeDoor"))
        {
            canInteract = true; // allows the player to interact with the escape door//
            door = other.GetComponent<DoorBehaviour>(); // Get the door behaviour for interaction//
        }
        else if (other.CompareTag("Hazard"))
        {
            Debug.Log("Player has entered a hazard area");
            HealthBehaviour health = GetComponent<HealthBehaviour>();
            if (health != null)
            {
                health.TakeDamage(100); // Instantly "kill" player
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("door") || other.CompareTag("EscapeDoor"))
        {
            canInteract = false;
            door = null;
        }
    }



    public void ModifyScore(int amt)
    {
        currentScore += amt;
        scoreText.text = "SCORE: " + currentScore.ToString();
    }



}
