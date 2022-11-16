using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDrop : MonoBehaviour
{
    [SerializeField] private float dropRate = 1.0f; 
    private float dropTime; 
    public GameObject healthPrefab; 
    public GameObject weaponPrefab; 
    public GameObject bossPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        dropRate=0.50f;
        dropTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropItem(Vector3 dropPosition){
        
            Instantiate(bossPrefab, dropPosition, transform.rotation); 
                // either 0 or 1
            // int dropChance = (Random.Range(0,2));
            // if(dropChance==1 &&Time.time >= dropTime){

            //     int drop = (Random.Range(0,2));
            //     if(drop==1){
            //         GameObject healthpack = Instantiate(healthPrefab, dropPosition, transform.rotation);  
            //         healthpack.GetComponent<healthDrop>().health = (Random.Range(10,100));
            //     }
            //     else{
            //         GameObject weapondrop = Instantiate(weaponPrefab, dropPosition, transform.rotation);  
            //         weapondrop.GetComponent<GunDrop>().damage = (Random.Range(1,7));
            //         // // rotate on its side
            //         weapondrop.transform.eulerAngles  = new Vector3(-1,-200,-90);
            //     }
            // }
            // if(Time.time >= dropTime){
            //     dropTime = Time.time + dropRate; //Set your fire rate cooldown
            // }
            
        
        
    
    }
}
