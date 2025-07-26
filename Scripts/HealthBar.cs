using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health = 1f; // Initial health value 
    public Slider healthSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a tag "Red Zone"
        if (collision.gameObject.CompareTag("Red Zone"))
        {
            health -= 0.05f;
            Debug.Log("Health reduced. Current health: " + health);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (healthSlider != null)
            healthSlider.value = health; // Update slider value
        if (health <= 0)
        {
            // If health is zero or less, destroy the game object
            Destroy(gameObject);
            Debug.Log("GameObject destroyed due to zero health.");
        }
    }
}
