using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Default Boss stats
    [SerializeField] private float moveSpeed = 2.0f; 
    [SerializeField] private float health = 500.0f;
    
    [SerializeField] private float damageToPlayer = 90.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;

    //Shooting stuff
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 10f;
    private float fireTime;
    [SerializeField] public float projectileDamage = 10;
    private float angle = 0f;
    private Vector3 bulletMoveDirection;

    //Random movement stuff
    private float changeDirectionTimer;


    // Start is called before the first frame update
    void Start()
    {
        changeDirectionTimer = Random.Range(3,7);
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        ShootCircle();
        Movement();
    }

    private void Movement () {
        if (GameManager.instance.player) {//null reference check
        //Change direction the boss is moving
            if(Time.time > changeDirectionTimer){
                transform.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
                changeDirectionTimer = Time.time + Random.Range(3,7);
            }

            Vector3 cameraPos = GameManager.instance.camera.transform.position;

            if(transform.position.x - cameraPos.x >10){
                transform.rotation = Quaternion.Euler(0, Random.Range(90,270), 0);
            }else if(transform.position.x- cameraPos.x <-10){
                transform.rotation = Quaternion.Euler(0, Random.Range(-90,90), 0);
            }else if(transform.position.z-cameraPos.z >15){
                transform.rotation = Quaternion.Euler(0, Random.Range(-180,0), 0);
            }else if(transform.position.z- cameraPos.z <-15){
                transform.rotation = Quaternion.Euler(0, Random.Range(0,180), 0);
            }
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void Fire(){
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle, 0));
        GameObject bullet2 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle + 180f, 0));
        angle +=10f;
        if(angle >=360f){
            angle = 0f;
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

    public void ShootCircle()
    {
        if (Time.time > fireTime){
            //Shoot in all angles in increments
            float currentAngle = 0f;
            while(currentAngle<360){
                GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, currentAngle, 0));
                currentAngle+=10;
            }
            // bullet.GetComponent<Projectile>().damage = projectileDamage;
            fireTime = Time.time + fireRate;
        }
    }
}