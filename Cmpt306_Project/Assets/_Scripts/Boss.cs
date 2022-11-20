using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    //Default Boss stats
    [SerializeField] private float moveSpeed = 2.0f; 
    [SerializeField] private float health = 500.0f;
    
    [SerializeField] private float damageToPlayer = 90.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 3f;
    private float fireTime;
    [SerializeField] public float projectileDamage = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Movement(); 
    }

    private void Movement () {
        if (GameManager.instance.player) {//null reference check
            transform.LookAt(GameManager.instance.player.transform.position);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage (float damage) {
        health -=damage;
        if (health <= 0) {
            Destroy(this.gameObject);
            GameManager.instance.changePhase();
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player" && Time.time > damageTime) {
            other.transform.GetComponent<Player>().TakeDamage(damageToPlayer); 
            damageTime = Time.time + damageRate;             
        }        
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy"){
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    public void Shoot()
    {
        if (Time.time > fireTime){
            //Shoot in all straight and diagonal angles
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 45, 0));
            GameObject bullet1 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -45, 0));
            GameObject bullet2 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -125, 0));
            GameObject bullet3 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 125, 0));
            GameObject bullet4 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 0, 0));
            GameObject bullet5 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0));
            GameObject bullet6 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));
            GameObject bullet7 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 180, 0));
            
            // bullet.GetComponent<Projectile>().damage = projectileDamage;
            fireTime = Time.time + fireRate;
        }
    }
}
