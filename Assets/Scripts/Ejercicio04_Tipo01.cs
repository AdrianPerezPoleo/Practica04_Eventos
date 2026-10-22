using UnityEngine;

public class Ejercicio04_Tipo01 : MonoBehaviour
{

    public Transform shieldTransform;
    private Ejercicio04_Notifier notifier;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            notifier = player.GetComponent<Ejercicio04_Notifier>();
            if (notifier != null)
            {
                notifier.OnTargetApproached += GetToSafety;
            }
        }
    }

    void GetToSafety()
    {
        if (rb == null) return;
        rb.MovePosition(shieldTransform.position + GenerateRandomVector());
    }

    Vector3 GenerateRandomVector()
    {
        float x = Random.Range(0f, 5f);
        float z = Random.Range(0f, 5f);
        return new Vector3(x, 0, z);
    }

    void OnDestroy()
    {
        notifier.OnTargetApproached -= GetToSafety;
    }
}
