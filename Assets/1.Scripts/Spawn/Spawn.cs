using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //��
    public GameObject[] prefabs;
    [SerializeField] List<GameObject>[] enemys;

    //������
    public GameObject[] itemObj;
    [SerializeField] List<GameObject>[] items;

    //����
    public GameObject[] weaponPrefabs;
    [SerializeField] List<GameObject>[] weapons;
    public GameObject boomArea;
    void Start()
    {
        //������ �Ҵ�
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
        //Ÿ�Կ� ���� �ٸ��� ����

        //���� ���� �������� ����
        if (type == "enemy")
        {
            GameObject enemy = Instantiate(prefabs[index], transform);

            return enemy;
        }
        //�������� ���� ���� ��ġ�� ����
        else if(type == "item")
        {
            GameObject item = Instantiate(itemObj[index], transform);

            return item;
        }
        //����� �÷��̾� ��ġ, ������ ��ġ���� ����
        else if(type == "weapon")
        {
            GameObject weapon = Instantiate(weaponPrefabs[index], transform);

            return weapon;
        }
        else
            return null;
    }
}
