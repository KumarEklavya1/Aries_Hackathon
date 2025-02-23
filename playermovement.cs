using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Mouse sensitivity
    public Transform playerBody;           // Reference to the player's body (used to rotate the body)
    public float moveSpeed = 5f;           // Movement speed
    public float jumpHeight = 2f;          // Jump height
    public Transform groundCheck;          // Reference to ground detection
    public LayerMask groundMask;           // Layer mask for checking if grounded

    private float xRotation = 0f;          // To limit the up/down rotation
    private Rigidbody rb;                  // Reference to the player's Rigidbody component
    private bool isGrounded;               // Boolean to check if the player is grounded
    private float groundDistance = 0.4f;   // Distance to check for ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    // Get the Rigidbody component
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
        Cursor.visible = false;                  // Hide cursor during gameplay
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
        Jump();
    }

    // Handle mouse look (camera rotation)
    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // Up/down movement for camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Clamp to prevent full rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Apply up/down rotation
        playerBody.Rotate(Vector3.up * mouseX); // Left/right movement for the player body
    }

    // Handle movement (WASD keys)
    void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  // Check if grounded

        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");    // W/S or Forward/Backward

        Vector3 move = transform.right * moveX + transform.forward * moveZ;  // Calculate movement direction
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);   // Move player with Rigidbody
    }

    // Handle jumping (spacebar)
    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);  // Apply upward force to jump
        }
    }
}
