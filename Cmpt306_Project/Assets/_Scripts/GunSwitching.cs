using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    [SerializeField] private GameObject pistol; 
    [SerializeField] private GameObject shotgun; 
    [SerializeField] private GameObject sniper; 
    [SerializeField] private GameObject uzi; 
    private GameObject currentGunObject; 
    private int currentGun = 0;
    [SerializeField] public List<int> gunLoadout = new List<int>();
    public float damageIncrease;
    // Start is called before the first frame update
    void Start()
    {
        gunLoadout.Add(2);
        currentGunObject = Instantiate(shotgun, transform.position, transform.rotation);  
        currentGunObject.transform.parent = GameObject.Find("GunSwitcher").transform;
        currentGun=2;
    }

    // Update is called once per frame
    void Update()
    {
        switchGuns();
    }

    private void destroyGun(){
        Destroy(currentGunObject);
    }
    public void recieveGun(){
        if(gunLoadout.Count==4){
            damageIncrease+=10;
        }
        else{
            int gun = Random.Range(1,5);
            while(gunLoadout.Contains(gun)){
                gun= Random.Range(1,5);
            }
            gunLoadout.Add(gun);

        }
    }
    private void switchGuns(){
         if (Input.GetKey(KeyCode.Alpha1) && currentGun!=1 && gunLoadout.Contains(1)){
            destroyGun();
            currentGunObject = Instantiate(pistol, transform.position, transform.rotation);  
            currentGunObject.GetComponent<PistolGun>().damages+=damageIncrease;
            currentGun=1;
        }
        if (Input.GetKey(KeyCode.Alpha2) && currentGun!=2 && gunLoadout.Contains(2)){
            destroyGun();
            currentGunObject = Instantiate(shotgun, transform.position, transform.rotation); 
            currentGunObject.GetComponent<ShotgunGun>().damages+=damageIncrease;
            
            currentGun=2;
        }
        if (Input.GetKey(KeyCode.Alpha3) && currentGun!=3 && gunLoadout.Contains(3)){
            destroyGun();
            currentGunObject = Instantiate(uzi, transform.position, transform.rotation);  
            currentGunObject.GetComponent<UziGun>().damages+=damageIncrease;
            
            currentGun=3;
        }
        if (Input.GetKey(KeyCode.Alpha4) && currentGun!=4 && gunLoadout.Contains(4)){
            destroyGun();
            currentGunObject = Instantiate(sniper, transform.position, transform.rotation); 
            currentGunObject.GetComponent<SniperGun>().damages+=damageIncrease;
    
            currentGun=4;
        }
        currentGunObject.transform.parent = GameObject.Find("GunSwitcher").transform;

    }
}
