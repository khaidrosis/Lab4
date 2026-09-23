using UnityEngine;
using UnityEngine.InputSystem;
public class RotatingObstacle : MonoBehaviour
{
    public float rotationSpeed = 90f;
    [SerializeField] private bool isActive = true;
    [SerializeField] private bool isX = false;
    [SerializeField] private bool isY = true;
    [SerializeField] private bool isZ = false;

    void Start()
    {
        Debug.Log("RotatingObstacle is running");
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            isActive = !isActive;
        }

        // x axis rotate
        if (isActive || isX)
        {
            float rotationThisFrame =
            rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationThisFrame, 0f, 0f);
        }

        // y axis rotate
        if (isActive || isY)
        {
            float rotationThisFrame =
            rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationThisFrame, 0f);
        }

        // z axis rotate
        if (isActive || isZ)
        {
            float rotationThisFrame =
            rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, rotationThisFrame);
        }
    }
}
