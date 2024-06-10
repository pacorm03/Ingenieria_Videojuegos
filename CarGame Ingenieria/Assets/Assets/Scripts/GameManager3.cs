using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    SceneStateManager stateManager;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = new SceneStateManager();
        stateManager.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        stateManager.Update();
    }
}
