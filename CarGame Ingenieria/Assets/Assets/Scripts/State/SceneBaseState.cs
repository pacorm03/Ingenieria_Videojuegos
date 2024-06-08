using UnityEngine;

public abstract class SceneBaseState 
{
    public abstract void EnterState(SceneStateManager scene);

    public abstract void UpdateState(SceneStateManager scene);

    public abstract void Exit(SceneStateManager scene);
}
