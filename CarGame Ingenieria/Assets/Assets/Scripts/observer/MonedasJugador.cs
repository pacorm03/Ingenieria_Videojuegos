using System.Collections;
using System.Collections.Generic;
using Patterns.Observer.Interfaces;
using UnityEngine;

public class MonedasJugador : MonoBehaviour, ISubject<float>
{
   
    public float contadorMonedas = 0;
    public Transform padreDeMonedas;
    public int totalMonedas;

    void Start()
    {
        if (padreDeMonedas != null)
        {
            totalMonedas = padreDeMonedas.childCount;
            contadorMonedas = totalMonedas; // Inicializar el contador de monedas con el total
        }
        else
        {
            Debug.LogError("Padre de las monedas no asignado.");
        }
    }
    public void RecogerMoneda(GameObject moneda)
    {
        Monedas monedasJugador = moneda.GetComponent<Monedas>();
        //comprobamos si ya ha recogido la moneda para evitar sumar monedas de mas
        if (monedasJugador != null && !monedasJugador.haSidoRecogida)
        {
            contadorMonedas++;
            monedasJugador.haSidoRecogida = true;

            // cuando recoge una moneda lo notifica a los observadores
            Destroy(moneda);
            NotifyObservers();
            
        }
    }

  
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))
        {
            Debug.Log("Moneda recogida");
            RecogerMoneda(other.gameObject);
            
        }
    }


    //PATRON OBSERVER (las monedas recogidas del jugador es uno de los sujetos observados)
    //creamos una lista de observers para almacenarlos
    private List<IObserver<float>> _observers = new List<IObserver<float>>();

    public void AddObserver(IObserver<float> observer)
    {
        _observers.Add(observer); //añade el observador
        Debug.Log("observador añadido al sujeto Monedas");
    }
    public void RemoveObserver(IObserver<float> observer)
    {
        _observers.Remove(observer); //quita el observador
    }
    public void NotifyObservers()
    {
        //a cada observador de la lista, le envia una notificacion para actualizarlo
        foreach (IObserver<float> observer in _observers)
        {
            Debug.Log("actualizado en MonedasJugador");
            //verifica hay algun observador en la lista, si lo hay, le pasa el valor de las monedas recogidas que va actualizandose
            observer?.UpdateObserver(contadorMonedas);
        }

    }

}
