using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{


    public GameObject pauseMenu;
    //private PauseManager pause;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PauseMenu"))
        {
            if (!isPaused)
            {
                //pause.PauseGame();
                pauseMenu.SetActive(true);
                isPaused = true;
            }
            else
            {

                //pause.UnpauseGame();
                pauseMenu.SetActive(false);
                isPaused = false;


            }
        }
    }
}
