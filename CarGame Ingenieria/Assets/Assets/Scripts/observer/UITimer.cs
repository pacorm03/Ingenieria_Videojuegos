using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Observer.Interfaces;
using Unity.VisualScripting;
using TMPro;
using System.Linq;
using UnityEngine.UI;
//using UnityEditor.Experimental.GraphView;

public class UITimer : MonoBehaviour, IObserver<float>
{
    
    public Text tiempoTranscurridoText; // Asigna el texto del contador desde el inspector
    private Timer timer; // Referencia al temporizador

    Salud saludJugador;
    MonedasJugador monedasJugador;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");

        monedasJugador = player.GetComponent<MonedasJugador>();
        monedasJugador.AddObserver(this);

        saludJugador = player.GetComponent<Salud>();
        saludJugador.AddObserver(this);

    }

    void Start()
    {
        Invoke("IniciarTemporizador", 3f);
        timer = Timer.Instance; // Obtener instancia del temporizador


    }
    void IniciarTemporizador()
    {
        timer.ReiniciarTimer(); // Reiniciar el temporizador al inicio
    }

    public void MostrarResultado()
    {
        float tiempo = timer.TiempoTranscurrido();
        Debug.Log($"El juego ha terminado en {tiempo} segundos.");
    }


    void Update()
    {
        if (tiempoTranscurridoText != null)
        {
            float tiempo = Timer.Instance.TiempoTranscurrido();
            tiempoTranscurridoText.text = $"Tiempo: {tiempo.ToString("F2")} segundos"; // Mostrar el tiempo con 2 decimales 
        }
    }

    public void UpdateObserver(float value)
    {
        if (monedasJugador != null && monedasJugador.contadorMonedas ==monedasJugador.totalMonedas)
        {
            Timer.Instance.DetenerTimer();
        }

        if (saludJugador != null && saludJugador.vidaActual <= 0)
        {
            Timer.Instance.DetenerTimer();
        }

    }



}
