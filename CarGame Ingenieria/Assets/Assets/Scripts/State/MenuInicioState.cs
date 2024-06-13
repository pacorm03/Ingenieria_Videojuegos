using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicioState : SceneBaseState
{
    GameObject botonJugar;
    Button botonJugarComp;

    GameObject botonAjustes;
    Button botonAjustesComp;

    GameObject botonCreditos;
    Button botonCreditosComp;

    GameObject menuInicio;

    SceneStateManager context;
    Scene sceneMenu;

    public override void EnterState(SceneStateManager scene)
    {
        context = scene;
        sceneMenu = SceneManager.GetSceneByBuildIndex(0);
        Debug.Log("Estado: Menu Inicio");

        if (!sceneMenu.isLoaded)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(0);
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
        if (botonJugarComp != null)
        {
            botonJugarComp.onClick.RemoveListener(CargarJuego);
        }
        if (botonAjustesComp != null)
        {
            botonAjustesComp.onClick.RemoveListener(CargarAjustes);
        }
        if (botonCreditosComp != null)
        {
            botonCreditosComp.onClick.RemoveListener(CargarCreditos);
        }

        if (menuInicio != null)
        {
            menuInicio.GetComponent<Opciones>().ActivarMenuInicio(false);
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("Saliendo de estado Menu Inicio");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Debug.Log($"La escena {scene.name} ya está cargada");
            InitializeMenu();
        }
    }

    void InitializeMenu()
    {
        menuInicio = GameObject.Find("Menu");
        if (menuInicio != null)
        {
            menuInicio.GetComponent<Opciones>().ActivarMenuInicio(true);

            botonJugar = GameObject.Find("BotonJugar");
            if (botonJugar != null)
            {
                botonJugarComp = botonJugar.GetComponent<Button>();
                botonJugarComp.onClick.AddListener(CargarJuego);
                Debug.Log("Boton Jugar encontrado");
            }

            botonAjustes = GameObject.Find("BotonAjustes");
            if (botonAjustes != null)
            {
                botonAjustesComp = botonAjustes.GetComponent<Button>();
                botonAjustesComp.onClick.AddListener(CargarAjustes);
            }

            botonCreditos = GameObject.Find("BotonCreditos");
            if (botonCreditos != null)
            {
                botonCreditosComp = botonCreditos.GetComponent<Button>();
                botonCreditosComp.onClick.AddListener(CargarCreditos);
            }
        }
        else
        {
            Debug.LogError("Menu no encontrado");
        }
    }

    void CargarJuego()
    {
        Debug.Log("Click en cargar juegos");
        context.SetState(new JuegoSceneState());
    }

    void CargarAjustes()
    {
        Debug.Log("Click en Ajustes");
        context.SetState(new AjustesState());
    }

    void CargarCreditos()
    {
        Debug.Log("Click en Creditos");
        context.SetState(new CreditosState());
    }
}
