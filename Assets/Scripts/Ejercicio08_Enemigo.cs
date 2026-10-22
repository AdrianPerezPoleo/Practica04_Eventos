using UnityEngine;

public class Ejercicio08_Enemigo : MonoBehaviour
{
    public float speed = 2.0f;
    private Transform playerTransform;
    private bool followPlayer = false;
    private Rigidbody rb;
    private Ejercicio08_Limon lemonNotifier;
    private Ejercicio08_EndgameNotifier endgameNotifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        lemonNotifier = GameObject.FindWithTag("Lemon").GetComponent<Ejercicio08_Limon>();
        endgameNotifier = GameObject.FindWithTag("Endgame").GetComponent<Ejercicio08_EndgameNotifier>();
        Ejercicio08_MonedaRecolectable.OnCoinCollected += FollowPlayer;
        lemonNotifier.OnLemonTouched += StopFollowingPlayer;
        endgameNotifier.OnEndgame += StopFollowingPlayer;
    }

    void FollowPlayer(int points)
    {
        followPlayer = true;
    }

    void StopFollowingPlayer()
    {
        followPlayer = false;
    }

    void FixedUpdate()
    {
        if (rb == null) return;
        if (followPlayer)
        {
            Vector3 directionVector = playerTransform.position - transform.position;
            rb.MoveRotation(Quaternion.LookRotation(directionVector));
            rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);            
        }
    }

    void OnDestroy()
    {
        Ejercicio08_MonedaRecolectable.OnCoinCollected -= FollowPlayer;
        lemonNotifier.OnLemonTouched -= StopFollowingPlayer;
        endgameNotifier.OnEndgame -= StopFollowingPlayer;
    }
}
