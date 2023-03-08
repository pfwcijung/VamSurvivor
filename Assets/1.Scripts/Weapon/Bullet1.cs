using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : Weapon
{
    void Start()
    {
        Vector2 vec = GameController.instance.player.inputVec;

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        GetComponent<Weapon>().SetWeaponInfo("ThrowBullet", 10, 3);
    }
}
