using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; 
    [SerializeField] private float spawnRate = 10f;
    private float spawnTimer; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy(); 
    }

    private void SpawnEnemy() {
        if (Time.time > spawnTimer) {
           
            Vector3 cameraPosition = GameManager.instance.camera.transform.position;
            int newX = 13;
            int leftOrRight = (Random.Range(0,2));
            int newZ = Random.Range(15,25);
            if(leftOrRight==1){
                newX = -13;
            }
   
            Vector3 randomLocation = new Vector3(cameraPosition.x +newX,1,cameraPosition.z+newZ);
            Instantiate(enemyPrefab, randomLocation, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }

    
}
