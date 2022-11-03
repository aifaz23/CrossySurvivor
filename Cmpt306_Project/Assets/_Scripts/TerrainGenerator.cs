using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // to track where to put the next layer
    private Vector3 currentPosition = new Vector3(0, 0, 0);
    [SerializeField] private int maxLayerCount = 30;
    [SerializeField] private List<GameObject> grassList = new List<GameObject>();
    private List<GameObject> currentLayers = new List<GameObject>();
    private int grassNumber = 0;
    public int currentDistance = 0;
    private void Start()
    {
        for (int i = 0; i < maxLayerCount; i++)
        {
            InitialSpawnTerrain();
        }
    }

    private void Update()
    {
        int playerDistance = GameObject.Find("Player").GetComponent<Player>().getDistanceTravelled();
        if (playerDistance > currentDistance)
        {
            SpawnTerrain();
            currentDistance = playerDistance;
        }
    }

    private void InitialSpawnTerrain()
    {
        if (grassNumber > 1)
        {
            grassNumber = 0;
        }
        GameObject layer = Instantiate(grassList[grassNumber], currentPosition, Quaternion.identity, transform);
        currentLayers.Add(layer);

        if (currentLayers.Count > maxLayerCount)
        {
            Destroy(currentLayers[0]);
            currentLayers.RemoveAt(0);
        }
        currentPosition.z++;
        grassNumber++;
    }

    private void SpawnTerrain()
    {
        if (grassNumber > 1)
        {
            grassNumber = 0;
        }
        GameObject layer = Instantiate(grassList[grassNumber], currentPosition, Quaternion.identity, transform);


        currentLayers.Add(layer);

        if (currentLayers.Count > maxLayerCount)
        {
            Destroy(currentLayers[0]);
            currentLayers.RemoveAt(0);
        }
        currentPosition.z++;
        grassNumber++;
    }
}
