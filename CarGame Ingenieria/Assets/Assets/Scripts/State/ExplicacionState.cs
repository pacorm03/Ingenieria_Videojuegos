using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExplicacionState : SceneBaseState
{


    GameObject botonVolver;
    Button botonVolverComp;
    Scene sceneExplicacion;


    public override void EnterState(SceneStateManager scene)
    {
        sceneExplicacion = SceneManager.GetSceneByBuildIndex(2);
        if (sceneExplicacion.isLoaded)
        {
            Debug.Log("La escena ya está cargada");
           
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        Debug.Log("Estado: Menu Explicacion");
        
        //Reanudar
        if (botonVolver == null)
        {
            botonVolver = GameObject.Find("BotonJugar");
        }
        if (botonVolver != null)
        {

            botonVolverComp = botonVolver.GetComponent<Button>();
            botonVolverComp.onClick.AddListener(() => ComenzarJuego(scene));
        }

    }

    public override void UpdateState(SceneStateManager scene)
    {
    }

    public override void Exit(SceneStateManager scene)
    {
        //Comenzar
        if (botonVolverComp != null)
        {
            botonVolverComp.onClick.RemoveListener(() => Exit(scene));
        }

    }

    void ComenzarJuego(SceneStateManager scene)
    {
        Debug.Log("Saliendo de explicacion");
        Exit(scene);
        scene.SetState(scene.juegoSceneState);
    }

}


