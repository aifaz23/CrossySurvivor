using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; 
    public GameObject player; 

    void Update()
    {
        
    }
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

    void Start () {
           
    }




}

