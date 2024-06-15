using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Observer.Interfaces;
using Unity.VisualScripting;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class UIMonedas : MonoBehaviour, IObserver<float>
{
    public Text contadorMonedasText; // Asigna el texto del contador desde el inspector

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");

        MonedasJugador monedasJugador = player.GetComponent<MonedasJugador>();

        //añadimos la ui a la lista de observadores del sujeto player y del sujeto moneda
        monedasJugador.AddObserver(this);

    }
    void Update()
    {
        /*if (tiempoTranscurridoText != null)
        {
            //float tiempo = Timer.Instance.TiempoTranscurrido();
            //tiempoTranscurridoText.text = $"Tiempo: {tiempo.ToString("F2")} segundos"; // Mostrar el tiempo con 2 decimales
        }*/
    }
    //metodo para actualizar la UI
    public void UpdateObserver(float data) //recibe el valor de la vida
    {

        if (contadorMonedasText != null)//actualizar contadador de monedas
        {
            contadorMonedasText.text = "Monedas: " + data.ToString();
        }

    }
}
