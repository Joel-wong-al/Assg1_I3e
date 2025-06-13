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

            if (door != null) // Allow the player to open the door//
            {
                door.Interact();
                Debug.Log("You have opened the door");
            }

            if (gameObject.CompareTag("EscapeDoor"))
            {
                if (currentScore >= 10) //Player can escape//
                {
                    Debug.Log("Door is Open");//Tell me that the door is open in requirements is met//
                    //Add door behaviour when it is done//
                }
                if (currentScore <= 10)//Player can't escape//
                {
        
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



    public void ModifyScore(int amt)
    {
        currentScore += amt;
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    [SerializeField]
    float interactionDistance = 20f;
    void Update()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position, transform.forward * interactionDistance, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.collider.gameObject.CompareTag("Collectible"))
            {
                canInteract = true;
                potions = hitInfo.collider.GetComponent<PotionBehaviour>();

                if (Input.GetKeyDown(KeyCode.E))//use of chatgpt to check for input//
                {
                    OnInteract();
                }
            }
            if (hitInfo.collider.gameObject.CompareTag("EscapeDoor"))
            {
                canInteract = true;
            }

        }
    }

}
