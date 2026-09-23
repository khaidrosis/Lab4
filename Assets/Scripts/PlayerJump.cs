using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10f;
    public float groundCheckDistance = 1.1f;
    public LayerMask groundLayer = ~0; // default to everything

    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb == null)
            return;

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        bool pressed;
        if (Keyboard.current != null)
            pressed = Keyboard.current.spaceKey.wasPressedThisFrame;
        else
            pressed = Input.GetKeyDown(KeyCode.Space);

        if (pressed && isGrounded)
            jumpRequested = true;
    }

    void FixedUpdate()
    {
        if (jumpRequested && rb != null)
        {
            // Remove horizontal (ground-plane) velocity while preserving vertical velocity
            Vector3 horizontalVel = Vector3.ProjectOnPlane(rb.linearVelocity, Vector3.up);
            rb.linearVelocity -= horizontalVel;

            // Apply upward impulse
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpRequested = false;
        }
    }
}