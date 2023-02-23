using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public string targetTag;
    public float speed;
    public float damage;
    public float curHp;
    public float maxHp;
}

//추상클래스로 전환 예정
public class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    Transform target;

    SpriteRenderer sprite;
    Animator anim;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ed.targetTag = "player";
        ed.speed = 2f;
        target = GameObject.FindGameObjectWithTag(ed.targetTag).GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, ed.speed * Time.deltaTime);

        sprite.flipX = target.position.x < transform.position.x;
    }
}
