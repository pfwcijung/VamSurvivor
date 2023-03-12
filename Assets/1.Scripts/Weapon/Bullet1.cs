using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : Weapon
{
    //던지기 무기
    void Start()
    {
        Vector2 vec = GameController.instance.player.inputVec;

        //플레이어가 바라보는 방향으로 던지기 무기를 돌리기 위함
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        //무기 이름, 무기 데미지, 무기 이동 속도
        GetComponent<Weapon>().SetWeaponInfo("ThrowBullet", 20 + GameController.instance.ThrowDamage, 0.05f);
    }
}
