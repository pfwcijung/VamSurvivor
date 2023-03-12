using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //플레이어 주변에서 적이 생성 되도록 생성 위치 설정
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

        //스테이지 상승에 따라 적 생성 속도 증가
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
