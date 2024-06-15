using Patterns.Observer.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer instance;
    private float tiempoTranscurrido = 0f;
    private bool juegoTerminado = false;

    public static Timer Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
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


}