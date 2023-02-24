using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    void Start()
    {
        ed.speed = 2f;
        ed.damage = 2f;
        ed.curHp = 50f;
        ed.maxHp = ed.curHp;
    }
}
