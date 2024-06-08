using UnityEngine;

[CreateAssetMenu(fileName = "AbejaData", menuName = "ScriptableObjects/AbejaData", order = 1)]
public class AbejaData : ScriptableObject
{
    public GameObject modelo3D;
    public float resistencia;
    public float velocidad;
    public int vidaInicial; // Nueva propiedad para la vida inicial de las abejas
}
