using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    //Modificar volumen con slider en men� de opciones
    public void cambiarVolumen(float volumen)
    {
        //iguala el volumen del audioMixer, con el par�metro que modifica el slider
        audioMixer.SetFloat("Volumen", volumen);
    }
}
