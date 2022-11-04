using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // to track where to put the next layer
    private Vector3 currentPosition = new Vector3(0, 0, -15);
    [SerializeField] private int maxLayerCount = 30;
    [SerializeField] private List<GameObject> grassList = new List<GameObject>();
    private List<GameObject> currentLayers = new List<GameObject>();
    private int grassNumber = 0;
    public int currentDistance = 0;
    [SerializeField] private GameObject spawner;
    private void Start()
    {
        maxLayerCount = 60;
        for (int i = 0; i < maxLayerCount; i++)
        {
            InitialSpawnTerrain();
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
        int[] xLocation = new int[] { -19, 19 };

        if (grassNumber > 1)
        {
            grassNumber = 0;
        }
        GameObject layer = new GameObject("Layer");
        layer.transform.SetParent(transform);
        layer.transform.position = transform.position;


        GameObject grass = Instantiate(grassList[grassNumber], currentPosition, Quaternion.identity, layer.transform);
        if (currentDistance % 7 == 0 && currentDistance != 0)
        {
            GameObject sp = Instantiate(spawner, currentPosition, Quaternion.identity, layer.transform);
            int index = Random.Range(0, 2);
            sp.transform.position = new Vector3(sp.transform.position.x + xLocation[index], sp.transform.position.y, sp.transform.position.z);
            // sp.transform.position = new Vector3(sp.transform.position.x - xLocation[index], sp.transform.position.y, sp.transform.position.z);
        }
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
