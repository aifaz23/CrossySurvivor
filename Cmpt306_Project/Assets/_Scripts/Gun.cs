using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile; 
    [SerializeField] private float fireRate = 0.1f; 
    private float fireTime; 
    [SerializeField] public float damages = 100.0f;

    void Update() {
        Shoot(); 
    }

    private void Shoot() {
        if(Input.GetKey(KeyCode.Space) && Time.time >= fireTime) {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation); 
            bullet.GetComponent<Projectile>().damage = damages;
            fireTime = Time.time + fireRate; //Set your fire rate cooldown
        }
    }
    

}
