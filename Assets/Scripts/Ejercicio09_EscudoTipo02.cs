using UnityEngine;

public class Ejercicio09_EscudoTipo02 : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tipo 1"))
        {
            Renderer meshRenderer = collision.gameObject.GetComponentInChildren<Renderer>();
            meshRenderer.material.color = new Color(0.800f, 0.624f, 0.063f);
        }
    }
}
