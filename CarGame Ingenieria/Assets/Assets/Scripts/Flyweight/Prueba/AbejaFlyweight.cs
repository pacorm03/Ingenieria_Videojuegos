using UnityEngine;

public class AbejaFlyweight : IAbejaFlyweight
{
    private AbejaData data;
    public string name = "Abeja";
    public string description = "Abeja que ataca y persigue al jugador para hacerle daño";
    public float distanciaAlcance = 30f;

    public AbejaFlyweight(AbejaData data)
    {
        this.data = data;
    }

    public void Operar(Vector3 posicion, float velocidad)
    {
        
    }
}
