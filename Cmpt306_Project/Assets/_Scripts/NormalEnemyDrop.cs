using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDrop : MonoBehaviour
{
    public GameObject healthPrefab; 
    public GameObject weaponPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropItem(Vector3 dropPosition){
        // either 0 or 1
        int dropChance = (Random.Range(0,2));
        if(dropChance==1){
            int drop = (Random.Range(0,2));
            if(drop==1){
                GameObject healthpack = Instantiate(healthPrefab, dropPosition, transform.rotation);  
                healthpack.GetComponent<healthDrop>().health = (Random.Range(10,100));
            }
            else{
                GameObject weapondrop = Instantiate(weaponPrefab, dropPosition, transform.rotation);  
                weapondrop.GetComponent<GunDrop>().damage = (Random.Range(1,7));
                // // rotate on its side
                weapondrop.transform.eulerAngles  = new Vector3(-1,-200,-90);
            }
        }
    }
}
