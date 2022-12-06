using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : MonoBehaviour
{
    [SerializeField] private GameObject projectile; 
    [SerializeField] private float fireRate = 2.0f; 
    private float fireTime; 
    [SerializeField] public float baseDamage = 80.0f;
    void start(){
        baseDamage = 80.0f;
        fireRate = 2.0f; 
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

        if(Time.time >= fireTime) {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Sniper");       
            bullet.GetComponent<Projectile>().damage=baseDamage;
            bullet.GetComponent<Projectile>().lifeTime=3.0f;
            bullet.GetComponent<Projectile>().moveSpeed=40.0f;
            transform.LookAt(vector);
            transform.rotation = Quaternion.Euler(0, eulerRotation.y,eulerRotation.z);
            fireTime = Time.time + fireRate; //Set your fire rate cooldown
        }
    }
}
