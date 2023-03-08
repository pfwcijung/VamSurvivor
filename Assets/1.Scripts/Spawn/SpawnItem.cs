using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] itemObj;

    [SerializeField] List<GameObject>[] items;

    void Start()
    {
        items = new List<GameObject>[itemObj.Length];

        for (int i = 0; i < itemObj.Length; i++)
        {
            items[i] = new List<GameObject>();
        }
    }
    public GameObject SpawnAct(int index, float exp)
    {
        GameObject item = Instantiate(itemObj[index], transform);
        return item;
    }
}
