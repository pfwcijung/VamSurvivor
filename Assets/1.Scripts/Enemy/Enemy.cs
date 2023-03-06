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
    public float exp;
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();

    Transform target;
    SpriteRenderer sprite;
    Animator anim;

    bool isLive = true;
    bool isAttack = false;

    float delayTime = 1;
    float deadTime = 0f;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        ed.exp = 10f;
    }

    void Update()
    {
        if (!GameController.instance.player.isLive || !isLive)
        {
            deadTime += Time.deltaTime;

            if (deadTime > 1.5f)
            {
                Destroy(gameObject);
            }

            return;
        }

        if (isAttack)
        {
            if (delayTime > 1f)
            {
                delayTime = 0;
                GameController.instance.player.GetDamage(ed.damage);
            }
            delayTime += Time.deltaTime;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, ed.speed * Time.deltaTime);

        sprite.flipX = target.position.x < transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameController.instance.player.isLive)
            return;

        if (collision.transform == target)
        {
            isAttack = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform == target)
        {
            isAttack = false;
        }
    }

    public void GetDamage(float dmg)
    {
        if (!isLive)
            return;

        ed.curHp -= dmg;

        anim.SetTrigger("Hit");

        if(ed.curHp <= 0)
        {
            isLive = false;
            anim.SetTrigger("Dead");
            transform.tag = "Untagged";
            GetComponent<Collider2D>().isTrigger = true;
            GameController.instance.player.nearstTarget = null;
            GameController.instance.playerCurEXP += ed.exp;
            GameController.instance.attackArea.DestroyOBJ(gameObject);
        }
    }
}
