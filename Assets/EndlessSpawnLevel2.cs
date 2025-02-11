using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawnLevel2 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnpoint;
    public Transform secondspn;
    public Transform tspn;
    public Transform fspn;
    public Transform fispn;
    public Transform sspn;

    float spawnInterval = 4f;
    float minimumSpawnInterval = 1f;
    float intervalDecrease = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
            if (objectToSpawn != null && spawnpoint != null)
            {
                Instantiate(objectToSpawn, spawnpoint.position, spawnpoint.rotation);
                Instantiate(objectToSpawn, secondspn.position, secondspn.rotation);
                Instantiate(objectToSpawn, tspn.position, tspn.rotation);
                Instantiate(objectToSpawn, fspn.position, fspn.rotation);
                Instantiate(objectToSpawn, fispn.position, fispn.rotation);
                Instantiate(objectToSpawn, sspn.position, sspn.rotation);
            }
    }
}
