using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int maxhealth = 100; //PLayer's maximum health//

    public double currentHealth; //Player's current amount of health//

    public int currentScore = 0;

    bool canInteract = false; //Wethere the player ca interact with this thing yet//

    private Vector3 spawnpoint; //Stores the respawn position of the player//

    PotionBehaviour potions; // Add the behaviour of the potions to the variable//

    void Start()
    {
        currentHealth = maxhealth; //Setting the player's current health to the max//
        spawnpoint = transform.position; //Set the Inital spawn point of player//
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
        if (other.CompareTag("EscapeDoor"))
        {
            canInteract = true;//allows for the player to open the door//
            //Add door behaviour//
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))//Checking what type of hazard it is//
        {
            TakeDamage(100); //Player will instantly die//
        }
        if (collision.gameObject.CompareTag("Hazard_Smoke"))
        {
            TakeDamage(0.1); //Player will lose health over time//
        }
    }
    void TakeDamage(double amount)
    {
        currentHealth -= amount;
        Debug.Log("Player has taken damage , current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }
    void Respawn()
    {
        transform.position = spawnpoint; // Send player back to spawn//
        currentHealth = maxhealth; // Set player health back to 100//
        Debug.Log("Player has respawned!"); //Let me know whether this code worked//
    }

    public void ModifyScore(int amt)
    {
        currentScore += amt;
    }

    [SerializeField]
    float interactionDistance = 5f;
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

            }
        }
    }

}
