using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunGun : MonoBehaviour
{
    [SerializeField] private GameObject projectile; 
    [SerializeField] private float fireRate = 1.0f; 
    private float fireTime; 
    [SerializeField] public float damages = 10.0f;

    void Start(){
        fireRate=0.1f;
        damages=10.0f;
    }
    void Update() {

         
        
        
            
        Shoot(); 
    }

    private void Shoot() {
        Vector3 vector = Input.mousePosition;
        vector.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        vector = Camera.main.ScreenToWorldPoint(vector);
        transform.LookAt(vector);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerRotation.y,eulerRotation.z);
        if(Input.GetMouseButtonDown(0) && Time.time >= fireTime) {
            
            for(int i=0; i<5; i++){
                Instantiate(projectile, transform.position, transform.rotation);    
                transform.Rotate(Vector3.up*(Random.Range(-15,15)));
            }
  
            transform.LookAt(vector);

            transform.rotation = Quaternion.Euler(0, eulerRotation.y,eulerRotation.z);
            
            fireTime = Time.time + fireRate; //Set your fire rate cooldown
        }
    }

}

