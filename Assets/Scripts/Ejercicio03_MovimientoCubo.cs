using UnityEngine;

public class Ejercicio03_MovimientoCubo : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;
    private float verticalAxis;
    private float horizontalAxis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        verticalAxis = Input.GetAxisRaw("Vertical");
        horizontalAxis = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (rb == null) return;
        Vector3 directionVector = new Vector3(horizontalAxis, 0, verticalAxis);
        rb.MovePosition(transform.position + directionVector.normalized * speed * Time.fixedDeltaTime);
    }
}
