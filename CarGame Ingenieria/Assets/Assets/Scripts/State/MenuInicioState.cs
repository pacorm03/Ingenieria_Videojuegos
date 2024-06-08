using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicioState : SceneBaseState
{
    GameObject botonJugar;
    Button botonJugarComp;

    Scene sceneMenu;


    public override void EnterState(SceneStateManager scene)
    {
        sceneMenu = SceneManager.GetSceneByBuildIndex(0);
        Debug.Log("Estado: Menu Inicio");
        if (sceneMenu.isLoaded)
        {
            Debug.Log("La escena ya está cargada");
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        botonJugar = GameObject.Find("BotonJugar");
        if (botonJugar != null)
        {
            botonJugarComp = botonJugar.GetComponent<Button>();
            botonJugarComp.onClick.AddListener(() => Exit(scene));
        }

    }

    public override void UpdateState(SceneStateManager scene)
    {

    }

    public override void Exit(SceneStateManager scene)
    {
        if (botonJugarComp != null)
        {
            botonJugarComp.onClick.RemoveListener(() => Exit(scene));
        }
        Debug.Log("Saliendo de estado Menu Inicio");
        scene.SetState(scene.juegoSceneState);

    }


}
