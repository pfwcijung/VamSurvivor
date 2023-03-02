using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 inputVec;
    public GameObject nearstTarget;

    SpriteRenderer sprite;
    Animator anim;

    public float curHp = 0f;
    public float maxHp = 0;
    public bool isLive = true;

    float speed = 3f;
    float delayTime = 0f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");

        maxHp = curHp = 100f;
    }

    void Update()
    {
        if (!isLive)
            return;

        inputVec.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        inputVec.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(transform.position.x + inputVec.x, transform.position.y + inputVec.y);

        if (inputVec.x != 0 || inputVec.y != 0) 
        {
            anim.SetTrigger("Move");

            if (inputVec.x <= 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;
        }
        else
        {
            anim.SetTrigger("Idle");
        }

        if (!nearstTarget)
            return;
        else
        {
            delayTime += Time.deltaTime;
            if (delayTime > .3f)
            {
                GameObject weapon = GameController.instance.spawnEnemy.SpawnWeapon(0);
                weapon.transform.position = transform.position;
                delayTime = 0;
            }
        }
    }

    public void GetDamage(float dmg)
    {
        if (!isLive)
            return;

        curHp -= dmg;

        if(curHp <= 0)
        {
            isLive = false;
            anim.SetTrigger("Dead");
            transform.tag = "Untagged";
        }
    }
}
