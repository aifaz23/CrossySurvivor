using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] public float lifeTime = 5.0f;   
   [SerializeField] private float moveSpeed = 20.0f; 
   [SerializeField] public float damage=0.0f; 


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed=20.0f;
        transform.position = new Vector3(transform.position.x,transform.position.y+0.11f,transform.position.z);
        
        Destroy(this.gameObject, lifeTime); 
    }

    // Update is called once per frame
    void Update()
    {

        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy1")
        {
            other.GetComponent<Enemy1>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "Enemy2")
        {
            other.GetComponent<Enemy2>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "Enemy3")
        {
            other.GetComponent<Enemy3>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "Boss")
        {
            other.GetComponent<Boss>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
