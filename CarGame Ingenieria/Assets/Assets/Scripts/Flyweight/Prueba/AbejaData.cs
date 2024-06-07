using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AbejaData", menuName = "ScriptableObjects/AbejaData", order = 1)]
public class AbejaData : ScriptableObject
{
    public string textura;
    public string modelo;
    public GameObject modelo3D; // Referencia al modelo 3D
}
