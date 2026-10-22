using UnityEngine;
using TMPro;
public class Ejercicio06_PointView : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private Ejercicio05_PointManager playerPoints;

    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        playerPoints = GameObject.FindWithTag("Player").GetComponent<Ejercicio05_PointManager>();
        Ejercicio05_EscudoRecolectable.OnShieldCollected += UpdatePoints;
        
        UpdatePoints(0); 
    }

    void UpdatePoints(int points)
    {
        if (scoreText != null && playerPoints != null)
        {
            scoreText.text = $"Puntuación: {playerPoints.GetPoints()}";
        }
    }

    private void OnDestroy()
    {
        Ejercicio05_EscudoRecolectable.OnShieldCollected -= UpdatePoints;
    }
}