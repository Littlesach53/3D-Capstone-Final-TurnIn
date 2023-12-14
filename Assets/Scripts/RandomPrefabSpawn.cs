using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawn : MonoBehaviour
{
    [System.Serializable]
    public class PrefabProbability
    {
        public GameObject prefab;
        [Range(1, 100)] public int probability = 1;
    }

    public PrefabProbability[] prefabs; // Array of prefabs with associated probabilities
    public int numberOfPrefabs = 10; // Number of prefabs to spawn
    public BoxCollider spawnArea; // Box collider representing the spawn area
    public Transform player; // Player reference
    public float spawnDistanceThreshold = 100f; // Maximum distance for spawning

    private List<GameObject> spawnedPrefabs = new List<GameObject>();

   void Update()
{
    // Check the distance between the player and the spawn area continuously
    float distanceToPlayer = Vector3.Distance(player.position, spawnArea.bounds.center);

    // Check if prefabs are not already spawned and the player is within the specified distance
    if (spawnedPrefabs.Count == 0 && distanceToPlayer <= spawnDistanceThreshold)
    {
        // Spawn new prefabs when the player is within the specified distance
        SpawnPrefabs();
    }
    else if (spawnedPrefabs.Count > 0 && distanceToPlayer > spawnDistanceThreshold)
    {
        // Despawn prefabs when the player is too far away
        DespawnPrefabs();
    }
}

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Randomly select a prefab based on probabilities
            GameObject prefabToSpawn = ChooseRandomPrefab();

            // Generate a random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            // Instantiate the selected prefab at the random position
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

            // Keep track of the spawned prefab
            spawnedPrefabs.Add(spawnedPrefab);
        }
    }

    void DespawnPrefabs()
    {
        // Check the distance between the player and each spawned prefab
        for (int i = spawnedPrefabs.Count - 1; i >= 0; i--)
        {
            if (spawnedPrefabs[i] != null)
            {
                float distanceToPlayer = Vector3.Distance(player.position, spawnedPrefabs[i].transform.position);

                if (distanceToPlayer > spawnDistanceThreshold)
                {
                    // Despawn the prefab if the player is too far away
                    Destroy(spawnedPrefabs[i]);
                    spawnedPrefabs.RemoveAt(i);
                }
            }
            else
            {
                // Remove null entries from the list
                spawnedPrefabs.RemoveAt(i);
            }
        }
    }

    GameObject ChooseRandomPrefab()
    {
        int totalProbability = 0;

        foreach (var prefab in prefabs)
        {
            totalProbability += prefab.probability;
        }

        int randomValue = Random.Range(1, totalProbability + 1);

        foreach (var prefab in prefabs)
        {
            if (randomValue <= prefab.probability)
            {
                return prefab.prefab;
            }

            randomValue -= prefab.probability;
        }

        // This should not happen, but just in case
        return prefabs[0].prefab;
    }
}