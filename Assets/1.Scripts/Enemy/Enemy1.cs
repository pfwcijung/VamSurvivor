using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    void Start()
    {
        float upgrade = GameController.instance.enemyUpgrade;

        ed.speed = (float)(2f + (0.2 * upgrade));
        ed.damage = 2f * upgrade;
        ed.curHp = 50f * upgrade;
        ed.maxHp = ed.curHp;
    }
}
