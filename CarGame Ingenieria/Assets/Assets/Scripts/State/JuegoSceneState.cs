using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoSceneState : SceneBaseState
{
    GameObject menuPausa;
    Scene sceneJugar;
    GameObject jugador;
    Salud saludJugador;
    MonedasJugador monedas;
    
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
            if (saludJugador.vidaActual == 4)
            {
                scene.SetState(new PerderState());
            }
            //Si se consiguen todas las monedas = ganar
            if (monedas.contadorMonedas == 2)
            {
                Debug.Log($"monedas: {monedas.contadorMonedas}");
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
        saludJugador = jugador.GetComponent<Salud>();


    }
}
