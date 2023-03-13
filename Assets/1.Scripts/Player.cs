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

    //플레이어 스탯
    public bool isLive = true;
    public float curHp = 0;
    public float maxHp = 0;
    public float speed = 0;

    //무기 재생성 딜레이
    float delayTimeShooting = 0f;
    float delayTimeThrow = 0f;
    float delayTimeBoom = 0f;
    void Start()
    {
        //플레이어 애니메이션 기본 설정
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");

        //플레이어 스탯 설정
        maxHp = curHp = GameController.instance.setMaxHp;
        speed = GameController.instance.setSpeed;
    }

    void Update()
    {
        if (!isLive)
            return;

        if (curHp >= maxHp)
            curHp = maxHp;

        PlayerMove();

        nearstTarget = FindNearestTarget();

        //가까운 타겟 있고, 총알 무기가 활성화 했을 때 총알 무기가 생성
        if (nearstTarget != null && GameController.instance.ShootingActive)
            ShootingBullet();

        //플레이어가 움직이며, 던지기 무기가 활성화 했을 때 던지기 무기 생성
        if ((inputVec.x != 0 || inputVec.y != 0) && GameController.instance.ThrowActive)
            ThrowBullet();

        //폭탄 무기가 활성화 했을 때 폭탄 무기 생성
        if (GameController.instance.BoomActive)
            BoomBullet();
    }

    public void GetDamage(float dmg)
    {
        if (!isLive)
            return;

        curHp -= dmg;

        GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Hit");

        //죽었을 경우 애니메이션 및 플레이어, 적 움직임을 멈추게 하기 위함
        if (curHp <= 0)
        {
            isLive = false;
            anim.SetTrigger("Dead");
            transform.tag = "Untagged";
        }

        GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Base");
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
        //enemy 태그의 모든 적을 리스트 화
        var objects = GameObject.FindGameObjectsWithTag("enemy").ToList();

        //리스트에 없으면 null 반환
        if (objects.Count == 0)
            return null;

        //플레이어와 적 사이에 거리를 기준으로 맨 처음에 있는 값을 가지고 오게 함
        var neareastObj = objects.OrderBy(obj => { return Vector3.Distance(transform.position, obj.transform.position); }).FirstOrDefault();

        //가장 가까운 적이 내 공격 범위에 없을 경우 null, 있을 경우 그 적을 타겟으로 하기 위해 값을 반환
        if (Vector2.Distance(neareastObj.transform.position, transform.position) >= 7)
            return null;
        else
            return neareastObj;
    }
    //총알 무기 생성
    public void ShootingBullet()
    {
        delayTimeShooting += Time.deltaTime;
        if (delayTimeShooting > GameController.instance.ShootingDelay)
        {
            GameObject weapon = GameController.instance.spawn.SpawnAct("weapon", 0);
            weapon.transform.position = transform.position;
            delayTimeShooting = 0;
        }
    }
    //던지기 무기 생성
    public void ThrowBullet()
    {
        delayTimeThrow += Time.deltaTime;
        if (delayTimeThrow > GameController.instance.ThrowDelay)
        {
            GameObject weapon = GameController.instance.spawn.SpawnAct("weapon", 1);
            weapon.transform.position = transform.position;
            delayTimeThrow = 0;
        }
    }
    //폭탄 무기 생성
    public void BoomBullet()
    {
        delayTimeBoom += Time.deltaTime;
        if (delayTimeBoom >= 2f)
        {
            Transform weapon = GameController.instance.spawn.SpawnAct("weapon", 2).transform;
            delayTimeBoom = 0f;
        }
    }
}
