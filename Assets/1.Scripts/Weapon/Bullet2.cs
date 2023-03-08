using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : Weapon
{ 
    void Start()
    {
        GetComponent<Weapon>().SetWeaponInfo("RotateBullet", 10, 100);
    }
}
