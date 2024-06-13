using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public Transform pausa;
    public Transform ajustes;
    public Transform creditos;
    public Transform menuInicio;



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
    public void ActivarCreditos(bool isActive)
    {
        creditos.gameObject.SetActive(isActive);
    }

    public void ActivarMenuInicio(bool isActive)
    {
        menuInicio.gameObject.SetActive(isActive);
    }
}
