using UnityEngine;

public class Ejercicio03_Notificador : MonoBehaviour
{
    public delegate void FollowFirstGroup();
    public event FollowFirstGroup OnFollowFirst;

    public delegate void FollowSecondGroup();
    public event FollowSecondGroup OnFollowSecond;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Tipo 1"))
        {
            OnFollowFirst();
        }
        if (col.gameObject.CompareTag("Tipo 2"))
        {
            OnFollowSecond();
        }
    }
}
