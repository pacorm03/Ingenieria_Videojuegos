using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GanarState : SceneBaseState
{

    GameObject botonVolver;
    Button botonVolverComp;

    GameObject botonMenuPrincipal;
    Button botonMenuPrincipalComp;




    Scene sceneFinal;

    public override void EnterState(SceneStateManager scene)
    {
        Debug.Log("Estado: Ganar");
        sceneFinal = SceneManager.GetSceneByBuildIndex(3);
        if (sceneFinal.isLoaded)
        {
            Debug.Log("La escena ya está cargada");

        }
        else
        {
            SceneManager.LoadScene(3);
        }
        Debug.Log("Estado: Menu Ganar");
        
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

        Debug.Log("Saliendo de ganar");
        Exit(scene);
        scene.SetState(scene.juegoSceneState);
    }

    void IrAlMenuPrincipal(SceneStateManager scene)
    {
        Debug.Log("Saliendo de ganar");
        Exit(scene);
        scene.SetState(scene.menuInicioState);
    }
}
