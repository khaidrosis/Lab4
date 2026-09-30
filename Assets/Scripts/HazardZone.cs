using UnityEngine;
public class HazardZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        EnergyCore core = other.GetComponent<EnergyCore>();
        if (core != null)
        {
            Debug.Log("Energy Core lost!");
            core.ResetCore();
        }
    }
}