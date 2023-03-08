using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject[] weaponPrefabs;

    [SerializeField] List<GameObject>[] weapons;

    public GameObject boomArea;

    void Start()
    {
        weapons = new List<GameObject>[weaponPrefabs.Length];

        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = new List<GameObject>();
        }
    }

    public GameObject SpawnAct(int index)
    {
        GameObject weapon = Instantiate(weaponPrefabs[index], transform);

        return weapon;
    }
}
