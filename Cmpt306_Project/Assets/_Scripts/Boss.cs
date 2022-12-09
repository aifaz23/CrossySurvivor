using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Default Boss stats
    [SerializeField] private float moveSpeed = 2.0f; 
    [SerializeField] private float health = 500.0f; 
    private float maxHealth = 500.0f;

    [SerializeField] private float damageToPlayer = 90.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    [SerializeField] private GameObject BossDrops;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 5f;
    private float fireTime;
    [SerializeField] public float projectileDamage = 10;
    private float angle = 0f;
    private Vector3 bulletMoveDirection;

    //Random movement stuff
    private float changeDirectionTimer;

    //Rocket Stuff
    [SerializeField] private float rocketFireRate = 9f;
    [SerializeField] private GameObject rocket;
    

    // Start is called before the first frame update
    void Start()
    {
        changeDirectionTimer = Random.Range(3,7);
        InvokeRepeating("Fire", 0f, 0.1f);
        InvokeRepeating("FireRocket", 0f, rocketFireRate);
    }

    // Update is called once per frame
    void Update()
    {
        ShootCircle();
        
        GameObject.Find("BossHealth").GetComponent<HealthBar>().SetMaxHealth(maxHealth);
        GameObject.Find("BossHealth").GetComponent<HealthBar>().SetHealth(health);
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
            float width = (1/ (Camera.main.WorldToViewportPoint(new Vector3(1,1,0)).x - .5f))/2;

            if(transform.position.x - cameraPos.x >Camera.main.transform.position.x +width){
                transform.rotation = Quaternion.Euler(0, Random.Range(90,270), 0);
            }else if(transform.position.x- cameraPos.x <Camera.main.transform.position.x -width){
                transform.rotation = Quaternion.Euler(0, Random.Range(-90,90), 0);
            }else if(transform.position.z-cameraPos.z >8.5){
                transform.rotation = Quaternion.Euler(0, Random.Range(-180,0), 0);
            }else if(transform.position.z- cameraPos.z <-8.5){
                transform.rotation = Quaternion.Euler(0, Random.Range(0,180), 0);
            }
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void Fire(){
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle, 0), this.transform);
        GameObject bullet2 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle + 180f, 0), this.transform);
        angle +=10f;
        if(angle >=360f){
            angle = 0f;
        }
    }

    public void TakeDamage (float damage) {
        health -=damage;
        if (health <= 0) {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("bossDeath");   
            Instantiate(BossDrops, transform.position, transform.rotation);
            GameObject.Find("TerrainGenerator").GetComponent<TerrainGenerator>().switchTerrain();
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
                GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, currentAngle, 0), this.transform);
                
                currentAngle+=10;
            }
            fireTime = Time.time + fireRate;
        }
    }

    public void increaseHealth(){
        health += 500;
        maxHealth += 500;
    }
        
    private void FireRocket(){
        GameObject launchedRocket = Instantiate(rocket, transform.position, transform.rotation);
    }