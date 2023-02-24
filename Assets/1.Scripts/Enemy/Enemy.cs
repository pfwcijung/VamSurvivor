using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float damage;
    public float curHp;
    public float maxHp;
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    Transform target;
    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!GameController.instance.player.isLive)
            return;

        transform.position = Vector2.MoveTowards(transform.position, target.position, ed.speed * Time.deltaTime);

        sprite.flipX = target.position.x < transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameController.instance.player.isLive)
            return;

        if (collision.transform == target)
        {
            GameController.instance.player.GetDamage(ed.damage);
        }
        return;
        // 1초마다 틱 데미지로 들어가게 하려면 ??
    }
}
