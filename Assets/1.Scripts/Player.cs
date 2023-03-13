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

    //�÷��̾� ����
    public bool isLive = true;
    public float curHp = 0;
    public float maxHp = 0;
    public float speed = 0;

    //���� ����� ������
    float delayTimeShooting = 0f;
    float delayTimeThrow = 0f;
    float delayTimeBoom = 0f;
    void Start()
    {
        //�÷��̾� �ִϸ��̼� �⺻ ����
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");

        //�÷��̾� ���� ����
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

        //����� Ÿ�� �ְ�, �Ѿ� ���Ⱑ Ȱ��ȭ ���� �� �Ѿ� ���Ⱑ ����
        if (nearstTarget != null && GameController.instance.ShootingActive)
            ShootingBullet();

        //�÷��̾ �����̸�, ������ ���Ⱑ Ȱ��ȭ ���� �� ������ ���� ����
        if ((inputVec.x != 0 || inputVec.y != 0) && GameController.instance.ThrowActive)
            ThrowBullet();

        //��ź ���Ⱑ Ȱ��ȭ ���� �� ��ź ���� ����
        if (GameController.instance.BoomActive)
            BoomBullet();
    }

    public void GetDamage(float dmg)
    {
        if (!isLive)
            return;

        curHp -= dmg;

        GameController.instance.CameraObj.GetComponent<AudioController>().PlayBGM("Hit");

        //�׾��� ��� �ִϸ��̼� �� �÷��̾�, �� �������� ���߰� �ϱ� ����
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
        //enemy �±��� ��� ���� ����Ʈ ȭ
        var objects = GameObject.FindGameObjectsWithTag("enemy").ToList();

        //����Ʈ�� ������ null ��ȯ
        if (objects.Count == 0)
            return null;

        //�÷��̾�� �� ���̿� �Ÿ��� �������� �� ó���� �ִ� ���� ������ ���� ��
        var neareastObj = objects.OrderBy(obj => { return Vector3.Distance(transform.position, obj.transform.position); }).FirstOrDefault();

        //���� ����� ���� �� ���� ������ ���� ��� null, ���� ��� �� ���� Ÿ������ �ϱ� ���� ���� ��ȯ
        if (Vector2.Distance(neareastObj.transform.position, transform.position) >= 7)
            return null;
        else
            return neareastObj;
    }
    //�Ѿ� ���� ����
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
    //������ ���� ����
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
    //��ź ���� ����
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
