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
    //public float distanciaAlcance;
    //public float vida;

    

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform; // Aseg�rate de que el jugador tenga la etiqueta "Player"
        //SetValues(); // Llama a SetValues para inicializar los valores extr�nsecos
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
        if (distanciaAlJugador < extrinseco.distanciaAlcance)
        {
            persiguiendo = true;
        }
        else if (distanciaAlJugador > extrinseco.distanciaAlcance)
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
            Salud saludJugador = other.GetComponent<Salud>();
            if (saludJugador != null)
            {
                saludJugador.PerderVida();
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
        //extrinseco.vida--;
        //if (extrinseco.vida <= 0)
        //{
        //    Morir();
        //}
    }

    void Morir()
    {
        Debug.Log("La abeja ha muerto");
        Destroy(gameObject);
    }
}
