using UnityEngine;

public class Ejercicio08_DirectionalLight : MonoBehaviour
{
    private Ejercicio08_EndgameNotifier endgameNotifier;
    private Light light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        endgameNotifier = GameObject.FindWithTag("Endgame").GetComponent<Ejercicio08_EndgameNotifier>();
        endgameNotifier.OnEndgame += MakeNight;
    }

    void MakeNight()
    {
        light.intensity = 0.05f;
        light.color = new Color(1.0f, 1.0f, 1.0f);
    }

    void OnDestroy()
    {
        endgameNotifier.OnEndgame -= MakeNight;
    }
}
