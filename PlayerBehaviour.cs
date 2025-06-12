using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    int maxhealth = 100; //PLayer's maximum health//

    int currentHealth = 100; //Player's current amount of health//

    int currentScore = 0;

    bool canInteract = false; //Wethere the player ca interact with this thing yet//

    PotionBehaviour potions; // Add the behaviour of the potions to the variable//

    void OnInteract()
    {
        if (canInteract)
        {
            if (potions != null)
            {
                potions.Collect(this);
                Debug.Log("Your current score is " + currentScore);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            canInteract = true;//Allow the player to pick up the coin//
            potions = other.GetComponent<PotionBehaviour>();

        }
    }

    public void ModifyScore(int amt)
    {
        currentScore += amt;
    }

}
