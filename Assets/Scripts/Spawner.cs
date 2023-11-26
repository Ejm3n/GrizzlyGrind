using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minSpawnTimer= 4;
    [SerializeField] private float maxSpawnTimer = 7;
    [SerializeField] private GameObject objectToSpawn;
    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTimer, maxSpawnTimer);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(objectToSpawn,transform);
        }
    }
}
