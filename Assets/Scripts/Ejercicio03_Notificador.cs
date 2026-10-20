using UnityEngine;

public class Ejercicio03_Notificador : MonoBehaviour
{
    public delegate void FollowFirstGroup();
    public static event FollowFirstGroup OnFollowFirst;

    public delegate void FollowSecondGroup();
    public static event FollowSecondGroup OnFollowSecond;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tipo 1"))
        {
            OnFollowFirst?.Invoke();
        }
        if (collision.gameObject.CompareTag("Tipo 2"))
        {
            OnFollowSecond?.Invoke();
        }
    }
}
