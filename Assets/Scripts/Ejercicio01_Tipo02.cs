using UnityEngine;

public class Ejercicio01_Tipo02 : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;
    private Transform target;
    private bool followTarget;
    private Ejercicio01_Notificador notifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notifier = GameObject.FindWithTag("Cylinder").GetComponent<Ejercicio01_Notificador>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
        notifier.OnFollow += follow;
    }

    void FixedUpdate()
    {
        if (followTarget && target != null)
        {
            Vector3 directionVector = target.position - transform.position;
            directionVector.y = 0;

            if (directionVector != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionVector);
                rb.MoveRotation(targetRotation);
            }

            Vector3 nextPosition = transform.position + transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(nextPosition);
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
