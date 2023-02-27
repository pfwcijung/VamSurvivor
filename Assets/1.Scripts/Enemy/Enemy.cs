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

    List<GameObject> inAttArea;

    Transform target;
    SpriteRenderer sprite;
    Animator anim;

    bool isLive = true;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!GameController.instance.player.isLive || !isLive)
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
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("attArea"))
        {
            inAttArea.Add(gameObject);
        }

        float distance = 100f;

        foreach(var item in inAttArea)
        {
            float itemDis = Vector3.Distance(item.transform.position, GameController.instance.player.transform.position);
            if (itemDis < distance)
            {
                distance = itemDis;
                GameController.instance.player.nearstTarget = item.gameObject;
            }
        }
    }*/

    public void GetDamage(float dmg)
    {
        if (!isLive)
            return;

        ed.curHp -= dmg;

        if(ed.curHp <= 0)
        {
            isLive = false;
            anim.SetTrigger("Dead");
        }
    }
}
