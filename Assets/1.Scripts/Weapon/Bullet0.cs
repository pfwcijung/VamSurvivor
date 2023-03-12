using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet0 : Weapon
{
    //�Ѿ� ����
    void Start()
    {
        //�÷��̾� ��ũ��Ʈ���� ���� ����� Ÿ���� �������� ��
        GameObject target = GameController.instance.player.nearstTarget;

        //Ÿ�� �������� �Ѿ��� ������ ����
        Vector2 vec = transform.position - target.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        //���� �̸�, ���� ������, ���� �̵� �ӵ�
        GetComponent<Weapon>().SetWeaponInfo("ShootingBullet", GameController.instance.ShootingDamage, 0.05f);
    }
}
