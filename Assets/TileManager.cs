using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;  // Array of tile prefabs to spawn
    public float zSpawn = 0;          // Initial z-axis position where tiles will spawn
    public float tileLength = 60;     // Length of each tile (ensure this matches actual prefab length)
    public int numberOfTiles = 6;     // How many tiles should exist at any time
    public Transform playerTransform; // Reference to the player object
    private List<GameObject> activeTiles = new List<GameObject>(); // List to keep track of active tiles

    void Start()
    {
        // Check if playerTransform is assigned, otherwise find it by tag "Player"
        /*if (playerTransform == null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }*/

        // Initial tile spawning
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);  // Always spawn the first tile from the first prefab
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));  // Spawn other random tiles
            }
        }
       /* SpawnTile(0);
        SpawnTile(1);
        SpawnTile(4);*/

    }

    void Update()
    {
        // Check if player has passed enough distance to spawn a new tile
        if (playerTransform.position.z-65 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));  // Spawn random tile (index 1 onwards)
            DeleteTile();  // Delete the oldest tile
        }
    }

    public void SpawnTile(int tileIndex)
    {
        // Spawn the tile at the current zSpawn position
        /* Vector3 spawnPosition = new Vector3(0, 0, zSpawn);
         GameObject go = Instantiate(tilePrefabs[tileIndex], spawnPosition, Quaternion.identity);

         // Add the tile to the list of active tiles
         activeTiles.Add(go);

         // Increment zSpawn for the next tile
         zSpawn += tileLength;*/
        GameObject go=Instantiate(tilePrefabs[tileIndex], transform.forward*zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    } 

    private void DeleteTile()
    {
        // Delete the first (oldest) tile in the list
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        Debug.Log("Deleted tile.");
    }
}
