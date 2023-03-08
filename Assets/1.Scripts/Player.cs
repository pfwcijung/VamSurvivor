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

    public bool isLive = true;
    public float curHp = 0f;
    public float maxHp = 0;
    public float speed = 3f;

    float delayTimeShooting = 0f;
    float delayTimeThrow = 0f;
    public float delayTimeRotate = 0f;
    float delayTimeBoom = 0f;
    float countRotate;
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

        PlayerMove();

        nearstTarget = FindNearestTarget();

        if (nearstTarget != null)
            ShootingBullet();

        if (inputVec.x != 0 || inputVec.y != 0)
            ThrowBullet();

        //회전무기 다시
        /*
        if(countRotate>0 && delayTimeRotate == 0)
        {
            for (int i = 0; i < countRotate; i++)
                RotateBullet(i);
        }
        */
        if (true)
            BoomBullet();
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
    public void PlayerMove()
    {
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
    }
    public GameObject FindNearestTarget()
    {
        var objects = GameObject.FindGameObjectsWithTag("enemy").ToList();

        if (objects.Count == 0)
            return null;

        var neareastObj = objects.OrderBy(obj => { return Vector3.Distance(transform.position, obj.transform.position); }).FirstOrDefault();

        if (Vector2.Distance(neareastObj.transform.position, transform.position) >= 7)
            return null;
        else
            return neareastObj;
    }
    public void ShootingBullet()
    {
        delayTimeShooting += Time.deltaTime;
        if (delayTimeShooting > .3f - (0.01 * GameController.instance.playerLevel))
        {
            GameObject weapon = GameController.instance.spawnWeapon.SpawnAct(0);
            weapon.transform.position = transform.position;
            delayTimeShooting = 0;
        }
    }
    public void ThrowBullet()
    {
        delayTimeThrow += Time.deltaTime;
        if (delayTimeThrow > .5f - (0.01 * GameController.instance.playerLevel))
        {
            GameObject weapon = GameController.instance.spawnWeapon.SpawnAct(1);
            weapon.transform.position = transform.position;
            delayTimeThrow = 0;
        }
    }
    public void RotateBullet(int index)
    {        
        Transform weapon = GameController.instance.spawnWeapon.SpawnAct(2).transform;

        weapon.localPosition = transform.position + new Vector3(0, 1, 10);
        weapon.localRotation = Quaternion.identity;

        Vector3 rotateVec = Vector3.forward * 360 * index / countRotate;
        weapon.Rotate(rotateVec);
        weapon.Translate(weapon.up * 1.5f, Space.World);
    }
    public void BoomBullet()
    {
        delayTimeBoom += Time.deltaTime;
        if (delayTimeBoom >= 1f)
        {
            Transform weapon = GameController.instance.spawnWeapon.SpawnAct(3).transform;
            delayTimeBoom = 0f;
        }
    }
}
