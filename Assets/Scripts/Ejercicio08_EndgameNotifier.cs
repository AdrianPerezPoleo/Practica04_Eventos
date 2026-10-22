using UnityEngine;

public class Ejercicio08_EndgameNotifier : MonoBehaviour
{
    public delegate void EndgameEventHandler();
    public event EndgameEventHandler OnEndgame;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Ejercicio08_CoinCollector>().GetCoins() > 50)
        {
            OnEndgame();
        }
    }
}
