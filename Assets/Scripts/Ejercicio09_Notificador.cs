using UnityEngine;

public class Ejercicio09_Notificador : MonoBehaviour
{
    public delegate void FollowFirstGroup();
    public event FollowFirstGroup OnFollowFirst;

    public delegate void FollowSecondGroup();
    public event FollowSecondGroup OnFollowSecond;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisión{collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("Tipo 1"))
        {
            OnFollowFirst();
        }
        if (collision.gameObject.CompareTag("Tipo 2"))
        {
            OnFollowSecond();
        }
    }
}
