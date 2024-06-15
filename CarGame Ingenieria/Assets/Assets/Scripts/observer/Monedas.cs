using System.Collections;
using System.Collections.Generic;
using Patterns.Observer.Interfaces;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public float velocidadRotacion = 100f; // Velocidad de rotación ajustable desde el Inspector
    public bool haSidoRecogida = false;
    

    void Update()
    {
        // Rotar la moneda alrededor del eje Y (vertical)
        if (!haSidoRecogida)
        {
            transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
        }
    }

}