using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GanarState : SceneBaseState
{
    GameObject botonVolver;
    Button botonVolverComp;

    GameObject botonMenuPrincipal;
    Button botonMenuPrincipalComp;

    Scene sceneFinal;

    SceneStateManager context;

    public override void EnterState(SceneStateManager scene)
    {
        context = scene;
        Debug.Log("Estado: Ganar");

        sceneFinal = SceneManager.GetSceneByBuildIndex(3);
        if (!sceneFinal.isLoaded)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(3);
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
            botonVolverComp.onClick.RemoveListener(ReanudarJuego);
        }

        if (botonMenuPrincipalComp != null)
        {
            botonMenuPrincipalComp.onClick.RemoveListener(IrAlMenuPrincipal);
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("Saliendo de estado Ganar");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 3)
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
            botonVolverComp.onClick.AddListener(ReanudarJuego);
            Debug.Log("Boton Volver encontrado");
        }

        botonMenuPrincipal = GameObject.Find("BotonMenuPrincipal");
        if (botonMenuPrincipal != null)
        {
            botonMenuPrincipalComp = botonMenuPrincipal.GetComponent<Button>();
            botonMenuPrincipalComp.onClick.AddListener(IrAlMenuPrincipal);
            Debug.Log("Boton Menu Principal encontrado");
        }
    }

    void ReanudarJuego()
    {
        Debug.Log("Saliendo de ganar");
        context.SetState(new JuegoSceneState());
    }

    void IrAlMenuPrincipal()
    {
        Debug.Log("Saliendo de ganar");
        context.SetState(new MenuInicioState());
    }
}
