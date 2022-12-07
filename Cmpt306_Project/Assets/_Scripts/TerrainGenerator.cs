using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // to track where to put the next layer
    private Vector3 currentPosition = new Vector3(0, 0, -15);
    [SerializeField] private int maxLayerCount = 60;
    public List<GameObject> currentLayers = new List<GameObject>();
    public int currentDistance = 0;
    [SerializeField] private GameObject spawner;

    [SerializeField] private List<GameObject> terrainList = new List<GameObject>();
    [SerializeField] private List<GameObject> forestPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> desertPrefabs = new List<GameObject>();
    public int terrainNumber;
    public int layerCounter;

    private void Start()
    {
        layerCounter = 0;
        maxLayerCount = 35;
        terrainNumber = Random.Range(0, terrainList.Count);
        for (int i = 0; i < maxLayerCount; i++)
        {
            InitialSpawn();
        }
    }

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            int playerDistance = GameObject.Find("Player").GetComponent<Player>().getDistanceTravelled();
            if (playerDistance > currentDistance)
            {
                SpawnTerrain();
                currentDistance = playerDistance;
            }
        }
    }

    private void InitialSpawn()
    {
        if (terrainNumber == 0)
        {
            int numOfObstacles = Random.Range(1, 4);

            GameObject layer = new GameObject("Layer");
            layer.transform.SetParent(transform);
            layer.transform.position = transform.position;

            GameObject terrain = Instantiate(terrainList[terrainNumber], currentPosition, Quaternion.identity, layer.transform);

            if (layerCounter == 6)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;
                List<int> obstacleLocations = new List<int>();

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, forestPrefabs.Count);
                    int randomX = Random.Range((int)-width, (int)width);
                    while (obstacleLocations.Contains(randomX))
                    {
                        randomX = Random.Range((int)-width, (int)width);
                    }
                    obstacleLocations.Add(randomX);

                    GameObject obstacle = Instantiate(forestPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
                    obstacle.transform.Rotate(0.0f, Random.Range(0, 360), 0.0f);
                }
                layerCounter = 0;
            }

            currentLayers.Add(layer);
            layerCounter++;

            if (currentLayers.Count > maxLayerCount)
            {
                Destroy(currentLayers[0]);
                currentLayers.RemoveAt(0);
            }
            currentPosition.z++;
        }
        else if (terrainNumber == 1)
        {
            int numOfObstacles = Random.Range(1, 4);

            GameObject layer = new GameObject("Layer");
            layer.transform.SetParent(transform);
            layer.transform.position = transform.position;

            GameObject terrain = Instantiate(terrainList[terrainNumber], currentPosition, Quaternion.identity, layer.transform);

            if (layerCounter == 6)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;
                List<int> obstacleLocations = new List<int>();

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, desertPrefabs.Count);
                    int randomX = Random.Range((int)-width, (int)width);
                    while (obstacleLocations.Contains(randomX))
                    {
                        randomX = Random.Range((int)-width, (int)width);
                    }
                    obstacleLocations.Add(randomX);

                    GameObject obstacle = Instantiate(desertPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
                    obstacle.transform.Rotate(0.0f, Random.Range(0, 360), 0.0f);
                }
                layerCounter = 0;
            }

            currentLayers.Add(layer);
            layerCounter++;

            if (currentLayers.Count > maxLayerCount)
            {
                Destroy(currentLayers[0]);
                currentLayers.RemoveAt(0);
            }
            currentPosition.z++;
        }
    }

    private void SpawnTerrain()
    {
        maxLayerCount = 30;
        int[] xLocation = new int[] { -19, 19 };
        if (terrainNumber == 0)
        {
            int numOfObstacles = Random.Range(1, 4);

            GameObject layer = new GameObject("Layer");
            layer.transform.SetParent(transform);
            layer.transform.position = transform.position;

            GameObject terrain = Instantiate(terrainList[terrainNumber], currentPosition, Quaternion.identity, layer.transform);
            List<int> obstacleLocations = new List<int>();

            if (layerCounter == 6)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, forestPrefabs.Count);
                    int randomX = Random.Range((int)-width, (int)width);

                    while (obstacleLocations.Contains(randomX))
                    {
                        randomX = Random.Range((int)-width, (int)width);
                    }
                    obstacleLocations.Add(randomX);

                    GameObject obstacle = Instantiate(forestPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
                    obstacle.transform.Rotate(0.0f, Random.Range(0, 360), 0.0f);
                }
                layerCounter = 0;
            }
            if (currentDistance % 7 == 0 && currentDistance != 0)
            {
                GameObject sp = Instantiate(spawner, currentPosition, Quaternion.identity, layer.transform);
                int index = Random.Range(0, 2);
                sp.transform.position = new Vector3(sp.transform.position.x + xLocation[index], sp.transform.position.y, sp.transform.position.z);
            }

            currentLayers.Add(layer);
            layerCounter++;

            if (currentLayers.Count > maxLayerCount)
            {
                Destroy(currentLayers[0]);
                currentLayers.RemoveAt(0);
            }
            currentPosition.z++;
        }
        else if (terrainNumber == 1)
        {
            int numOfObstacles = Random.Range(1, 4);

            GameObject layer = new GameObject("Layer");
            layer.transform.SetParent(transform);
            layer.transform.position = transform.position;

            GameObject terrain = Instantiate(terrainList[terrainNumber], currentPosition, Quaternion.identity, layer.transform);

            if (layerCounter == 6)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;
                List<int> obstacleLocations = new List<int>();

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, desertPrefabs.Count);
                    int randomX = Random.Range((int)-width, (int)width);

                    while (obstacleLocations.Contains(randomX))
                    {
                        randomX = Random.Range((int)-width, (int)width);
                    }
                    obstacleLocations.Add(randomX);

                    GameObject obstacle = Instantiate(desertPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
                    obstacle.transform.Rotate(0.0f, Random.Range(0, 360), 0.0f);
                }
                layerCounter = 0;
            }
            if (currentDistance % 7 == 0 && currentDistance != 0)
            {
                GameObject sp = Instantiate(spawner, currentPosition, Quaternion.identity, layer.transform);
                int index = Random.Range(0, 2);
                sp.transform.position = new Vector3(sp.transform.position.x + xLocation[index], sp.transform.position.y, sp.transform.position.z);
            }

            currentLayers.Add(layer);
            layerCounter++;

            if (currentLayers.Count > maxLayerCount)
            {
                Destroy(currentLayers[0]);
                currentLayers.RemoveAt(0);
            }
            currentPosition.z++;
        }
    }

    public void switchTerrain()
    {
        if(terrainNumber==0){
            terrainNumber=1;
        }
        else{
            terrainNumber=0;
        }
        
    }

    public void addExtraLayer()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject layer = new GameObject("Layer");
            layer.transform.SetParent(transform);
            layer.transform.position = transform.position;

            GameObject terrain = Instantiate(terrainList[terrainNumber], currentPosition, Quaternion.identity, layer.transform);
            currentLayers.Add(layer);
            currentPosition.z++;
        }
    }
}
