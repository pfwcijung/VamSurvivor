using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet3 : Weapon
{
    void Start()
    {
        Vector3 myPos = GameController.instance.player.transform.position;

        float randPosX = Random.Range(myPos.x - 5, myPos.x + 5);
        float randPosY = Random.Range(myPos.y - 5, myPos.y + 5);

        transform.position = new Vector3(randPosX, randPosY, 0);
        GetComponent<Weapon>().SetWeaponInfo("BoomBullet", 50 + GameController.instance.BoomDamage, 5);
    }
}
