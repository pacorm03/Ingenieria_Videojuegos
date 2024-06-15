using System.Collections;
using System.Collections.Generic;
using Patterns.Observer.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class Salud : MonoBehaviour, ISubject <float>
{   
    [SerializeField]public float maxVida = 5;
    public float vidaActual;
    private bool puedePerderVida = true;
    public float tiempoDeEspera = 2.0f; // Tiempo de espera entre pérdidas de vida


    //private Timer timer; // Referencia al temporizador

    void Start()
    {
        vidaActual = maxVida;

        // Invocar la función para iniciar el temporizador después de 3 segundos
        //Invoke("IniciarTemporizador", 3f);
       
    }
    /*void IniciarTemporizador()
    {
        //timer = Timer.Instance; // Obtener instancia del temporizador
        timer.ReiniciarTimer(); // Reiniciar el temporizador al inicio
    }*/
    void Update()
    {
      
    }
    public void PerderVida()
    {
        if (vidaActual > 0 && puedePerderVida)
        {
            vidaActual--;
            //cuando pierde vida notifica a los observadores
            NotifyObservers();
            puedePerderVida = false;
            Invoke("ReactivatePerderVida", tiempoDeEspera);
        }
        else
        {
            //TerminarJuego();
            Debug.Log("El jugador ha muerto");
        }
    }
    private void ReactivatePerderVida()
    {
        puedePerderVida = true;
    }
    void TerminarJuego()
    {
        
        //timer.DetenerTimer(); // Detener el temporizador
        //MostrarResultado();
        NotifyObservers(); // Notificar a los observadores
    }

    /*void MostrarResultado()
    {
        float tiempo = timer.TiempoTranscurrido();
        Debug.Log($"El juego ha terminado en {tiempo} segundos.");
    }*/

    
    //DETECTOR DE COLISIONES
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Abeja")) //si choca con la abeja pierde vida
        {
            Debug.Log("choque detectado");
            PerderVida();
        }
    
    }
    
   
    //PATRON OBSERVER (la vida del jugador es uno de los sujetos observados)
    //creamos una lista de observers para almacenarlos
    private List<IObserver<float>> _observers = new List<IObserver<float>>();

    public void AddObserver(IObserver<float> observer)
    {
        _observers.Add(observer); //añade el observador
        Debug.Log("observador añadido al sujeto Salud");
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
            Debug.Log("actualizado en jugadorObserver");
            //verifica hay algun observador en la lista, si lo hay, le pasa el valor de la vida que va actualizandose
            observer?.UpdateObserver(vidaActual);
        }

    }

}



