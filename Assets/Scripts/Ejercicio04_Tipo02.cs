using UnityEngine;

public class Ejercicio04_Tipo02 : MonoBehaviour
{
    private Transform buildingTransform;
    private Ejercicio04_Notifier notifier;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        buildingTransform = GameObject.FindWithTag("Building").transform;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            notifier = player.GetComponent<Ejercicio04_Notifier>();
            if (notifier != null)
            {
                notifier.OnTargetApproached += LookBuilding;
            }
        }
    }

    void LookBuilding()
    {
        if (rb == null) return;
        rb.MoveRotation(Quaternion.LookRotation(buildingTransform.position));
    }

    void OnDestroy()
    {
        notifier.OnTargetApproached -= LookBuilding;
    }
}
