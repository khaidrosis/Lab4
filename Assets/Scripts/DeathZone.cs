using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public float deathY = -10f;

    private Vector3 spawnPoint;
    private Transform playerTransform;
    private Rigidbody playerRb;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("DeathZone: no GameObject tagged 'Player' found.");
            return;
        }

        playerTransform = player.transform;
        playerRb = player.GetComponent<Rigidbody>();
        spawnPoint = playerTransform.position;
    }

    void Update()
    {
        if (playerTransform == null) return;

        if (playerTransform.position.y < deathY)
        {
            if (playerRb != null)
            {
                // Clear motion and teleport using the Rigidbody (safer for physics)
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
                playerRb.position = spawnPoint;
            }
            else
            {
                // Fallback if no Rigidbody
                playerTransform.position = spawnPoint;
            }
        }
    }
}