using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy
{
    void Start()
    {
        float upgrade = GameController.instance.enemyUpgrade;

        ed.speed = (float)(1f + (0.2 * upgrade));
        ed.damage = 4f * upgrade;
        ed.curHp = 100f * upgrade;
        ed.maxHp = ed.curHp;
    }
}
