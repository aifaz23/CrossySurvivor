using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthDrop : MonoBehaviour
{
    [SerializeField] public float health = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            Destroy(this.gameObject); 
            other.GetComponent<Player>().restoreHP(health); 
        }     

    }
    void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Enemy")
         {
             Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
         }
         if (collision.gameObject.tag == "Drop")
         {
             Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
         }
     }

}
