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

    GameObject botonAjustes;
    Button botonAjustesComp;

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
        //Ajustes
        if (botonAjustes == null)
        {
            botonAjustes = GameObject.Find("BotonAjustes");
        }
        if (botonAjustes != null)
        {

            botonAjustesComp = botonAjustes.GetComponent<Button>();
            botonAjustesComp.onClick.AddListener(IrAjustes);
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

        
        //Ajustes
        if (botonAjustesComp != null)
        {
            botonAjustesComp.onClick.RemoveListener(IrAjustes);
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

    void IrAjustes()
    {
        Debug.Log("Saliendo de pausa");
        context.SetState(new AjustesState());
    }
}
