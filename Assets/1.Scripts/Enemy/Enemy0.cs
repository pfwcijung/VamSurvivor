using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : Enemy
{
    void Start()
    {
        ed.speed = 1.5f;
        ed.damage = 1;
        ed.curHp = 20f;
        ed.maxHp = ed.curHp;
    }
}
