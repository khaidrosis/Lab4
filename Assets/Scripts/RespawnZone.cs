using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    public float deathY = -10f;

    private Vector3 spawnPoint;
    private Transform ballTransform;
    private Rigidbody ballRb;

    void Start()
    {
        var ball = GameObject.FindGameObjectWithTag("Respawn");
        if (ball == null)
        {
            Debug.LogWarning("RespawnZone: no GameObject tagged 'Respawn' found.");
            return;
        }

        ballTransform = ball.transform;
        ballRb = ball.GetComponent<Rigidbody>();
        spawnPoint = ballTransform.position;
    }

    void Update()
    {
        if (ballTransform == null) return;

        if (ballTransform.position.y < deathY)
        {
            if (ballRb != null)
            {
                ballRb.linearVelocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                ballRb.position = spawnPoint;
            }
            else
            {
                ballTransform.position = spawnPoint;
            }
        }
    }
}