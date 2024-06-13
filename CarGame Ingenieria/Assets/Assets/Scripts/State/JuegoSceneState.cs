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

        if(!sceneJugar.isLoaded)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(1);
            
        }

    }

    public override void UpdateState(SceneStateManager scene)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scene.SetState(new PausaState());
        }
        //Exit
        if (sceneJugar.isLoaded)
        {
            //Si no hay vida = Perder
            if (jugadorComp.vidaActual == 4)
            {
                scene.SetState(new PerderState());
            }
            //Si se consiguen todas las monedas = ganar
            if (jugadorComp.contadorMonedas == 2)
            {
                scene.SetState(new GanarState());
            }
        }

    }

    public override void Exit(SceneStateManager scene)
    {
        Debug.Log("Saliendo de estado Juego");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //menuPausa.SetActive(true);
        // Pulsar esc = PausaState
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"La escena {scene.name} ya está cargada");
        jugador = GameObject.Find("Player");
        jugadorComp = jugador.GetComponent<JugadorObserver>();


    }
}
