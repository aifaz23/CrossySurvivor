using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> enemyPrefabList = new List<GameObject>();

    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    [SerializeField] private float spawnRate = 10f;
    private float spawnTimer;

    // Update is called once per frame
    void Update()
    {
        //Only spawn normal enemies when in normal phase(not boss phase)
        if (!GameManager.getIsBossPhase())
        {
            SpawnEnemy();
        }
        else
        {
            spawnTimer = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        if (Time.time > spawnTimer)
        {
            float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;
            Vector3 cameraPosition = GameManager.instance.camera.transform.position;
            int newX = (int)width;
            int leftOrRight = (Random.Range(0, 2));
            int newZ = 10;
            if (leftOrRight == 1)
            {
                newX = (int)-width;
            }

            int randomEnemy = Random.Range(0, 3);
            GameObject enemy = enemyPrefabList[randomEnemy];
            if (GameManager.score >= 50)
            {
                if (GameManager.score % 25 == 0)
                {              
                    if (enemy.tag == "Enemy1")
                    {
                        enemy.GetComponent<Enemy1>().health = enemy.GetComponent<Enemy1>().health + 5;
                    }
                    if (enemy.tag == "Enemy2")
                    {
                        enemy.GetComponent<Enemy2>().health = enemy.GetComponent<Enemy2>().health + 5;
                    }
                    if (enemy.tag == "Enemy3")
                    {
                        enemy.GetComponent<Enemy3>().health = enemy.GetComponent<Enemy3>().health + 5;
                    }
                }
            }

            if (GameManager.scaleDown)
            {
                if (enemy.tag == "Enemy1")
                {
                    spawnRate = 20f;
                    enemy.GetComponent<Enemy1>().damageToPlayer = 1.0f;
                    enemy.GetComponent<Enemy1>().projectileDamage = 0.5f;
                }
                if (enemy.tag == "Enemy2")
                {
                    spawnRate = 20f;
                    enemy.GetComponent<Enemy2>().damageToPlayer = 1.0f;
                    enemy.GetComponent<Enemy2>().projectileDamage = 0.5f;
                }
                if (enemy.tag == "Enemy3")
                {
                    spawnRate = 20f;
                    enemy.GetComponent<Enemy3>().damageToPlayer = 1.0f;
                    enemy.GetComponent<Enemy3>().projectileDamage = 0.5f;
                }
            }

            else if (!GameManager.scaleDown)
            {
                if (enemy.tag == "Enemy1")
                {
                    spawnRate = 10f;
                    enemy.GetComponent<Enemy1>().damageToPlayer = 20.0f;
                    enemy.GetComponent<Enemy1>().projectileDamage = 5.0f;
                }
                if (enemy.tag == "Enemy2")
                {
                    spawnRate = 10f;
                    enemy.GetComponent<Enemy2>().damageToPlayer = 20.0f;
                    enemy.GetComponent<Enemy2>().projectileDamage = 2.0f;
                }
                if (enemy.tag == "Enemy3")
                {
                    spawnRate = 10f;
                    enemy.GetComponent<Enemy3>().damageToPlayer = 20.0f;
                    enemy.GetComponent<Enemy3>().projectileDamage = 8.0f;
                }
            }

            Vector3 randomLocation = new Vector3(cameraPosition.x + newX, 1, cameraPosition.z + newZ);
            Instantiate(enemy, randomLocation, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }

    public void SpawnBoss()
    {
        Vector3 cameraPosition = GameManager.instance.camera.transform.position;
        Vector3 bossLocation = new Vector3(cameraPosition.x, 0.72f, cameraPosition.z + 5);
        Instantiate(bossPrefab, bossLocation, transform.rotation);
    }
}
