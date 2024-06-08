using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoSceneState : SceneBaseState
{
    GameObject menuPausa;
    Scene sceneJugar;
    
    public override void EnterState(SceneStateManager scene)
    {
        sceneJugar = SceneManager.GetSceneByBuildIndex(1);
        Debug.Log("Estado: Juego");
        
        if (sceneJugar.isLoaded)
        {
            Debug.Log("La escena ya está cargada");
            if(menuPausa == null)
            {
                menuPausa = GameObject.Find("MenuPausa");
            }
            menuPausa.SetActive(false);


        }
        else
        {
            SceneManager.LoadScene(1);
        }


    }

    public override void UpdateState(SceneStateManager scene)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit(scene);
        }
        //Exit

    }

    public override void Exit(SceneStateManager scene)
    {
        Debug.Log("Saliendo de estado Juego");
        menuPausa.SetActive(true);
        scene.SetState(scene.pausaState);
        // Pulsar esc = PausaState
    }
}
