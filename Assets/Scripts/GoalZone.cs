using UnityEngine;
public class GoalZone : MonoBehaviour
{
    public int score = 0;
    void OnTriggerEnter(Collider other)
    {
        EnergyCore core = other.GetComponent<EnergyCore>();
        if (core != null)
        {
            score++;
            Debug.Log(
            "Energy Core delivered! Score: " + score
            );
            core.ResetCore();
        }
    }
}