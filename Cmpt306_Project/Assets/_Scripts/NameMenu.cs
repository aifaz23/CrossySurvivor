using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameMenu : MonoBehaviour
{
    public static string playerName;
    public TextMeshProUGUI placeholder;

    void Start() {
        playerName = "";
    }

    public void Enter() {
        if (string.IsNullOrEmpty(playerName)) {
            placeholder.text = "Please Enter Your Name";
        }
        else {
            Time.timeScale = 1f;
            // Debug.Log(playerName);
            SceneManager.LoadScene("GameScene");
        }
    }

    public void ReadStringInput(string pName) {
        playerName = pName;
    } 
}
