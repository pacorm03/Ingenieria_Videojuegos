using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditosState : SceneBaseState
{
    GameObject menuCreditos;

    GameObject botonVolver;
    Button botonVolverComp;


    SceneStateManager context;
    public override void EnterState(SceneStateManager scene)
    {
        context = scene;
        Debug.Log("Estado: Menu Creditos");

        menuCreditos = GameObject.Find("Menu");
        menuCreditos.GetComponent<Opciones>().ActivarCreditos(true);
        //Volver a Menu Principal
        if (botonVolver == null)
        {
            botonVolver = GameObject.Find("BotonVolver");
        }
        if (botonVolver != null)
        {

            botonVolverComp = botonVolver.GetComponent<Button>();
            botonVolverComp.onClick.AddListener(IrAMenuPrincipal);
        }

    }

    public override void UpdateState(SceneStateManager scene)
    {
    }

    public override void Exit(SceneStateManager scene)
    {

        //Reanudar
        if (botonVolverComp != null)
        {
            botonVolverComp.onClick.RemoveListener(IrAMenuPrincipal);
        }

        menuCreditos = GameObject.Find("Menu");
        menuCreditos.GetComponent<Opciones>().ActivarCreditos(false);
    }

    void IrAMenuPrincipal()
    {
        Debug.Log("Saliendo de ajustes");
        context.SetState(new MenuInicioState());
    }
}
