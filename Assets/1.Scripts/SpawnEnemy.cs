using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] weaponPrefabs;

    [SerializeField] List<GameObject>[] enemys;
    [SerializeField] List<GameObject>[] weapons;

    void Start()
    {
        enemys = new List<GameObject>[prefabs.Length];
        weapons = new List<GameObject>[weaponPrefabs.Length];

        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = new List<GameObject>();
        }
        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = new List<GameObject>();
        }
    }

    public GameObject SpawnAct(int index)
    {
        GameObject enemy = Instantiate(prefabs[index], transform);

        return enemy;
    }

    public GameObject SpawnWeapon(int index)
    {
        GameObject weapon = Instantiate(weaponPrefabs[index], transform);

        return weapon;
    }
}
