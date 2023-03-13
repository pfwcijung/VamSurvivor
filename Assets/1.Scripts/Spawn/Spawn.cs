using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //적
    public GameObject[] prefabs;
    [SerializeField] List<GameObject>[] enemys;

    //아이템
    public GameObject[] itemObj;
    [SerializeField] List<GameObject>[] items;

    //무기
    public GameObject[] weaponPrefabs;
    [SerializeField] List<GameObject>[] weapons;
    public GameObject boomArea;
    void Start()
    {
        //프리펩 할당
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

        weapons = new List<GameObject>[weaponPrefabs.Length];

        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = new List<GameObject>();
        }
    }
    public GameObject SpawnAct(string type ,int index)
    {
        //타입에 따라 다르게 생성

        //적은 생성 지점에서 시작
        if (type == "enemy")
        {
            GameObject enemy = Instantiate(prefabs[index], transform);

            return enemy;
        }
        //아이템은 적이 죽은 위치에 생성
        else if(type == "item")
        {
            GameObject item = Instantiate(itemObj[index], transform);

            return item;
        }
        //무기는 플레이어 위치, 랜덤한 위치에서 생성
        else if(type == "weapon")
        {
            GameObject weapon = Instantiate(weaponPrefabs[index], transform);

            return weapon;
        }
        else
            return null;
    }
}
