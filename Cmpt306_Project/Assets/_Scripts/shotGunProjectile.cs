using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGunProjectile : MonoBehaviour
{

   [SerializeField] private float lifeTime = 1.0f;   
   [SerializeField] private float moveSpeed = 20.0f; 
   [SerializeField] public float damage = 100.0f; 
   private float positiony;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed=20.0f;
        lifeTime = 0.2f;   
        transform.position = new Vector3(transform.position.x,transform.position.y+0.11f,transform.position.z);
        Vector3 position = transform.position;
        positiony=position.y;
  
        Destroy(this.gameObject, lifeTime); 
    }

    // Update is called once per frame
    void Update()
    {

        MoveProjectile(); 
    }
    
    private void MoveProjectile() {
        
        transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Enemy"){
            other.GetComponent<Enemy>().TakeDamage(damage); 
            Destroy(this.gameObject); 
        }else if(other.transform.tag == "Boss"){
            other.GetComponent<Boss>().TakeDamage(damage); 
            Destroy(this.gameObject); 
        }
    }
    


}
