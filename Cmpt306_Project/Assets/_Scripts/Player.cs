using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] public float health = 100.0f;
    private int distanceTravelled;
    public bool speedBuff = false;
    public float speedBuffTime;
    public bool shieldBuff = false;
    public float shieldBuffTime;

    void Start()
    {
        distanceTravelled = 0;
        health = maxHealth;


    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > speedBuffTime && speedBuff)
        {
            speedBuff = false;
        }
        if (Time.time > shieldBuffTime && shieldBuff)
        {
            shieldBuff = false;
        }
        if (health <= 10.0f)
        {
            GameManager.scaleDown = true;
        }
        if (health > 10.0f)
        {
            GameManager.scaleDown = false;
        }

        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetMaxHealth(maxHealth);
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(health);
        MovePlayer();
    }

    public int getDistanceTravelled()
    {
        return distanceTravelled;
    }

    //Player Input Controls
    private void MovePlayer()
    {
        float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;
        //Forward & Backward Movement 
        if (Input.GetKey(Binds.forward)){
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 
            FindObjectOfType<AudioManager>().Play("Footstep");    
            distanceTravelled = (int)transform.position.z;
        }
        if (Input.GetKey(Binds.backward)) {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); 
            FindObjectOfType<AudioManager>().Play("Footstep");    
        }
        if (Input.GetKey(Binds.right)) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); 
            FindObjectOfType<AudioManager>().Play("Footstep");    
            if(transform.position.x>width){
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); 
            }
            else if(transform.position.x<-width){
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); 
            }
        }
        if (Input.GetKey(Binds.left)) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); 
            FindObjectOfType<AudioManager>().Play("Footstep");    
            if(transform.position.x>width){
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); 
            }
            else if(transform.position.x<-width){
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); 
            }
        }
     

        //Kill player if too far ahead or behind
        Vector3 cameraPosition = GameManager.instance.camera.transform.position;
        if (cameraPosition.z > (transform.position.z + 8.0f))
        {
            kill();
        }
        else if (cameraPosition.z < (transform.position.z - 8.0f))
        {
            kill();
        }

    }

    public void TakeDamage(float damage)
    {
        if (!shieldBuff)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            kill();
        }
    }

    public void kill()
    {
        health = 0;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(health);
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().changeVolume("gameMusic", 0f);
            FindObjectOfType<AudioManager>().Play("GameOver");
            Destroy(this.gameObject);
            GameManager.instance.GameOver();
            GameManager.instance.playerDead = true;
        }
    }

    public void increaseDamage(float increasedamage)
    {
        FindObjectOfType<AudioManager>().Play("pick");   
        this.GetComponent<GunSwitching>().damageIncrease += increasedamage;
    }

    public void restoreHP(float hp)
    {
        FindObjectOfType<AudioManager>().Play("pick");   
        health += hp;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void getSpeedBuff()
    {
        FindObjectOfType<AudioManager>().Play("pick");   
        moveSpeed += (Random.Range(0.5f, 1));
        speedBuffTime = Time.time + (Random.Range(1f, 5f));
        speedBuff = true;
    }

    public void getShieldBuff()
    {
        FindObjectOfType<AudioManager>().Play("pick");   
        shieldBuffTime = Time.time + (Random.Range(1f, 5f));
        shieldBuff = true;
    }



    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Debug.Log("Collided with obstacle");
            if (Input.GetKey(Binds.forward))
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(Binds.backward))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(Binds.left))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * 2f);
            }
            if (Input.GetKey(Binds.right))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime * 2f);
            }
        }
    }
}


