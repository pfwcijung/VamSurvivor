using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public string targetTag;
    public float speed;
    public float attDamage;
}

//�߻�Ŭ������ ��ȯ ����
public class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    SpriteRenderer sprite;
    Animator anim;
    float curHP = 1;
    float MaxHp = 1;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
