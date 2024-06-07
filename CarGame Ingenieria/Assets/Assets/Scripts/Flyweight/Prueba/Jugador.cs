using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public int maxVida = 5;
    public GameObject[] corazones; // Asigna los GameObjects de los corazones desde el inspector
    private int vidaActual;

    void Start()
    {
        vidaActual = maxVida;
        ActualizarCorazones();
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Abeja"))
        {
            PerderVida();
        }
    }
}
