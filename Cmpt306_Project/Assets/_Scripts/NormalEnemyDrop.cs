using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDrop : MonoBehaviour
{
    [SerializeField] private float dropRate = 1.0f; 
    private float dropTime; 
    public GameObject healthPrefab; 
    public GameObject weaponPrefab; 
    public GameObject speedPrefab; 
    public GameObject shieldPrefab; 
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
        
                // either 0 or 1
            int dropChance = (Random.Range(0,2));
            if(dropChance==1){

                int drop = (Random.Range(0,4));
                if(drop==1){
                    Instantiate(healthPrefab, dropPosition, transform.rotation);  
                }
                else if(drop==2){
                    Instantiate(shieldPrefab, dropPosition, transform.rotation);  
                }
                else if(drop==3){
                    Instantiate(speedPrefab, dropPosition, transform.rotation);  
                }
                else{
                    Instantiate(weaponPrefab, dropPosition, transform.rotation);  
                    
                }
                
            }
           
            
        
        
    
    }
}
