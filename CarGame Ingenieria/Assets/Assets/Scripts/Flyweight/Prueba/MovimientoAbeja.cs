using UnityEngine;
using UnityEngine.UI;

public class MovimientoAbeja : MonoBehaviour
{
    public AbejaData abejaData; // Asignar desde el inspector o código
    public AbejaFlyweight abejaFlyweight;
    private float _distanciaAlcance;
    private float _velocidad;
    private Transform _jugador;
    private bool _persiguiendo = false;
    private int _vida;
    public Image _barraDeVida; // Asignar el UI de la barra de vida desde el inspector

    void Start()
    {
        _jugador = GameObject.FindWithTag("Player").transform; // Asegúrate de que el jugador tenga la etiqueta "Player"
        if (abejaData != null)
        {
            _velocidad = abejaData.velocidad;
            _vida = abejaData.vidaInicial;
            ActualizarBarraDeVida();
        }
        else
        {
            Debug.LogError("AbejaData no está asignado.");
        }
    }

    void Update()
    {
        if (_persiguiendo)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }

        transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Ajusta la velocidad de rotación según sea necesario

        float distanciaAlJugador = Vector3.Distance(transform.position, _jugador.position);
        _distanciaAlcance = abejaFlyweight.distanciaAlcance;
        _persiguiendo = distanciaAlJugador < _distanciaAlcance;
    }

    void Patrullar()
    {
        transform.Translate(Vector3.forward * _velocidad * Time.deltaTime);
    }

    void PerseguirJugador()
    {
        Vector3 direccion = (_jugador.position - transform.position).normalized;
        transform.Translate(direccion * _velocidad * Time.deltaTime);
    }

    public void RecibirDanio(int cantidad)
    {
        _vida -= cantidad;
        if (_vida <= 0)
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
        if (_barraDeVida != null)
        {
            _barraDeVida.fillAmount = (float)_vida / abejaData.vidaInicial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // La colisión con el jugador será manejada por el script del jugador
        }
    }
}
