using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet0 : Weapon
{
    //총알 무기
    void Start()
    {
        //플레이어 스크립트에서 가장 가까운 타겟을 가져오게 함
        GameObject target = GameController.instance.player.nearstTarget;

        //타겟 방향으로 총알을 돌리기 위함
        Vector2 vec = transform.position - target.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        //무기 이름, 무기 데미지, 무기 이동 속도
        GetComponent<Weapon>().SetWeaponInfo("ShootingBullet", GameController.instance.ShootingDamage, 0.05f);
    }
}
