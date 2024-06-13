using System.Collections;
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
        context = scene;
        sceneExplicacion = SceneManager.GetSceneByBuildIndex(2);
        Debug.Log("Estado: Menu Explicacion");

        if (!sceneExplicacion.isLoaded)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(2);
        }
        else
        {
            InitializeMenu();
        }
    }

    public override void UpdateState(SceneStateManager scene)
    {
    }

    public override void Exit(SceneStateManager scene)
    {
        if (botonVolverComp != null)
        {
            botonVolverComp.onClick.RemoveListener(ComenzarJuego);
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("Saliendo de estado Menu Explicacion");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            Debug.Log($"La escena {scene.name} ya está cargada");
            InitializeMenu();
        }
    }

    void InitializeMenu()
    {
        botonVolver = GameObject.Find("BotonJugar");
        if (botonVolver != null)
        {
            botonVolverComp = botonVolver.GetComponent<Button>();
            botonVolverComp.onClick.AddListener(ComenzarJuego);
            Debug.Log("Boton Volver encontrado");
        }
        else
        {
            Debug.LogError("Boton Volver no encontrado");
        }
    }

    void ComenzarJuego()
    {
        Debug.Log("Saliendo de explicacion");
        context.SetState(new JuegoSceneState());
    }
}
