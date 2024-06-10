using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public Transform pausa;
    public Transform ajustes;


    //Modificar volumen con slider en menú de opciones
    public void cambiarVolumen(float volumen)
    {
        //iguala el volumen del audioMixer, con el parámetro que modifica el slider
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void ActivarPausa(bool isActive)
    {
        pausa.gameObject.SetActive(isActive);
    }

    public void ActivarAjustes(bool isActive)
    {
        ajustes.gameObject.SetActive(isActive);
    }

}
