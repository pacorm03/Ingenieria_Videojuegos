using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoSceneState : SceneBaseState
{
    public override void EnterState(SceneStateManager scene)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public override void UpdateState(SceneStateManager scene)
    {

    }

    public override void Exit(SceneStateManager scene)
    {

    }
}
