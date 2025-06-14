using UnityEngine;
using TMPro;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]private int maxhealth = 100; //PLayer's maximum health//

    private int currentHealth; //Player's current amount of health//

    private bool Inlazar = false;//Whther player is in lazar//
    [SerializeField] private int lazarDamageAmount = 2;//Damage player take in lazar per second//

    [SerializeField] private float lazarDamageInterval = 0.1f;

    [SerializeField] private Transform RespawnPoint; //The point where the player will respawn//

    private float lazarTimer = 0f;

    [SerializeField] TextMeshProUGUI HeaalthText; //Text to display the player's health//
    void Start()
    {
        currentHealth = maxhealth; //Setting the player's current health to the max//
        HeaalthText.text = "Health: " + currentHealth.ToString(); //Display the player's health on the UI//
        Debug.Log("Player health initialized: " + currentHealth);
    }

    void Update()
    {
        if (Inlazar)
        {
            lazarTimer += Time.deltaTime;

            if (lazarTimer >= lazarDamageInterval)
            {
                TakeDamage(lazarDamageAmount);
                lazarTimer = 0f;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard_lazar"))
        {
            Inlazar = true;
            Debug.Log("Player entered lazar."); 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard_lazar"))
        {
            Inlazar = false;
            Debug.Log("Player exited lazar.");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;//Minus the damage taken//
        Debug.Log("Player has taken damage , current health: " + currentHealth);
        HeaalthText.text = "Health: " + currentHealth.ToString();
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
        HeaalthText.text = "Health: " + currentHealth.ToString();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

}
