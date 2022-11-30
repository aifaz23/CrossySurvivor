using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] public float health = 99.0f;

    [SerializeField] public float damageToPlayer = 20.0f;
    [SerializeField] public float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    private bool moveLeft = false;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 1f;
    private float fireTime;
    [SerializeField] public float projectileDamage = 5;

    void Start()
    {
        if (GameManager.instance.player != null)
        {
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            if (GameManager.instance.player)
            { //null reference check
                if (transform.position.x >= 1)
                {
                    moveLeft = true;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
        Movement();
        float width = (1/ (Camera.main.WorldToViewportPoint(new Vector3(1,1,0)).x - .5f))/2;
        if (transform.position.x < Camera.main.transform.position.x -width-2 || transform.position.x > Camera.main.transform.position.x +width+2)
        {
            Destroy(this.gameObject);
        }
    }

    public void resetStats() {
        health = 99.0f;
        projectileDamage = 5;
        damageToPlayer = 20.0f;
    }

    private void Movement()
    {
        //Vector3 spot = transform.position;
        if (moveLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime * 2);
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * 2);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            // either 0 or 1
            GameManager.instance.summonDrop(transform.position);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Time.time > damageTime)
        {
            other.transform.GetComponent<Player>().TakeDamage(damageToPlayer);
            damageTime = Time.time + damageRate;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    public void Shoot()
    {
        if (Time.time > fireTime)
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 45, 0), this.transform);
            GameObject bullet1 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -45, 0), this.transform);
            GameObject bullet2 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -125, 0), this.transform);
            GameObject bullet3 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 125, 0), this.transform);

            // bullet.GetComponent<Projectile>().damage = projectileDamage;
            fireTime = Time.time + fireRate;
        }
    }
}
