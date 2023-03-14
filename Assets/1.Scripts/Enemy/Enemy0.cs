using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : Enemy
{
    void Start()
    {
        float upgrade = GameController.instance.enemyUpgrade;

        ed.speed = (float)(1.5f + (0.2 * upgrade));
        ed.damage = 1 * upgrade;
        ed.curHp = 20f * upgrade;
        ed.maxHp = ed.curHp;
    }
}
