using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // public GameObject nameMenu;
    // public GameObject mainMenu;

    // void Start() {
    //     nameMenu = GameObject.Find("NameMenu");
    //     Debug.Log(nameMenu);
    //     nameMenu.SetActive(false);
    //     mainMenu = GameObject.Find("MainMenu");
    //     Debug.Log(mainMenu);
    // }

    // public void Play() {
    //     nameMenu.SetActive(true);
    //     mainMenu.SetActive(false);
    //     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    public void LeaderBoard() {
        SceneManager.LoadScene("LeaderboardScene");
    }  

    public void Quit() {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
