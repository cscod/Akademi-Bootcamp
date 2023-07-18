using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pausePanel.SetActive(false);
        gameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pausePanel.SetActive(true);
        gameIsPaused = true;
        PlayerPrefs.SetString("SavedLevel", SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        PlayerPrefs.SetString("SavedLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenuScene");
    }
}
