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
        gunLoadout.Add(1); 
        currentGunObject = Instantiate(pistol, transform.position, transform.rotation);  
        currentGunObject.transform.parent = GameObject.Find("GunSwitcher").transform;
        currentGun=1;
    }

    // Update is called once per frame
    void Update()
    {
        switchGuns();
    }


    private void initiaiteNewGun(int newGun){
        Destroy(currentGunObject);
        if (newGun==1){
            currentGunObject = Instantiate(pistol, transform.position, transform.rotation);  
            currentGunObject.GetComponent<PistolGun>().baseDamage+=damageIncrease;
        }
        else if (newGun==2){
            currentGunObject = Instantiate(shotgun, transform.position, transform.rotation); 
            currentGunObject.GetComponent<ShotgunGun>().baseDamage+=damageIncrease;
        }
        if (newGun==3){
            currentGunObject = Instantiate(uzi, transform.position, transform.rotation);  
            currentGunObject.GetComponent<UziGun>().baseDamage+=damageIncrease;
        }
        if (newGun==4){
            currentGunObject = Instantiate(sniper, transform.position, transform.rotation); 
            currentGunObject.GetComponent<SniperGun>().baseDamage+=damageIncrease;
        }
        currentGun=newGun;
    }

    public void increaseDamage(){
        damageIncrease+=Random.Range(10,20);
        if(currentGun==1){
            currentGunObject.GetComponent<PistolGun>().baseDamage+=damageIncrease;
        }
        else if(currentGun==2){
            currentGunObject.GetComponent<ShotgunGun>().baseDamage+=damageIncrease;
        }
        else if(currentGun==3){
            currentGunObject.GetComponent<UziGun>().baseDamage+=damageIncrease;
        }
        else if(currentGun==4){
            currentGunObject.GetComponent<SniperGun>().baseDamage+=damageIncrease;
        }
    }
    public void recieveGun(){
        if(gunLoadout.Count==4){
            damageIncrease+=10;
            if(currentGun==1){
                currentGunObject.GetComponent<PistolGun>().baseDamage+=damageIncrease;
            }
            else if(currentGun==2){
                currentGunObject.GetComponent<ShotgunGun>().baseDamage+=damageIncrease;
            }
            else if(currentGun==3){
                currentGunObject.GetComponent<UziGun>().baseDamage+=damageIncrease;
            }
            else if(currentGun==4){
                currentGunObject.GetComponent<SniperGun>().baseDamage+=damageIncrease;
            }
            
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
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            currentGun++;
            if(currentGun>4){
                currentGun=1;
            }
            initiaiteNewGun(currentGun);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            currentGun--;
            if(currentGun<1){
                currentGun=4;
            }
            initiaiteNewGun(currentGun);
        }
        if (Input.GetKey(KeyCode.Alpha1) && currentGun!=1 && gunLoadout.Contains(1)){
            initiaiteNewGun(1);
        }
        if (Input.GetKey(KeyCode.Alpha2) && currentGun!=2 && gunLoadout.Contains(2)){
            initiaiteNewGun(2);
        }
        if (Input.GetKey(KeyCode.Alpha3) && currentGun!=3 && gunLoadout.Contains(3)){
            initiaiteNewGun(3);
        }
        if (Input.GetKey(KeyCode.Alpha4) && currentGun!=4 && gunLoadout.Contains(4)){
            initiaiteNewGun(4);
        }
        currentGunObject.transform.parent = GameObject.Find("GunSwitcher").transform;

    }
}
