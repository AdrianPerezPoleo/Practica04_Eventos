using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ejercicio01_Tipo01 : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;
    public GameObject target;

    private Ejercicio01_Notificador notifier;

    private bool followTarget = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notifier = GameObject.FindWithTag("Cylinder").GetComponent<Ejercicio01_Notificador>();
        rb = GetComponent<Rigidbody>();
        notifier.OnFollow += follow;
    }

    void FixedUpdate()
    {
        if (followTarget && target != null)
        {
            Vector3 directionVector = target.transform.position - transform.position;
            directionVector.y = 0; 
            if (directionVector != Vector3.zero)
            {
                rb.MoveRotation(Quaternion.LookRotation(directionVector));
            }
            rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
        }
    }

    void follow()
    {
        if (target == null) return;
        followTarget = true;
    }

    void OnDestroy()
    {
        notifier.OnFollow -= follow;
    }
}
