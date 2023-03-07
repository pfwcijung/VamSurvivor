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
        if (!GameController.instance.player.isLive)
            return;

        spawnDelayTime += Time.deltaTime;

        if(spawnDelayTime >= 1f - (0.02 * GameController.instance.enemyUpgrade))
        {
            spawnDelayTime = 0;
            Spawn((int)GameController.instance.level % 5);
        }
    }

    void Spawn(int index)
    {
        GameObject enemy = GameController.instance.spawnEnemy.SpawnAct(index);
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    }
}
