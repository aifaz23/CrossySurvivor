using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; 
    public GameObject player; 
    public GameObject camera;
    private static bool isBossPhase = false;

    //Reset scene when this is called.
    public void GameOver(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        } 

        else if (instance != this) {
            Destroy(gameObject); 
        }
    }

    void changePhase(){
        isBossPhase = !isBossPhase;
    }

    //Return true if in boss phase, else turn false if in normal phase.
    public static bool getIsBossPhase(){
        return isBossPhase;
    }




}

