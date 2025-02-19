using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnInterval = 10f;
    public int groupSize = 1;
    public Vector3 groupCenter = new Vector3 (-40f, 0, 0);
    public float groupRadius = 10f; 
    
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnZombieGroup", 0f, spawnInterval);
    }

    void SpawnZombieGroup()
    {
        for (int i = 0; i < groupSize; i++)
        {
            // Generate a random position within the group radius
            Vector2 randomOffset2D = Random.insideUnitCircle * groupRadius;
            Vector3 spawnPosition = groupCenter + new Vector3(randomOffset2D.x, 0f, randomOffset2D.y);

            // Instantiate the zombie
            GameObject zombieInstance = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            zombieInstance.transform.position = new Vector3(zombieInstance.transform.position.x, 0f, zombieInstance.transform.position.z);  
            
            // Make the zombie face the player
            Vector3 directionToPlayer = (player.transform.position - zombieInstance.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            zombieInstance.transform.rotation = lookRotation;
        }
        groupSize++; // Increase group size
    }
}