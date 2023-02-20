using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;

    float spawnDelayTime = 0;
    
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        spawnDelayTime += Time.deltaTime;

        if(spawnDelayTime >= 2f)
        {
            spawnDelayTime = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        int spawnTrans = Random.RandomRange(1, spawnPoints.Length);
    }
}
