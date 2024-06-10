using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager 
{

    //currentState
    SceneBaseState currentState;


    // Start is called before the first frame update
    public void Start()
    {
        MenuInicioState menuInicioState = new MenuInicioState();

        SetState(menuInicioState);
    }

    // Update is called once per frame
    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(SceneBaseState state)
    {
        Debug.Log($"Cambiando al estado {state}");
        if(currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = state;
        state.EnterState(this);
    }

}
