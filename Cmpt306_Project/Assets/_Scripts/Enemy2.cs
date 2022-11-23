using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float health = 99.0f;

    [SerializeField] private float damageToPlayer = 20.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    private bool moveLeft = false;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 1f;
    private float fireTime;
    [SerializeField] public float projectileDamage = 2;

    public GameObject healthPrefab;
    public GameObject weaponPrefab;
    void Start()
    {
        if (GameManager.instance.player != null)
        {
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            if (GameManager.instance.player)
            { //null reference check
                if (transform.position.x >= 12)
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
        if (transform.position.x < -15 || transform.position.x > 15)
        {
            Destroy(this.gameObject);
        }
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
            int dropChance = (Random.Range(0, 2));
            if (dropChance == 1)
            {
                int drop = (Random.Range(0, 2));
                if (drop == 1)
                {
                    GameObject healthpack = Instantiate(healthPrefab, transform.position, transform.rotation);
                    healthpack.GetComponent<healthDrop>().health = (Random.Range(10, 100));
                }
                else
                {
                    GameObject weapondrop = Instantiate(weaponPrefab, transform.position, transform.rotation);
                    weapondrop.GetComponent<GunDrop>().damage = (Random.Range(1, 7));
                    // rotate on its side
                    weapondrop.transform.eulerAngles = new Vector3(-1, -200, -90);
                }
            }
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
