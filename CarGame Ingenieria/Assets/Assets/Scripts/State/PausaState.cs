using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class PausaState : SceneBaseState
{
    GameObject menuPausa;
    GameObject botonVolver;
    Button botonVolverComp;

    GameObject botonMenuPrincipal;
    Button botonMenuPrincipalComp;

    public override void EnterState(SceneStateManager scene)
    {
        Debug.Log("Estado: Menu Pausa");
        menuPausa = GameObject.Find("MenuPausa");
        menuPausa.SetActive(true);
        //Reanudar
        if(botonVolver == null )
        {
            botonVolver = GameObject.Find("BotonVolver");
        }
        if (botonVolver != null)
        {

            botonVolverComp = botonVolver.GetComponent<Button>();
            botonVolverComp.onClick.AddListener(() => ReanudarJuego(scene));
        }
        //Salir
        if (botonMenuPrincipal == null)
        {
            botonMenuPrincipal = GameObject.Find("BotonMenuPrincipal");
        }
        if (botonMenuPrincipal != null)
        {

            botonMenuPrincipalComp = botonMenuPrincipal.GetComponent<Button>();
            botonMenuPrincipalComp.onClick.AddListener(() => IrAlMenuPrincipal(scene));
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
            botonVolverComp.onClick.RemoveListener(() => Exit(scene));
        }


        //Salir
        if (botonMenuPrincipalComp != null)
        {
            botonMenuPrincipalComp.onClick.RemoveListener(() => Exit(scene));
        }

    }

    void ReanudarJuego(SceneStateManager scene)
    {
        Debug.Log("Saliendo de pausa");
        Exit(scene);
        scene.SetState(scene.juegoSceneState);
    }

    void IrAlMenuPrincipal(SceneStateManager scene)
    {
        Debug.Log("Saliendo de pausa");
        Exit(scene);
        scene.SetState(scene.menuInicioState);
    }
}
