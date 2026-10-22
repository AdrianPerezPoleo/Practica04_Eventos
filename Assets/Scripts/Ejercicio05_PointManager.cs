using System.Drawing;
using UnityEngine;

public class Ejercicio05_PointManager : MonoBehaviour
{
    private int totalPoints = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ejercicio05_EscudoRecolectable.OnShieldCollected += AddPoints;
    }

    void AddPoints(int points)
    {
        totalPoints += points;
        Debug.Log($"Se ha recogido un escudo. Nueva puntuación: {totalPoints}.");
    }

    void OnDestroy()
    {
        Ejercicio05_EscudoRecolectable.OnShieldCollected -= AddPoints;
    }
}
