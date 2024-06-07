using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicioState : SceneBaseState
{
    public Button botonJugar;
    public override void EnterState(SceneStateManager scene)
    {
        Console.WriteLine("Estado: Menu Inicio");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public override void UpdateState(SceneStateManager scene)
    {
        if (botonJugar != null)
        {
            //botonJugar.onClick.AddListener(scene.SetState(scene.juegoSceneState));
        }
       
    }

    public override void Exit(SceneStateManager scene)
    {

    }
}
