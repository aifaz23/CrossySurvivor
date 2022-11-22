using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; 
    public GameObject player; 
    public GameObject camera;
    public static bool isBossPhase = false;
    public static int score = 0;
    public int counter  = 0;
    public float scoreRate = 1f;
    private float nextScore = 0.0f;
    public TextMeshProUGUI scoreTxt;
    public bool playerDead = false;
    public TextMeshProUGUI text;
    public TextMeshProUGUI arriveText;
    public EnemySpawner enemySpawner;
    public GameObject gameOver;
    public GameObject bossCanvas;
    public GameObject pauseMenu;
    public static bool gameEnded = false;

    void Start() {
        gameEnded = false;
        isBossPhase = false;
        gameOver.SetActive(false);
        bossCanvas.SetActive(false);
        pauseMenu.SetActive(true);
        playerDead = false;
        score = 0;
    }

    void Update(){
        if (Time.time > nextScore && isBossPhase == false && playerDead == false){
            nextScore = Time.time + scoreRate;
            score += 1;
            counter += 1;
            print(score);
            if(counter == 17) {
                bossCanvas.SetActive(true);
                ArrivalText script = arriveText.GetComponent<ArrivalText>();
                script.blink();
            }

            if(score%20 == 0){
                counter = 0;
                changePhase();
            }
        }
    }

    //Reset scene when this is called.
    public void GameOver(){
        LeaderboardManager.isGameOver = true;
        isBossPhase = false;
        gameEnded = true;
        pauseMenu.SetActive(false);
        scoreTxt.text = "Score: " + score.ToString();
        gameOver.SetActive(true);
        BlinkText script = text.GetComponent<BlinkText>();
        script.blink();
        StartCoroutine(LoadLeaderboard());
    }

    IEnumerator LoadLeaderboard() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("LeaderboardScene");
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
        if (!playerDead) {
            Debug.Log(playerDead);
            score += scoreToAdd;
        }
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