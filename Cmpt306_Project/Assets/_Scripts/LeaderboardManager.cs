using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    private LeaderboardData leaderboardData;
    public int score;
    public string playerName;
    public static bool isGameOver = false;

    void Start() {
        isGameOver = false;
    }

    void Update() {
        if (isGameOver) {
            score = GameManager.score;
            Debug.Log("Score is: " + score.ToString());
            playerName = NameMenu.playerName;
            Debug.Log("Name is: " + playerName);
            AddScore(new Leaderboard(playerName, score));
            isGameOver = false;
        }
    }

    void Awake()
    {
        var dataEntry = PlayerPrefs.GetString("scores", "{}");
        leaderboardData = JsonUtility.FromJson<LeaderboardData>(dataEntry);
    }

    public IEnumerable<Leaderboard> GetHighScore() {
        return leaderboardData.leaderboard.OrderByDescending(x => x.score);
    }

    public void AddScore(Leaderboard scoredata) {
        leaderboardData.leaderboard.Add(scoredata);
    }

    public void OnDestroy() {
        var dataEntry = JsonUtility.ToJson(leaderboardData);
        PlayerPrefs.SetString("scores", dataEntry);    
    }
}
