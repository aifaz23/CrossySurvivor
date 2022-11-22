using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 360.0f; 
    [SerializeField] private Vector3 _rotation; 
    [SerializeField] public float maxHealth = 100.0f; 
    [SerializeField] public float health = 100.0f; 
    private int distanceTravelled;
    private bool speedBuff = false;
    public float speedBuffTime;
    private bool shieldBuff = false;
    public float shieldBuffTime;

    void Start(){
        distanceTravelled = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > speedBuffTime && speedBuff){
            speedBuff=false;
        }
        if (Time.time > shieldBuffTime && shieldBuff){
            shieldBuff=false;
        }
        MovePlayer();
    }

    public int getDistanceTravelled()
    {
        return distanceTravelled;
    }

    //Player Input Controls
    private void MovePlayer() {
        //Forward & Backward Movement 
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 
            distanceTravelled = (int)transform.position.z;
            if(transform.position.x>17){
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); 
            }
            else if(transform.position.x<-17){
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); 
            }
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); 
            if(transform.position.x>17){
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 
            }
            else if(transform.position.x<-17){
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 
            }
        }

        //Left and Right Rotation
        if (Input.GetKey(KeyCode.D)) _rotation = Vector3.up;
        else if (Input.GetKey(KeyCode.A)) _rotation = Vector3.down; 
        else _rotation = Vector3.zero; 
        transform.Rotate(_rotation * rotateSpeed * Time.deltaTime); 

    }
  
    public void TakeDamage (float damage) {
        if(!shieldBuff){
            health -= damage; 
        }
        if (health <= 0) {
            Destroy(this.gameObject);         
            GameManager.instance.GameOver();
        }
    }
    public void kill () {
        health = 0; 
        
        if (health <= 0) {
            Destroy(this.gameObject);         
            GameManager.instance.GameOver();
        }
    }

    public void increaseDamage (float increasedamage) {
        this.GetComponent<GunSwitching>().damageIncrease+=increasedamage;
    }

    public void restoreHP (float hp) {
        health += hp;
        if(health>maxHealth){
            health=maxHealth;
        }
    }

    public void getSpeedBuff()
    {
        moveSpeed+= (Random.Range(0.5f,1));
        speedBuffTime = Time.time + (Random.Range(1f,5f));
        speedBuff=true;
    }
    public void getShieldBuff()
    {
        shieldBuffTime = Time.time + (Random.Range(1f,5f));
        shieldBuff=true;
    }


}


