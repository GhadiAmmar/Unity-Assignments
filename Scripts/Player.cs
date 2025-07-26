using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    private bool isGrounded = true;
    private bool onEnvironment = false;
    private float sensitivity;
    private float rotationY = 0f;

    private Vector3 moveInput;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 10.0f); // Default to 1.0 if not set
        sensitivity /= 10.0f; // Set sensitivity to 10.0f as per your requirement
        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Debug.Log("sensitivity: " + sensitivity);   
        // --- Get Input ---
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveInput = transform.right * moveX + transform.forward * moveZ;

        // --- Get Mouse Input for Rotation ---
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        rotationY += mouseX;

        // --- Jump Input ---
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded||onEnvironment))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None; // Unlock cursor when Escape is pressed
        }
        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = 10f; // Increase speed when shift is held
        }
        else
        {
            moveSpeed = 5f; // Reset to normal speed
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None; // Unlock cursor when Escape is pressed
        }
        else
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked; // Lock cursor otherwise
        }
    }

    void FixedUpdate()
    {
        // --- Apply Movement ---
        Vector3 newVelocity = moveInput * moveSpeed;
        newVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = newVelocity;

        // --- Apply Rotation ---
        Quaternion newRotation = Quaternion.Euler(0f, rotationY, 0f);
        rb.MoveRotation(newRotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Environment"))
        {
            onEnvironment = true;
        }
        else 
        {             
            onEnvironment = false;
        }   
    }
}

