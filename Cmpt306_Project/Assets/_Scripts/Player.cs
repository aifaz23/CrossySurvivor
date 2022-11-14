using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 360.0f; 
    [SerializeField] private Vector3 _rotation; 
    [SerializeField] private float maxHealth = 100.0f; 
    [SerializeField] private float health = 100.0f; 
    private int distanceTravelled;

    public HealthBar healthBar;
    
    void Start(){
        distanceTravelled = 0;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
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
        health -= damage; 
        healthBar.SetHealth(health);
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
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Gun");
        foreach (GameObject go in gos)
        {
            go.GetComponent<Gun>().damages += increasedamage;
        }
    }

    public void restoreHP (float hp) {
        health += hp;
        if(health>maxHealth){
            health=maxHealth;
        }
    }


}


