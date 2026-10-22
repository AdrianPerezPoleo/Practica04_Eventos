using UnityEngine;

public class Ejercicio08_PlayerEndgame : MonoBehaviour
{
    private Ejercicio08_EndgameNotifier endgameNotifier;
    private Transform lastPosition;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = GameObject.FindWithTag("Final Position").transform;
        endgameNotifier = GameObject.FindWithTag("Endgame").GetComponent<Ejercicio08_EndgameNotifier>();
        endgameNotifier.OnEndgame += MoveToFinalPosition;
    }

    void MoveToFinalPosition()
    {
        rb.MovePosition(lastPosition.position);
        GetComponent<Ejercicio08_Movimiento>().speed = 0f;
    }

    void OnDestroy()
    {
        endgameNotifier.OnEndgame -= MoveToFinalPosition;
    }
}
