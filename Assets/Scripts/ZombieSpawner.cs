using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject[] spawnpoints;
    public float spawnRate;
    float maxSpawnRate, minSpawnRate;
    void Start()
    {
        maxSpawnRate = 8;
        minSpawnRate = 1;
        spawnpoints = GameObject.FindGameObjectsWithTag("spawn");
        Invoke("Spawn", 0);
    }

    void Spawn()
    {
        Instantiate(zombie, spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
        spawnRate = Mathf.Lerp(spawnRate, maxSpawnRate - minSpawnRate, 0.15f);
        Invoke("Spawn", maxSpawnRate - spawnRate);
    }
}
