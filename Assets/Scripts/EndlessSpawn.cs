using UnityEngine;
using System.Collections;
using System.Threading;

public class EndlessSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnpoint;
    public Transform secondspn;
    public Transform thirdspn;

    float spawnInterval = 4f;
    float minimumSpawnInterval = 1f;
    float intervalDecrease = 0.1f;
    public bool level1completed;

    private IEnumerator spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        level1completed = false;
        spawnCoroutine = SpawnEnemies();
        StartCoroutine(spawnCoroutine);
    }
    IEnumerator SpawnEnemies()
    {
        if(level1completed == false)
        {
        PortalScript1 portal = GetComponent<PortalScript1>();
        while (true)
        {
            if (objectToSpawn != null && spawnpoint != null)
            {
                Instantiate(objectToSpawn, spawnpoint.position, spawnpoint.rotation);
                Instantiate(objectToSpawn, secondspn.position, secondspn.rotation);
                Instantiate(objectToSpawn, thirdspn.position, thirdspn.rotation);
            }
            else
            {
                Debug.LogWarning("Object to spawn or spawn point is not set");
            }
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - intervalDecrease);
        }
        }
    }

    public void StopSpawningEnemies()
    {
        StopCoroutine(spawnCoroutine);
    }
}
