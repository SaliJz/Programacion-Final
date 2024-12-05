using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles = new List<GameObject>();
    [SerializeField] private GameObject[] tilePrefabs;
    [SerializeField] private float tileLength = 30f;
    [SerializeField] private int numberOfTiles = 3;

    private float zSpawn = 0;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(i == 0 ? 0 : Random.Range(0, tilePrefabs.Length));
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - 35 >= zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int index)
    {
        GameObject tile = Instantiate(tilePrefabs[index], Vector3.forward * zSpawn, Quaternion.identity);
        activeTiles.Add(tile);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        PlayerManager.score += 3; // Incrementar el puntaje
    }
}
