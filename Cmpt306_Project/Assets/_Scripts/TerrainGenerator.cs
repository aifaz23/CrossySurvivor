using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // to track where to put the next layer
    private Vector3 currentPosition = new Vector3(0, 0, -15);
    [SerializeField] private int maxLayerCount = 60;
    // [SerializeField] private List<GameObject> grassList = new List<GameObject>();
    public List<GameObject> currentLayers = new List<GameObject>();
    // private int grassNumber = 0;
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
        maxLayerCount = 60;
        switchTerrain();
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

            if (layerCounter == 4)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, forestPrefabs.Count);
                    float randomX = Random.Range(-(int)width, (int)width);
                    
                    GameObject obstacle = Instantiate(forestPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
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

            if (layerCounter == 4)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, desertPrefabs.Count);
                    float randomX = Random.Range(-(int)width, (int)width);

                    GameObject obstacle = Instantiate(desertPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
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
        if (terrainNumber == 0)
        {
            int numOfObstacles = Random.Range(1, 4);

            GameObject layer = new GameObject("Layer");
            layer.transform.SetParent(transform);
            layer.transform.position = transform.position;

            GameObject terrain = Instantiate(terrainList[terrainNumber], currentPosition, Quaternion.identity, layer.transform);

            if (layerCounter == 4)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, forestPrefabs.Count);
                    float randomX = Random.Range(-(int)width, (int)width);

                    GameObject obstacle = Instantiate(forestPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
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

            if (layerCounter == 4)
            {
                float width = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f)) / 2;

                for (int i = 0; i < numOfObstacles; i++)
                {
                    int randomObstacle = Random.Range(0, desertPrefabs.Count);
                    float randomX = Random.Range(-(int)width, (int)width);

                    GameObject obstacle = Instantiate(desertPrefabs[randomObstacle], layer.transform);
                    obstacle.transform.position = new Vector3(randomX, transform.position.y, currentPosition.z);
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

    public void switchTerrain()
    {
        terrainNumber = Random.Range(0, terrainList.Count);
    }
}
