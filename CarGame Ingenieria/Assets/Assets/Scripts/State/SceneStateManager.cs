using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{

    //currentState
    SceneBaseState currentState;
    public PausaState pausaState = new PausaState();
    public MenuInicioState menuInicioState = new MenuInicioState();
    public JuegoSceneState juegoSceneState = new JuegoSceneState();
    public ExplicacionState explicacionState = new ExplicacionState();

    Scene sceneJugar;
    Scene sceneInicio;
    Scene sceneExplicacion;

    // Start is called before the first frame update
    void Start()
    {
        sceneJugar = SceneManager.GetSceneByBuildIndex(1);
        sceneExplicacion = SceneManager.GetSceneByBuildIndex(2);


        if (sceneJugar.isLoaded)
        {
            currentState = juegoSceneState;
        }
        else if(sceneExplicacion.isLoaded)
        {
            currentState = explicacionState;
        }
        else
        {
            currentState = menuInicioState;
        }
        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(SceneBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

}
