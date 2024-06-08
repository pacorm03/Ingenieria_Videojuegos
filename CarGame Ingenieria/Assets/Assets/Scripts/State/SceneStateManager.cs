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

    Scene sceneJugar;
    Scene sceneInicio;


    // Start is called before the first frame update
    void Start()
    {
        sceneJugar = SceneManager.GetSceneByBuildIndex(1);

        if (sceneJugar.isLoaded)
        {
            currentState = juegoSceneState;
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
