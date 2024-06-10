using UnityEngine;

[CreateAssetMenu(fileName = "AbejaData", menuName = "ScriptableObjects/AbejaData", order = 1)]
public class AbejaDataSO : ScriptableObject
{
    //[Header("Valores Extrínsecos Abejas")]
    //public GameObject modelo3D;
    [field: SerializeField] public float distanciaAlcance { get; set; }
    [field: SerializeField] public float Maxvida { get; set; }
    



}
