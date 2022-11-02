using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0, 0, 0);
    [SerializeField] private int maxTerrainCount = 10;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();
    private List<GameObject> currentTerrains = new List<GameObject>();

    private int grassNumber = 0;

    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
        if (grassNumber > 1)
        {
            grassNumber = 0;
        }
        GameObject t = Instantiate(terrains[grassNumber], currentPosition, Quaternion.identity, transform);
        currentTerrains.Add(t);
        if (currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
        currentPosition.x++;
        grassNumber++;
    }
}
