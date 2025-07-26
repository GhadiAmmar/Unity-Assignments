using UnityEngine;

public class RaycastInspector : MonoBehaviour
{
    public float length = 100f; // Length of the raycast
    public int score = 0; // Score variable to keep track of hits   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //GameObject door = GameObject.FindGameObjectWithTag("Door");
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        {
        //    {
        //                    // If the left mouse button is pressed, log a message
        //        Debug.Log("Left mouse button pressed");
        //    }
        bool ray = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hitInfo, length);
        if (ray)
        {
            // Log the name of the object hit by the raycast
            Debug.Log("Hit " + hitInfo.collider.gameObject.tag);
            if (hitInfo.collider.gameObject.tag == "Target")
            {
                // If the raycast hits an object with the tag "Target", log a message
                Debug.Log("Target ahead!");
                if (Input.GetMouseButtonDown(0))
                {

                    // If the leftclick is pressed, increment the score
                    score++;
                    Debug.Log("Score: " + score);
                    Destroy(hitInfo.collider.gameObject); // Eliminate the target

                }
            }
        }
        else { Debug.Log("nothing ahead"); }
                   
        if (score == 9)
        {
            Destroy(GameObject.FindGameObjectWithTag("Door")); // Destroy the game object when score reaches 9  
        }
    }
}
