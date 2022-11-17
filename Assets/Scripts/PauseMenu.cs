using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused  = false;
    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        IsGamePaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        IsGamePaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        IsGamePaused = false;
        SceneManager.LoadScene("EntryScreen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
