using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] public float damage;


    // Start is called before the first frame update
    void Start()
    {
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
        if (other.transform.tag == "Player")
        {
            switch (transform.parent.tag)
            {
                case "Enemy1":
                    {
                        damage = transform.parent.GetComponent<Enemy1>().projectileDamage;
                        break;
                    }
                case "Enemy2":
                    {
                        damage = transform.parent.GetComponent<Enemy2>().projectileDamage;
                        break;
                    }
                case "Enemy3":
                    {
                        damage = transform.parent.GetComponent<Enemy3>().projectileDamage;
                        break;
                    }
                case "Boss":
                    {
                        damage = transform.parent.GetComponent<Boss>().projectileDamage;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            other.GetComponent<Player>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}

