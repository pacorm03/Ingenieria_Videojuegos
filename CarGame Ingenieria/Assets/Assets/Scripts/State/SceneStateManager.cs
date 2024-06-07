using UnityEngine;

public abstract class SceneStateManager : MonoBehaviour
{

    //currentState
    SceneBaseState currentState;
    public PausaState pausaState = new PausaState();
    public MenuInicioState menuInicioState = new MenuInicioState();
    public JuegoSceneState juegoSceneState = new JuegoSceneState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = menuInicioState;

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
