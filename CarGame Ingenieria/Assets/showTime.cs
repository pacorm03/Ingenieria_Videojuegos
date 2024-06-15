using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showTime : MonoBehaviour
{
    
    public Text tiempoTranscurridoText; // Asigna el texto del contador desde el inspector
    void Start()
    {
        float tiempo = Timer.Instance.TiempoTranscurrido();
        tiempoTranscurridoText.text = $"Tiempo: {tiempo.ToString("F2")} segundos"; // Mostrar el tiempo con 2 decimales  
    }

    
}
