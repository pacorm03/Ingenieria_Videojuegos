using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBaseState : MonoBehaviour
{
    public abstract void EnterState(SceneStateManager scene);

    public abstract void UpdateState(SceneStateManager scene);

    public abstract void Exit(SceneStateManager scene);
}
