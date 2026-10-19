using UnityEngine;

public class Ejercicio01_Tipo02 : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;
    private Transform target;
    private bool followTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
        Ejercicio01_Notificador.OnFollow += follow;
    }

    void FixedUpdate()
    {
        if (followTarget && target != null)
        {
            Vector3 directionVector = target.transform.position - transform.position;
            directionVector.y = 0; 
            rb.linearVelocity = directionVector.normalized * speed;
        }
    }
    void follow()
    {
        if (target == null) return;
        followTarget = true;
    }

    void OnDestroy()
    {
        Ejercicio01_Notificador.OnFollow -= follow;
    }
}
