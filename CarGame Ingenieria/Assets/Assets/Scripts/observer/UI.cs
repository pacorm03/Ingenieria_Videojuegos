using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Observer.Interfaces;
using Unity.VisualScripting;
using TMPro;
using System.Linq;

public class UI : MonoBehaviour, IObserver<float>
{
    public int maxVida;
    public GameObject[] corazones; //array para gestionar la visibilidad de los corazones
    private JugadorObserver jugadorObserver;
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        //añadimos la ui a la lista de observadores del sujeto player
        JugadorObserver jugadorObserver = player.GetComponent<JugadorObserver>();
        maxVida= (int)jugadorObserver.maxVida; //maxima vida del jugador preestablecida en su clase
        Debug.Log($"Inicializando vidaActual con maxVida = {maxVida}");
        jugadorObserver.AddObserver(this);
        
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
