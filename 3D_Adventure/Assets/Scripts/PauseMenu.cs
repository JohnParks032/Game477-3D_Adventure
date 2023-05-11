using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenuCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GamePaused)
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Camera.main.GetComponent<CinemachineBrain>().enabled = true;
    }
    void Pause()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
    }

    public void MainMenuButtion() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
