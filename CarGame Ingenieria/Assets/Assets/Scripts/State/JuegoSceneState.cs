using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoSceneState : SceneBaseState
{
    GameObject menuPausa;
    Scene sceneJugar;
    GameObject jugador;
    JugadorObserver jugadorComp;
    
    public override void EnterState(SceneStateManager scene)
    {
        sceneJugar = SceneManager.GetSceneByBuildIndex(1);
        Debug.Log("Estado: Juego");
        
        jugador = GameObject.Find("Player");
        jugadorComp = jugador.GetComponent<JugadorObserver>();
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
            scene.SetState(scene.pausaState);

        }
        //Exit

        //Si no hay vida = Perder
        if (jugadorComp.vidaActual == 0)
        {
            Exit(scene);
            scene.SetState(scene.perderState);
        }
        //Si se consiguen todas las monedas = ganar
        if(jugadorComp.contadorMonedas == 5)
        {
            Exit(scene);
            scene.SetState(scene.ganarState);
        }

    }

    public override void Exit(SceneStateManager scene)
    {
        Debug.Log("Saliendo de estado Juego");
        menuPausa.SetActive(true);
        // Pulsar esc = PausaState
    }
}
