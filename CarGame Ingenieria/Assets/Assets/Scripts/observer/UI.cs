using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Observer.Interfaces;
using Unity.VisualScripting;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class UI : MonoBehaviour, IObserver<float>
{
    public int maxVida;
    public GameObject[] corazones; //array para gestionar la visibilidad de los corazones
    public Text tiempoTranscurridoText; // Asigna el texto del contador desde el inspector

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
        Salud saludJugador = player.GetComponent<Salud>();
         
        maxVida= (int)saludJugador.maxVida; //maxima vida del jugador preestablecida en su clase
        Debug.Log($"Inicializando vidaActual con maxVida = {maxVida}");

        //añadimos la ui a la lista de observadores del sujeto player
        saludJugador.AddObserver(this);
      
        
    }
    void Update()
    {
       
    }
    //metodo para actualizar la UI
    public void UpdateObserver(float data) //recibe el valor de la vida
    {
        
        for (int i = 0; i < maxVida; i++) 
        {
            // si i es menor que la vida actual significa que no ha perdido aun ese 
            corazones[i].SetActive(i < data);
            Debug.Log("Observer actualizado");
        }
     
    }

}
