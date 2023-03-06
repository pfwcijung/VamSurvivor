using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    void Start()
    {
        float upgrade = GameController.instance.enemyUpgrade;

        ed.speed = (float)(2.5f + (0.2 * upgrade));
        ed.damage = 3f * upgrade;
        ed.curHp = 30f * upgrade;
        ed.maxHp = ed.curHp;
        ed.exp = 20f * upgrade;
    }
}
