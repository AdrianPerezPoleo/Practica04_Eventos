using UnityEngine;

public class Ejercicio01_Notificador : MonoBehaviour
{

    public delegate void FollowDelegate();
    public event FollowDelegate OnFollow;
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnFollow();
        }
    }
}
