using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    bool isOpen = false; //The door is currently closed//
    public void Interact()
    {
        Vector3 doorRotation = transform.eulerAngles; // Get the current rotation of the door//

        if (!isOpen) //If the door is closed//
        {
            doorRotation.y += 90f; // Rotate the door by 90 degrees on the Y-axis//
            isOpen = true; // Set the door to open state//
        }
        else if (isOpen == true) //If the door is open//
        {
            doorRotation.y -= 90f; // Rotate the door back by 90 degrees on the Y-axis//
            isOpen = false; // Set the door to closed state//
        }

        transform.eulerAngles = doorRotation; // Apply the new rotation to the door//

    } 
}
