using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public Button restartButton;

    void Update() {
        if (GameManager.gameEnded) {
            restartButton.interactable = true;
        }
        else {
            restartButton.interactable = false;
            restartButton.GetComponentInChildren<TextMeshProUGUI>().text = "<----";
        }
    }

    public void Home() {
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart() {
        SceneManager.LoadScene("GameScene");
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0.0f);
    }
}
