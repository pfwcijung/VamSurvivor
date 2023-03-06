using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

        nearstTarget = FindNearestTarget();

        if (nearstTarget == null)
            return;
        else
        {
            delayTime += Time.deltaTime;
            if (delayTime > .3f - (0.01 * GameController.instance.playerLevel))
            {
                GameObject weapon = GameController.instance.weapon.SpawnWeapon(0);
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

    public GameObject FindNearestTarget()
    {
        var objects = GameObject.FindGameObjectsWithTag("enemy").ToList();

        var neareastObj = objects.OrderBy(obj => { return Vector3.Distance(transform.position, obj.transform.position); }).FirstOrDefault();

        if (Vector2.Distance(neareastObj.transform.position, transform.position) >= 7)
            return null;
        else
            return neareastObj;
    }
}
