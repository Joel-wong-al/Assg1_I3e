using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Transform player;
    AudioSource doorSound; //Audio source for the door sound effect//
    bool isOpen = false; //The door is currently closed//
    public float closeDistance = 5f;//Distance for door to close//

    void Start()
    {
        doorSound = GetComponent<AudioSource>(); //Get the audio source component attached to the door//
    }
    public void Interact()
    {
        if (!isOpen)
        {
            OpenDoor();
        }
    } 

    void Update()
    {
        if (isOpen && Vector3.Distance(transform.position, player.position) > closeDistance)
        {
            CloseDoor();
        }
    }
        void OpenDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y += 90f;
        transform.eulerAngles = doorRotation;

        if (doorSound != null)
        {
            doorSound.Play();
            Debug.Log("Door opened and sound played");
        }

        isOpen = true;
    }

    void CloseDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y -= 90f;
        transform.eulerAngles = doorRotation;

        isOpen = false;
        Debug.Log("Door closed");
    }
}
