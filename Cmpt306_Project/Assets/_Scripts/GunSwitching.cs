using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    [SerializeField] private GameObject pistol; 
    [SerializeField] private GameObject shotgun; 
    [SerializeField] private GameObject sniper; 
    [SerializeField] private GameObject uzi; 
    private int currentGun = 0;
    [SerializeField] public List<int> gunLoadout = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        gunLoadout.Add(1);
        GameObject weapon = Instantiate(pistol, transform.position, transform.rotation);  
        weapon.transform.parent = GameObject.Find("GunSwitcher").transform;
        currentGun=1;
    }

    // Update is called once per frame
    void Update()
    {
        switchGuns();
    }

    private void destroyGun(){
        if(currentGun==1){
            Destroy(pistol);
        }
        else if(currentGun==2){
            Destroy(shotgun);
        }
        else if(currentGun==3){
            Destroy(sniper);
        }
        else if(currentGun==4){
            Destroy(uzi);
        }
    }
    private void switchGuns(){
         if (Input.GetKey(KeyCode.Alpha1) && currentGun!=1 && gunLoadout.Contains(1)){
            destroyGun();
            GameObject weapon = Instantiate(pistol, transform.position, transform.rotation);  
            weapon.transform.parent = GameObject.Find("GunSwitcher").transform;
            currentGun=1;
        }
        if (Input.GetKey(KeyCode.Alpha2) && currentGun!=2 && gunLoadout.Contains(2)){
            destroyGun();
            GameObject weapon = Instantiate(shotgun, transform.position, transform.rotation);  
            weapon.transform.parent = GameObject.Find("GunSwitcher").transform;
            currentGun=2;
        }
        if (Input.GetKey(KeyCode.Alpha3) && currentGun!=3 && gunLoadout.Contains(3)){
            destroyGun();
            GameObject weapon = Instantiate(uzi, transform.position, transform.rotation);  
            weapon.transform.parent = GameObject.Find("GunSwitcher").transform;
            currentGun=3;
        }
        if (Input.GetKey(KeyCode.Alpha4) && currentGun!=4 && gunLoadout.Contains(4)){
            destroyGun();
            GameObject weapon = Instantiate(sniper, transform.position, transform.rotation);  
            weapon.transform.parent = GameObject.Find("GunSwitcher").transform;
            currentGun=4;
        }
        
    }
}
