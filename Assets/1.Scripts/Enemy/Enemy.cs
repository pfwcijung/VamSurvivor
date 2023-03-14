using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모든 적들이 공유하는 데이터
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

    //타겟 : 플레이어, 적의 애니메이션 설정
    Transform target;
    SpriteRenderer sprite;
    Animator anim;

    //적 상태 설정
    bool isLive = true;
    bool isAttack = false;

    //데미지와 죽었을 경우 설정
    float delayTime = 1;
    float deadTime = 0f;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        //플레이어 사망 시 제자리에 고정
        if (!GameController.instance.player.isLive)
            return;

        //적 사망 시 설정
        if (!isLive)
        {
            deadTime += Time.deltaTime;

            if (deadTime > 1.5f)
            {
                //spawnItem = true;
                DropItems();
                Destroy(gameObject);
            }
            return;
        }

        //충돌 시 1초마다 플레이어에게 데미지 들어가도록 함
        if (isAttack)
        {
            if (delayTime > 1f)
            {
                delayTime = 0;
                GameController.instance.player.GetDamage(ed.damage);
            }
            delayTime += Time.deltaTime;
        }

        //타겟(플레이어) 방향으로 움직이기 위함
        transform.position = Vector2.MoveTowards(transform.position, target.position, ed.speed * Time.deltaTime);

        sprite.flipX = target.position.x < transform.position.x;
    }

    //플레이어 공격
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameController.instance.player.isLive)
            return;

        if (collision.transform == target)
        {
            isAttack = true;
        }
    }
    //플레이어 도망 성공
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform == target)
        {
            isAttack = false;
        }
    }

    //적 데미지 받게 하기 위함
    public void GetDamage(float dmg)
    {
        if (!isLive)
            return;

        ed.curHp -= dmg;

        transform.Translate(Vector2.zero);
        anim.SetTrigger("Hit");

        if(ed.curHp <= 0)
        {
            Dead();
        }
    }

    //적 사망 시
    public void Dead()
    {
        isLive = false;
        anim.SetTrigger("Dead");
        transform.tag = "Untagged"; //플레이어가 태그를 기준으로 가장 가까운 적을 찾기 때문에 죽은 적을 untag하여 빨리 새로운 적을 찾게 하기 위함
        GetComponent<Collider2D>().isTrigger = true;
        GameController.instance.player.nearstTarget = null;
        GameController.instance.killCount++;
    }

    //확률에 의해 exp, hp회복, 자석 아이템 드롭
    public void DropItems()
    {
        GameObject items;
        int idx;
        int rand = Random.Range(0, 100);

        //exp
        if(rand < 82)
        {
            idx = 0;
        }
        else if (rand >= 82 && rand < 91)
        {
            idx = 1;
        }
        else if (rand >= 91 && rand < 94)
        {
            idx = 2;
        }        
        else
        {
            // hp, 자석
            if (rand % 2 == 0)
            {
                idx = 3;
            }
            else
            {
                idx = 4;
            }
        }

        items = GameController.instance.spawn.SpawnAct("item", idx);
        items.transform.position = gameObject.transform.position; // 적이 죽은 위치에 아이템 생성
    }
}
