using UnityEngine;

public class Ejercicio08_CoinCollector : MonoBehaviour
{
    private int totalCoins = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ejercicio08_MonedaRecolectable.OnCoinCollected += AddCoins;
    }

    void AddCoins(int points)
    {
        totalCoins += points;
        Debug.Log($"Se ha recogido una moneda. Nueva puntuación: {totalCoins}.");
        GetComponent<Ejercicio08_Movimiento>().speed = GetComponent<Ejercicio08_Movimiento>().speed * 0.9f;
    }

    public int GetCoins()
    {
        return totalCoins;
    }

    void OnDestroy()
    {
        Ejercicio08_MonedaRecolectable.OnCoinCollected -= AddCoins;
    }
}
