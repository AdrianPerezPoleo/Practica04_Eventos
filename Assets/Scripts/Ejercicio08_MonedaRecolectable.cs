using UnityEngine;

public class Ejercicio08_MonedaRecolectable : MonoBehaviour
{
    public delegate void CollectCoinEventHandler(int points);
    public static event CollectCoinEventHandler OnCoinCollected;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Moneda 1"))
        {
            OnCoinCollected(10);
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Moneda 2"))
        {
            OnCoinCollected(5);
        }
    }
}
