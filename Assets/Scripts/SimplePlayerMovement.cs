using UnityEngine;
using UnityEngine.InputSystem;
public class SimplePlayerMovement : MonoBehaviour
{
    public float moveForce = 10f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        moveDirection = Vector3.zero;
        if (Keyboard.current == null)
            return;
        // Use the object's local axes so "forward" follows the player's facing direction
        // right  -> D key or Right Arrow
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveDirection += transform.right;
        // left   -> A key or Left Arrow
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveDirection -= transform.right;
        // forward -> W key or Up Arrow
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveDirection += transform.forward;
        // backward -> S key or Down Arrow
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveDirection -= transform.forward;
        moveDirection = moveDirection.normalized;
    }
    void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveForce, ForceMode.Acceleration);
    }
}
