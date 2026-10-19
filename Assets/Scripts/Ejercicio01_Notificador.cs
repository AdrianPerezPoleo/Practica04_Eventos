using UnityEngine;

public class Ejercicio01_Notificador : MonoBehaviour
{

    public delegate void follow();
    public static event follow OnFollow;
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Persecución Activada");
            OnFollow();
        }
    }
}
