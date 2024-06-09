using UnityEngine;
using UnityEngine.UI;


public class Jugador : MonoBehaviour
{
    public int maxVida = 5;
    public GameObject[] corazones;
    public Text contadorMonedasText;

    private int vidaActual;
    private int contadorMonedas = 0;

    void Start()
    {
        vidaActual = maxVida;
        ActualizarCorazones();
        ActualizarContadorMonedas();
    }

    void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(i < vidaActual);
        }
    }

    public void PerderVida()
    {
        if (vidaActual > 0)
        {
            vidaActual--;
            ActualizarCorazones();
            if (vidaActual <= 0)
            {
                Debug.Log("El jugador ha muerto");
            }
        }
    }

    public void RecogerMoneda()
    {
        contadorMonedas++;
        ActualizarContadorMonedas();
    }

    void ActualizarContadorMonedas()
    {
        if (contadorMonedasText != null)
        {
            contadorMonedasText.text = "Monedas: " + contadorMonedas.ToString();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Abeja"))
        {
            PerderVida();
            MovimientoAbeja movimientoAbeja = other.GetComponent<MovimientoAbeja>();
            if (movimientoAbeja != null)
            {
                movimientoAbeja.RecibirDanio(1); // cada vez que te pica pierde 1 de vida
            }
        }
    }
}

