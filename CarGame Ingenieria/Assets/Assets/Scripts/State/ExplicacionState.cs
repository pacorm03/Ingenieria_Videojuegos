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
    SceneStateManager context;


    public override void EnterState(SceneStateManager scene)
    {
        sceneExplicacion = SceneManager.GetSceneByBuildIndex(2);
        context = scene;
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
            botonVolverComp.onClick.AddListener(ComenzarJuego);
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
            botonVolverComp.onClick.RemoveListener(ComenzarJuego);
        }

    }


    void ComenzarJuego()
    {
        Debug.Log("Saliendo de explicacion");
        context.SetState(new JuegoSceneState());
    }

}


