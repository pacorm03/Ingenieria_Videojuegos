// MovimientoAbeja.cs
using UnityEngine;

public class MovimientoAbeja : MonoBehaviour
{
    private float velocidad = 10;
    private Transform jugador;
    private bool persiguiendo = false;

    public void SetVelocidad(float nuevaVelocidad)
    {
        velocidad = nuevaVelocidad;
    }

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform; // Asegúrate de que el jugador tenga la etiqueta "Player"
    }

    void Update()
    {
        // Mover la abeja en la dirección deseada con la velocidad especificada
        if (persiguiendo)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }

        // Rotar la abeja sobre su propio eje (eje Y en este caso)
        transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Ajusta la velocidad de rotación según sea necesario

        // Verificar distancia al jugador para cambiar comportamiento
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador < 10f)
        {
            persiguiendo = true;
        }
        else if (distanciaAlJugador > 10f)
        {
            persiguiendo = false;
        }
    }

    void Patrullar()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void PerseguirJugador()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // La colisión con el jugador será manejada por el script del jugador
        }
    }
}
