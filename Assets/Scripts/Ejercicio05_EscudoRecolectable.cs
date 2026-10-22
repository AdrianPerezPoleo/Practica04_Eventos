using UnityEngine;

public class Ejercicio05_EscudoRecolectable : MonoBehaviour
{
    public delegate void CollectShieldEventHandler(int points);
    public static event CollectShieldEventHandler OnShieldCollected;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Escudo Tipo 1"))
        {
            OnShieldCollected(5);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Escudo Tipo 2"))
        {
            OnShieldCollected(10);
        }
    }
}
