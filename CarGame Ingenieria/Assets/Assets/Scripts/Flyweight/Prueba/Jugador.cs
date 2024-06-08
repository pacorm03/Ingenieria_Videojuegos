// Jugador.cs
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public int maxVida = 5;
    public GameObject[] corazones; // Asigna los GameObjects de los corazones desde el inspector
    public Text contadorMonedasText; // Asigna el texto del contador desde el inspector

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
            if (i < vidaActual)
            {
                corazones[i].SetActive(true);
            }
            else
            {
                corazones[i].SetActive(false);
            }
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
                // Manejar la muerte del jugador, si es necesario
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
        }
    }
}
