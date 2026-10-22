using UnityEngine;

public class Ejercicio04_Notifier : MonoBehaviour
{
    public delegate void ProximityEventHandler();
    public event ProximityEventHandler OnTargetApproached;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building Entry"))
        {
            OnTargetApproached();
        }
    }
}
