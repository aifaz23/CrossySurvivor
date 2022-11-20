using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameMenu : MonoBehaviour
{
    public void Enter() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
