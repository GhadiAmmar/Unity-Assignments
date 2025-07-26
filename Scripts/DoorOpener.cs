using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnimator=GetComponentInParent<Animator>();
        doorAnimator.SetBool("isTrig", false); // Ensure the door is closed at the start
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("isTrig", true); // Open the door when the player enters the trigger
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("isTrig", false); // Close the door when the player exits the trigger
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
