using UnityEngine;
using UnityEngine.InputSystem;

public class CamCam : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // assign the player (for yaw). If null, will rotate parent if present.

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 delta;
        if (Mouse.current != null)
            delta = Mouse.current.delta.ReadValue() * mouseSensitivity * Time.deltaTime;
        else
            delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity * Time.deltaTime;

        float mouseY = delta.y;
        float mouseX = delta.x;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (playerBody != null)
            playerBody.Rotate(Vector3.up * mouseX);
        else
            transform.parent?.Rotate(Vector3.up * mouseX);
    }
}
