using UnityEngine;
using TMPro;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]private int maxhealth = 100; //PLayer's maximum health//

    private int currentHealth; //Player's current amount of health//


    [SerializeField]private Transform RespawnPoint; //The point where the player will respawn//

    [SerializeField]
    TextMeshProUGUI HeaalthText; //Text to display the player's health//
    void Start()
    {
        currentHealth = maxhealth; //Setting the player's current health to the max//
        HeaalthText.text = "Health: " + currentHealth.ToString(); //Display the player's health on the UI//
        Debug.Log("Player health initialized: " + currentHealth);
    }



    public void TakeDamage(int amount)
    {
        currentHealth -= amount;//Minus the damage taken//
        Debug.Log("Player has taken damage , current health: " + currentHealth);

        if (currentHealth <= 0) //if the player health is below 0 he dies//
        {
            Respawn();
        }
    }
    void Respawn()
    {
        Debug.Log("Player respawned.");
        currentHealth = maxhealth;

        if (RespawnPoint != null)
        {
            var controller = GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                transform.position = RespawnPoint.position;
                controller.enabled = true;
            }
            else
            {
                transform.position = RespawnPoint.position;
            }
        }

    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

}
