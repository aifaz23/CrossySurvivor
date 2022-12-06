using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCanvas : MonoBehaviour
{
    public GameObject speed;
    public GameObject shield;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<Player>().shieldBuff){
            shield.SetActive(true);
        }
        else{
            shield.SetActive(false);
        }
        if(GameObject.Find("Player").GetComponent<Player>().speedBuff){
            speed.SetActive(true);
        }
        else{
            speed.SetActive(false);
        }

    }
}
