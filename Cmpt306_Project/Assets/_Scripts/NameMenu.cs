using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameMenu : MonoBehaviour
{
    private string Sname;

    public void Enter() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(Sname);
    }

    public void ReadStringInput(string s) {
        Sname = s;
    }
}
