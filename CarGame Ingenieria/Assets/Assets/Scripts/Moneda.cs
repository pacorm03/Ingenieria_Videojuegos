// Moneda.cs
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float velocidadRotacion = 100f; // Velocidad de rotación ajustable desde el Inspector

    void Update()
    {
        // Rotar la moneda alrededor del eje Y (vertical)
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        //si el jugador recoge la moneda se destruye
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.RecogerMoneda();
                Destroy(gameObject);
            }
        }
    }
}
