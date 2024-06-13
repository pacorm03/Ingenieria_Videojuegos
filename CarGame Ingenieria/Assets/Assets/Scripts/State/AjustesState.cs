using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AjustesState : SceneBaseState
{
    GameObject menuAjustes;

    GameObject botonVolver;
    Button botonVolverComp;


    SceneStateManager context;

    Scene sceneMenuInicio;
    Scene sceneJuego;
      
    public override void EnterState(SceneStateManager scene)
    {
        context = scene;
        Debug.Log("Estado: Menu Ajustes");

        sceneMenuInicio = SceneManager.GetSceneByBuildIndex(0);
        sceneJuego = SceneManager.GetSceneByBuildIndex(1);

        if (sceneMenuInicio.isLoaded)
        {
            menuAjustes = GameObject.Find("Menu");
            menuAjustes.GetComponent<Opciones>().ActivarAjustes(true);
            //Volver a Menu Principal
            if (botonVolver == null)
            {
                botonVolver = GameObject.Find("BotonVolver");
            }
            if (botonVolver != null)
            {

                botonVolverComp = botonVolver.GetComponent<Button>();
                botonVolverComp.onClick.AddListener(IrAMenuPrincipal);
            }
        }
        else
        {
            menuAjustes = GameObject.Find("MenuPausa");
            menuAjustes.GetComponent<Opciones>().ActivarAjustes(true);
            Time.timeScale = 0; // Congelar la escena


            //Volver a Menu Pausa
            if (botonVolver == null)
            {
                botonVolver = GameObject.Find("BotonVolver");
            }
            if (botonVolver != null)
            {

                botonVolverComp = botonVolver.GetComponent<Button>();
                botonVolverComp.onClick.AddListener(IrAMenuPausa);
            }
        }

        
    }

    public override void UpdateState(SceneStateManager scene)
    {
    }

    public override void Exit(SceneStateManager scene)
    {

        //Reanudar
        if (botonVolverComp != null)
        {
            botonVolverComp.onClick.RemoveListener(IrAMenuPrincipal);
        }
        if (sceneMenuInicio.isLoaded)
        {
            menuAjustes = GameObject.Find("Menu");
            menuAjustes.GetComponent<Opciones>().ActivarAjustes(false);
        }
        else
        {
            menuAjustes = GameObject.Find("MenuPausa");
            menuAjustes.GetComponent<Opciones>().ActivarAjustes(false);
        }
    }

    void IrAMenuPrincipal()
    {
        Debug.Log("Saliendo de ajustes");
        context.SetState(new MenuInicioState());
    }

    void IrAMenuPausa()
    {
        Debug.Log("Saliendo de ajustes");
        context.SetState(new PausaState());
    }
}
