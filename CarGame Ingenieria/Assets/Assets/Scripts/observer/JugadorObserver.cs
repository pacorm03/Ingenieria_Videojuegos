using System.Collections;
using System.Collections.Generic;
using Patterns.Observer.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class JugadorObserver : MonoBehaviour, ISubject <float>
{   
    [SerializeField]public float maxVida = 5;
    public float vidaActual;
    public float tiempoDeEspera = 2; //tiempo que espera para volver a detectar la colision 
                                  // para que el jugador tenga tiempo para reaccionar antes de que le quite mas corazones el mismo enemigo
    public float tiempoTranscurrido;
    public int contadorMonedas = 0;
    private Timer timer; // Referencia al temporizador

    void Start()
    {
        vidaActual = maxVida;

        // Invocar la función para iniciar el temporizador después de 3 segundos
        Invoke("IniciarTemporizador", 3f);
       
    }
    void IniciarTemporizador()
    {
        timer = Timer.Instance; // Obtener instancia del temporizador
        timer.ReiniciarTimer(); // Reiniciar el temporizador al inicio
    }
    void Update()
    {
      
    }
    public void PerderVida()
    {
        if (vidaActual > 0)
        {
            vidaActual--;
            //cuando pierde vida notifica a los observadores
            NotifyObservers();
        }
        else
        {
            Debug.Log("El jugador ha muerto");
        }
    }
    public void RecogerMoneda(GameObject moneda)
    {
        MonedaObserver monedaObserver = moneda.GetComponent<MonedaObserver>();
        //comprobamos si ya ha recogido la moneda para evitar sumar monedas de mas
        if (monedaObserver != null && !monedaObserver.haSidoRecogida)
        {
            contadorMonedas++;
            monedaObserver.Recoger();

            // cuando recoge una moneda lo notifica a los observadores
            NotifyObservers();
            Destroy(moneda);
        }
    }
    void TerminarJuego()
    {
        // Aquí puedes agregar cualquier acción que desees realizar al finalizar el juego
        timer.DetenerTimer(); // Detener el temporizador
        MostrarResultado();
        NotifyObservers(); // Notificar a los observadores
    }

    void MostrarResultado()
    {
        float tiempo = timer.TiempoTranscurrido();
        Debug.Log($"El juego ha terminado en {tiempo} segundos.");
    }

    //DETECTOR DE COLISIONES
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Abeja")) //si choca con la abeja pierde vida
        {   
            Debug.Log("choque detectado");
            if (Time.time - tiempoTranscurrido >= tiempoDeEspera)
            {
                
                PerderVida();
                tiempoTranscurrido = Time.time; //actualizar el tiempo transcurrido
            }
                
        }

        if (other.CompareTag("Moneda"))
        {
            Debug.Log("Moneda recogida");
            RecogerMoneda(other.gameObject);
        }
    }
    
   
    //PATRON OBSERVER (el jugador es el sujeto observado)
    //creamos una lista de observers para almacenarlos
    private List<IObserver<float>> _observers = new List<IObserver<float>>();

    public void AddObserver(IObserver<float> observer)
    {
        _observers.Add(observer); //añade el observador
        Debug.Log("observador añadido");
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
            observer?.UpdateObserver(vidaActual, contadorMonedas, timer.TiempoTranscurrido());
        }

    }

}



