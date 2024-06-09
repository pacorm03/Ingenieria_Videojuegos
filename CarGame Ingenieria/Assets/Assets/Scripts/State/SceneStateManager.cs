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
    public GanarState ganarState = new GanarState();
    public PerderState perderState = new PerderState();

    Scene sceneJugar;
    Scene sceneInicio;
    Scene sceneExplicacion;
    Scene sceneGanar;
    Scene scenePerder;


    // Start is called before the first frame update
    void Start()
    {
        sceneJugar = SceneManager.GetSceneByBuildIndex(1);
        sceneExplicacion = SceneManager.GetSceneByBuildIndex(2);
        sceneGanar = SceneManager.GetSceneByBuildIndex(3);
        scenePerder = SceneManager.GetSceneByBuildIndex(4);



        if (sceneJugar.isLoaded)
        {
            currentState = juegoSceneState;
        }
        else if(sceneExplicacion.isLoaded)
        {
            currentState = explicacionState;
        }
        else if(sceneGanar.isLoaded)
        {
            currentState = ganarState;
        }else if (scenePerder.isLoaded)
        {
            currentState = perderState;
        }
        else{
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
