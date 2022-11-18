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
    private int score = 0;
    public float scoreRate = 1f;
    private float nextScore = 0.0f;
    public EnemySpawner enemySpawner;

    void Update(){
        if (Time.time > nextScore && isBossPhase==false){
            nextScore = Time.time + scoreRate;
            score += 1;
            print(score);
            if(score%20 == 0){
                changePhase();
            }
        }
    }

    //Reset scene when this is called.
    public void GameOver(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        isBossPhase = false;
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        } 

        else if (instance != this) {
            Destroy(gameObject); 
        }
    }

    public void AddPoints(int scoreToAdd){
        score += scoreToAdd;
    }

    public int GetPoints(){
        return score;
    }

    public void changePhase(){
        isBossPhase = !isBossPhase;
        if(isBossPhase){
            enemySpawner.SpawnBoss();
        }
    }

    //Return true if in boss phase, else turn false if in normal phase.
    public static bool getIsBossPhase(){
        return isBossPhase;
    }
}