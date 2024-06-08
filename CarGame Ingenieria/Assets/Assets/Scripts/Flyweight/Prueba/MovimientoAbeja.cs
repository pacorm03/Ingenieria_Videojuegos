using UnityEngine;
using UnityEngine.UI;

public class MovimientoAbeja : MonoBehaviour
{
    public AbejaData abejaData; // Asignar desde el inspector o c�digo
    private float velocidad;
    private Transform jugador;
    private bool persiguiendo = false;
    private int vida;
    public Image barraDeVida; // Asignar el UI de la barra de vida desde el inspector

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform; // Aseg�rate de que el jugador tenga la etiqueta "Player"
        if (abejaData != null)
        {
            velocidad = abejaData.velocidad;
            vida = abejaData.vidaInicial;
            ActualizarBarraDeVida();
        }
        else
        {
            Debug.LogError("AbejaData no est� asignado.");
        }
    }

    void Update()
    {
        if (persiguiendo)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }

        transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Ajusta la velocidad de rotaci�n seg�n sea necesario

        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        persiguiendo = distanciaAlJugador < 10f;
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

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            Morir();
        }
        else
        {
            ActualizarBarraDeVida();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }

    void ActualizarBarraDeVida()
    {
        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)vida / abejaData.vidaInicial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // La colisi�n con el jugador ser� manejada por el script del jugador
        }
    }
}
