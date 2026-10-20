using UnityEngine;

public class Ejercicio03_EscudoTipo02 : MonoBehaviour
{
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
            Debug.Log("Colisión.");
            Renderer meshRenderer = GetComponent<Renderer>();
            Debug.Log($"Color antiguo: {meshRenderer.material.color}");
            meshRenderer.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Debug.Log($"Color Nuevo: {meshRenderer.material.color}");
        }
    }
}
