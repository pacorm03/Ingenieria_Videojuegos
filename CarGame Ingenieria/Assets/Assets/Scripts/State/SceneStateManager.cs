using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager 
{

    //currentState
    //contexto actual
    SceneBaseState currentState;


    // Start is called before the first frame update
    public void Start()
    {
        //Estado Inicial
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
        //Cuando se actualiza el estado se ejectua el metodo Exit del estado
        Debug.Log($"Cambiando al estado {state}");
        if(currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = state;
        state.EnterState(this);
    }

}

