using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PerderState : SceneBaseState
{


    GameObject botonVolver;
    Button botonVolverComp;

    GameObject botonMenuPrincipal;
    Button botonMenuPrincipalComp;


    Scene sceneFinal;

    public override void EnterState(SceneStateManager scene)
    {
        Debug.Log("Estado: Perder");
        sceneFinal = SceneManager.GetSceneByBuildIndex(4);
        if (sceneFinal.isLoaded)
        {
            Debug.Log("La escena ya est� cargada");

        }
        else
        {
            SceneManager.LoadScene(4);
        }
        Debug.Log("Estado: Menu Perder");


        //Reanudar
        if (botonVolver == null)
        {
            botonVolver = GameObject.Find("BotonJugar");
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

        Debug.Log("Saliendo de perder");
        scene.SetState(new JuegoSceneState());
    }

    void IrAlMenuPrincipal(SceneStateManager scene)
    {
        Debug.Log("Saliendo de perder");
        scene.SetState(new MenuInicioState());
    }
}
