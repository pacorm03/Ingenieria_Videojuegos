using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer instance;
    private float tiempoTranscurrido = 0f;
    private bool juegoTerminado = false;

    public static Timer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Timer").AddComponent<Timer>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            tiempoTranscurrido += Time.deltaTime;
        }
    }

    public void ReiniciarTimer()
    {
        tiempoTranscurrido = 0f;
        juegoTerminado = false;
    }

    public float TiempoTranscurrido()
    {
        return tiempoTranscurrido;
    }

    public void DetenerTimer()
    {
        juegoTerminado = true;
    }

    // Implementación del método de actualización del observador
    public void UpdateObserver(float data, float data1)
    {
        // No necesitamos hacer nada en este método para el temporizador
    }
}