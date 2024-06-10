using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicioState : SceneBaseState
{
    GameObject botonJugar;
    Button botonJugarComp;

    Scene sceneMenu;
    SceneStateManager context;

    //Instanciar estados y llamar setstate
    public override void EnterState(SceneStateManager scene)
    {
        context = scene;
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
            botonJugarComp.onClick.AddListener(CargarJuego);
        }

    }

    public override void UpdateState(SceneStateManager scene)
    {

    }

    void CargarJuego()
    {
        Debug.Log("Click en cargar juegos");
        context.SetState(new JuegoSceneState());
    }

    public override void Exit(SceneStateManager scene)
    {
        if (botonJugarComp != null)
        {
            botonJugarComp.onClick.RemoveListener(CargarJuego);
        }
        Debug.Log("Saliendo de estado Menu Inicio");

    }


}
