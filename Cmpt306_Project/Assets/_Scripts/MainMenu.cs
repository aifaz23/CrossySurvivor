using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start() {
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0.035f);
    }
    
    public void LeaderBoard() {
        SceneManager.LoadScene("LeaderboardScene");
    }  

    public void Quit() {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
