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

        if(spawnDelayTime >= 1f)
        {
            spawnDelayTime = 0;
            Spawn(Random.Range(0, 5));
        }
    }

    void Spawn(int index)
    {
        GameObject enemy = GameController.instance.spawnEnemy.SpawnAct(index);
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    }
}
