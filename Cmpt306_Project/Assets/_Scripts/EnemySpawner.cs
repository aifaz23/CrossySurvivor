using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public List<GameObject> enemyPrefabList = new List<GameObject>();

    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    [SerializeField] private float spawnRate = 10f;
    private float spawnTimer;


    // Update is called once per frame
    void Update()
    {
        //Only spawn normal enemies when in normal phase(not boss phase)
        if(!GameManager.getIsBossPhase()){
            SpawnEnemy();
        }else{
            spawnTimer = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy() {
        if (Time.time > spawnTimer) {
            float width = (1/ (Camera.main.WorldToViewportPoint(new Vector3(1,1,0)).x - .5f))/2;
            Vector3 cameraPosition = GameManager.instance.camera.transform.position;
            int newX = (int)width;
            int leftOrRight = (Random.Range(0,2));
            int newZ = 10;
            if(leftOrRight==1){
                newX = (int)-width;
            }

            int randomEnemy = Random.Range(0, 3);
   
            Vector3 randomLocation = new Vector3(cameraPosition.x +newX,1,cameraPosition.z+newZ);
            Instantiate(enemyPrefabList[randomEnemy], randomLocation, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }

    public void SpawnBoss(){
        Vector3 cameraPosition = GameManager.instance.camera.transform.position;
        Vector3 bossLocation = new Vector3(cameraPosition.x,1,cameraPosition.z+10);
        Instantiate(bossPrefab, bossLocation, transform.rotation);
    }
}