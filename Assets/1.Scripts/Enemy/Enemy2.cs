using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    void Start()
    {
        ed.speed = 2.5f;
        ed.damage = 3f;
        ed.curHp = 30f;
        ed.maxHp = ed.curHp;
    }
}
