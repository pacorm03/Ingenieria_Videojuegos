using UnityEngine;

public class AbejaFlyweight : MonoBehaviour
{
    private Transform jugador;
    private bool persiguiendo = false;

    // Referencia al ScriptableObject
    [SerializeField] private AbejaDataSO extrinseco;

    // Intrinseco
    public float resistencia = 1;
    public float velocidad = 5;
    public float ataque = 1;

    // Extrinseco
    public float distanciaAlcance;
    public float vida;

    public void SetValues()
    {
        if (extrinseco != null)
        {
            distanciaAlcance = extrinseco.distanciaAlcance;
            vida = extrinseco.vida;
        }
        else
        {
            Debug.LogWarning("El ScriptableObject extrinseco no está asignado.");
        }
    }

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform; // Asegúrate de que el jugador tenga la etiqueta "Player"
        SetValues(); // Llama a SetValues para inicializar los valores extrínsecos
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

        transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Ajusta la velocidad de rotación según sea necesario

        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador < distanciaAlcance)
        {
            persiguiendo = true;
        }
        else if (distanciaAlJugador > distanciaAlcance)
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
            Debug.Log("Abeja colisiona con el jugador");
            JugadorObserver jugadorObserver = other.GetComponent<JugadorObserver>();
            if (jugadorObserver != null)
            {
                jugadorObserver.PerderVida();
                PerderVida();
            }
        }
        else if (other.CompareTag("Bala"))
        {
            Debug.Log("Abeja ha sido golpeada por una bala");
            PerderVida();
        }
    }

    void PerderVida()
    {
        vida--;
        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("La abeja ha muerto");
        Destroy(gameObject);
    }
}
