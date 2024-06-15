using UnityEngine;

public class AbejaFlyweight : MonoBehaviour
{
    private Transform jugador;
    private bool persiguiendo = false;

    // Referencia al ScriptableObject
    [SerializeField] private AbejaDataSO extrinseco;

    // Intrinseco
    public int resistencia = 1;
    public float velocidad = 5;
    public int ataque = 1;
    public int vidaActual;

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform;
        vidaActual = extrinseco.Maxvida;
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

        transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Ajusta la velocidad de rotacion segun sea necesario

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
            Salud salud = other.GetComponent<Salud>();
            if (salud != null)
            {
                salud.PerderVida();
                PerderVidaAbeja();
            }
        }
        else if (other.CompareTag("Bala"))
        {
            Debug.Log("Abeja ha sido golpeada por una bala");
            PerderVidaAbeja();
        }
    }

    void PerderVidaAbeja()
    {
        vidaActual--;
        if (vidaActual <= 0)
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
