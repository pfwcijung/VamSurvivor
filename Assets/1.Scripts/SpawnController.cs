using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] prefabs;

    float spawnDelayTime = 0;
    
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        spawnDelayTime += Time.deltaTime;

        if(spawnDelayTime >= 1f)
        {
            spawnDelayTime = 0;
            Spawn(0);
        }
    }

    void Spawn(int index)
    {
        GameObject enemy = prefabs[index];
        Instantiate(enemy, spawnPoints[Random.Range(1, spawnPoints.Length)]);
    }
}
