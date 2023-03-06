using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] itemObj;

    [SerializeField] List<GameObject>[] enemys;
    [SerializeField] List<GameObject>[] items; 

    void Start()
    {
        enemys = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = new List<GameObject>();
        }

        items = new List<GameObject>[itemObj.Length];

        for (int i = 0; i < itemObj.Length; i++)
        {
            items[i] = new List<GameObject>();
        }
    }

    public GameObject SpawnAct(int index)
    {
        GameObject enemy = Instantiate(prefabs[index], transform);

        return enemy;
    }

    public GameObject SpawnItem(int index)
    {
        GameObject item = Instantiate(prefabs[index], transform);

        return item;
    }
}
