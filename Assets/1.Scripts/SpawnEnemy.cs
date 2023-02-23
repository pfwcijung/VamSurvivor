using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] enemys;

    void Start()
    {
        enemys = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = new List<GameObject>();
        }
    }

    public GameObject SpawnAct(int index)
    {
        GameObject enemy = Instantiate(prefabs[index], transform);

        return enemy;
    }
}
