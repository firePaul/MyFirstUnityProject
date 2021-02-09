using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool gamepause = false; 
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamepause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void Resume()
    {
        SceneManager.LoadScene("level1");
        Time.timeScale = 1f;
        gamepause = false;
    }

    private void Pause()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 0f;
        gamepause = true;
    }
}
