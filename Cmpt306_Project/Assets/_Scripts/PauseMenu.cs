using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public TextMeshProUGUI scoreText;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        scoreText.enabled = true;
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0f);
        FindObjectOfType<AudioManager>().changeVolume("gameMusic", 0.02f);
        Time.timeScale = 1f;
        isPaused = false;
        pauseButton.SetActive(true);
    }

    public void Home() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit() {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        scoreText.enabled = false;
        FindObjectOfType<AudioManager>().changeVolume("gameMusic", 0f);
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0.035f);
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.SetActive(false);
    }
}
