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

    SceneStateManager context;
    public override void EnterState(SceneStateManager scene)
    {
        context = scene;
        Debug.Log("Estado: Menu Pausa");
        Time.timeScale = 0; // Congelar la escena

        menuPausa = GameObject.Find("MenuPausa");
        menuPausa.GetComponent<Opciones>().ActivarPausa(true);
        //Reanudar
        if (botonVolver == null )
        {
            botonVolver = GameObject.Find("BotonVolver");
        }
        if (botonVolver != null)
        {

            botonVolverComp = botonVolver.GetComponent<Button>();
            botonVolverComp.onClick.AddListener(ReanudarJuego);
        }
        //Salir
        if (botonMenuPrincipal == null)
        {
            botonMenuPrincipal = GameObject.Find("BotonMenuPrincipal");
        }
        if (botonMenuPrincipal != null)
        {

            botonMenuPrincipalComp = botonMenuPrincipal.GetComponent<Button>();
            botonMenuPrincipalComp.onClick.AddListener(IrAlMenuPrincipal);
        }

    }

    public override void UpdateState(SceneStateManager scene)
    {
    }

    public override void Exit(SceneStateManager scene)
    {
        Time.timeScale = 1; // Reanudar la escena

        //Reanudar
        if (botonVolverComp != null)
        {
            botonVolverComp.onClick.RemoveListener(ReanudarJuego);
        }


        //Salir
        if (botonMenuPrincipalComp != null)
        {
            botonMenuPrincipalComp.onClick.RemoveListener(IrAlMenuPrincipal);
        }
        menuPausa = GameObject.Find("MenuPausa");
        menuPausa.GetComponent<Opciones>().ActivarPausa(false);
    }

    void ReanudarJuego()
    {
        Debug.Log("Saliendo de pausa");
        context.SetState(new JuegoSceneState());
    }

    void IrAlMenuPrincipal()
    {
        Debug.Log("Saliendo de pausa");
        context.SetState(new MenuInicioState());
    }
}
