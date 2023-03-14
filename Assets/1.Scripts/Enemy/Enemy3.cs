using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    void Start()
    {
        float upgrade = GameController.instance.enemyUpgrade;

        ed.speed = (float)(1.5f + (0.2 * upgrade));
        ed.damage = 8f * upgrade;
        ed.curHp = 35f * upgrade;
        ed.maxHp = ed.curHp;
    }
}
