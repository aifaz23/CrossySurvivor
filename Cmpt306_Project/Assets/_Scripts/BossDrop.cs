using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrop : MonoBehaviour
{
    public GameObject bossMenuUI;

    void Start(){
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0.035f);
        Time.timeScale = 0f;
    }
    
    public void increaseHP(){
        GameObject.Find("Player").GetComponent<Player>().maxHealth+=25;
        GameObject.Find("Player").GetComponent<Player>().health+=25;
        Destroy(this.bossMenuUI); 
        GameManager.instance.changePhase(); // Impliment going to next stage here
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0f);
        Time.timeScale = 1f;
        
    }
    public void revieveNewWeapon(){
        GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().recieveGun();
        Destroy(this.bossMenuUI);
        GameManager.instance.changePhase(); // Impliment going to next stage here
        FindObjectOfType<AudioManager>().changeVolume("BackgroundMusic", 0f);
        Time.timeScale = 1f;
    }
   
}
