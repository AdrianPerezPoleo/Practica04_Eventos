using UnityEngine;

public class Ejercicio08_Limon : MonoBehaviour
{
    public delegate void TouchLemonEventHandler();
    public event TouchLemonEventHandler OnLemonTouched;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLemonTouched();
        }
    }
}
