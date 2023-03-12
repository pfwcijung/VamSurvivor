using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : Weapon
{
    //������ ����
    void Start()
    {
        Vector2 vec = GameController.instance.player.inputVec;

        //�÷��̾ �ٶ󺸴� �������� ������ ���⸦ ������ ����
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        //���� �̸�, ���� ������, ���� �̵� �ӵ�
        GetComponent<Weapon>().SetWeaponInfo("ThrowBullet", 20 + GameController.instance.ThrowDamage, 0.05f);
    }
}
