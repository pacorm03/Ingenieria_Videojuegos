using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Juego : MonoBehaviour
{
    public AbejaData[] abejasData; // Asigna esto desde el inspector en Unity.
    private FlyweightFactory factory = new FlyweightFactory();

    public void CrearAbeja(AbejaData data, Vector3 posicion, float velocidad)
    {
        IAbejaFlyweight abeja = factory.GetAbejaFlyweight(data);
        abeja.Operar(posicion, velocidad);
    }

    void Start()
    {
        // Ejemplo de uso
        if (abejasData.Length > 0)
        {
            CrearAbeja(abejasData[0], new Vector3(0, 0, 0), 5.0f);
            CrearAbeja(abejasData[0], new Vector3(1, 0, 0), 7.0f);
        }
    }
}

