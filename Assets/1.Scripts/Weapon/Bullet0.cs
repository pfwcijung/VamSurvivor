using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet0 : Weapon
{
    void Start()
    {
        GameObject target = GameController.instance.player.nearstTarget;

        Vector2 vec = transform.position - target.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        GetComponent<Weapon>().SetWeaponInfo("ShootingBullet", 10 + GameController.instance.ShootingDamage, 5);
    }
}
