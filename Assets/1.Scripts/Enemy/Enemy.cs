using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��� ������ �����ϴ� ������
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

    //Ÿ�� : �÷��̾�, ���� �ִϸ��̼� ����
    Transform target;
    SpriteRenderer sprite;
    Animator anim;

    //�� ���� ����
    bool isLive = true;
    bool isAttack = false;

    //�������� �׾��� ��� ����
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
        //�÷��̾� ��� �� ���ڸ��� ����
        if (!GameController.instance.player.isLive)
            return;

        //�� ��� �� ����
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

        //�浹 �� 1�ʸ��� �÷��̾�� ������ ������ ��
        if (isAttack)
        {
            if (delayTime > 1f)
            {
                delayTime = 0;
                GameController.instance.player.GetDamage(ed.damage);
            }
            delayTime += Time.deltaTime;
        }

        //Ÿ��(�÷��̾�) �������� �����̱� ����
        transform.position = Vector2.MoveTowards(transform.position, target.position, ed.speed * Time.deltaTime);

        sprite.flipX = target.position.x < transform.position.x;
    }

    //�÷��̾� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameController.instance.player.isLive)
            return;

        if (collision.transform == target)
        {
            isAttack = true;
        }
    }
    //�÷��̾� ���� ����
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform == target)
        {
            isAttack = false;
        }
    }

    //�� ������ �ް� �ϱ� ����
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

    //�� ��� ��
    public void Dead()
    {
        isLive = false;
        anim.SetTrigger("Dead");
        transform.tag = "Untagged"; //�÷��̾ �±׸� �������� ���� ����� ���� ã�� ������ ���� ���� untag�Ͽ� ���� ���ο� ���� ã�� �ϱ� ����
        GetComponent<Collider2D>().isTrigger = true;
        GameController.instance.player.nearstTarget = null;
        GameController.instance.killCount++;
    }

    //Ȯ���� ���� exp, hpȸ��, �ڼ� ������ ���
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
            // hp, �ڼ�
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
        items.transform.position = gameObject.transform.position; // ���� ���� ��ġ�� ������ ����
    }
}
