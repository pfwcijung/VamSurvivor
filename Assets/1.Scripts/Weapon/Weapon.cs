using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] weaponPrefabs;

    [SerializeField] List<GameObject>[] weapons;

    void Start()
    {
        weapons = new List<GameObject>[weaponPrefabs.Length];

        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = new List<GameObject>();
        }
    }

    public GameObject SpawnWeapon(int index)
    {
        GameObject weapon = Instantiate(weaponPrefabs[index], transform);

        return weapon;
    }
}
