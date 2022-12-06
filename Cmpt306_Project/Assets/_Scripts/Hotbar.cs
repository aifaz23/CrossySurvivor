using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject uzi;
    public GameObject sniper;

    public void switchToPistol(){
        GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().hotBarSwitch(1);
    }
    public void switchToShotgun(){
        GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().hotBarSwitch(2);
    }
    public void switchToUzi(){
        GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().hotBarSwitch(3);
    }
    public void switchToSniper(){
        GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().hotBarSwitch(4);
    }

    void Start()
    {
        pistol.SetActive(true);
        shotgun.SetActive(false);
        uzi.SetActive(false);
        sniper.SetActive(false);

    }
    public void updateHotbar(){
        if(GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().gunLoadout.Contains(1)){
            pistol.SetActive(true);
        }
        if(GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().gunLoadout.Contains(2)){
            shotgun.SetActive(true);
        }
        if(GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().gunLoadout.Contains(3)){
            uzi.SetActive(true);
        }
        if(GameObject.Find("GunSwitcher").GetComponent<GunSwitching>().gunLoadout.Contains(4)){
            sniper.SetActive(true);
        }
        
    }
    
}
