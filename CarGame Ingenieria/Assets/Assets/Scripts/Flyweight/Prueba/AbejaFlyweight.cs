using UnityEngine;

public class AbejaFlyweight : IAbejaFlyweight
{
    private AbejaData data;
    private string name = "Abeja";
    private string description = "Abeja que ataca y persigue al jugador para hacerle daño";
    private float distanciaAlJugador = 10f;

    public AbejaFlyweight(AbejaData data)
    {
        this.data = data;
    }

    public void Operar(Vector3 posicion, float velocidad)
    {
        
    }
}
