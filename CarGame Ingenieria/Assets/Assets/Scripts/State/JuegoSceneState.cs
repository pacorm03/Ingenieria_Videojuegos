using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoSceneState : SceneBaseState
{
    Scene sceneJugar;
    GameObject jugador;
    Salud saludJugador;
    MonedasJugador monedas;

    public override void EnterState(SceneStateManager scene)
    {
        sceneJugar = SceneManager.GetSceneByBuildIndex(1);
        Debug.Log("Estado: Juego");

        if (!sceneJugar.isLoaded)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else
        {
            InitializePlayerComponents();
        }
    }

    public override void UpdateState(SceneStateManager scene)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scene.SetState(new PausaState());
        }

        if (saludJugador != null && saludJugador.vidaActual == 0)
        {
            scene.SetState(new PerderState());
        }

        if (monedas != null && monedas.contadorMonedas == monedas.totalMonedas)
        {
            Debug.Log($"monedas: {monedas.contadorMonedas}");
            scene.SetState(new GanarState());
        }
    }

    public override void Exit(SceneStateManager scene)
    {
        Debug.Log("Saliendo de estado Juego");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Debug.Log($"La escena {scene.name} ya está cargada");
            InitializePlayerComponents();
        }
    }

    private void InitializePlayerComponents()
    {
        jugador = GameObject.Find("Player");
        if (jugador != null)
        {
            saludJugador = jugador.GetComponent<Salud>();
            monedas = jugador.GetComponent<MonedasJugador>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'Player' en la escena.");
        }
    }
}
