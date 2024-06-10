using Patterns.Observer.Interfaces;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Timer : MonoBehaviour, ISubject<float>
{
    private static Timer instance;
    private float tiempoTranscurrido = 0f;
    private bool juegoTerminado = false;

    public Timer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = this;
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

    public void AddObserver(IObserver<float> observer)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveObserver(IObserver<float> observer)
    {
        throw new System.NotImplementedException();
    }

    public void NotifyObservers()
    {
        throw new System.NotImplementedException();
    }
}