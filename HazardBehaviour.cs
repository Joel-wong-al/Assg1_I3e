using UnityEngine;

public class HazardBehaviour : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20; // Amount of damage the hazard inflicts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player has entered the hazard
        {
            HealthBehaviour health = other.GetComponent<HealthBehaviour>();
            if (health != null) // If the player has a HealthBehaviour component
            {
                health.TakeDamage(damageAmount); // Inflict damage
                Debug.Log("Player has entered a hazard and took " + damageAmount + " damage.");
            }
        }
    }

}
