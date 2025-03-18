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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SpawnEnemies();
            Destroy(gameObject);
        }
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
