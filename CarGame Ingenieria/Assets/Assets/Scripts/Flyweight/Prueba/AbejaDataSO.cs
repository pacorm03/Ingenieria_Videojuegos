using UnityEngine;

[CreateAssetMenu(fileName = "AbejaData", menuName = "ScriptableObjects/AbejaData", order = 1)]
public class AbejaDataSO : ScriptableObject
{
    [field: SerializeField] public int distanciaAlcance { get; set; }
    [field: SerializeField] public int Maxvida { get; set; }
}
