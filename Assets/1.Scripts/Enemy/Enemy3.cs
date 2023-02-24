using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    void Start()
    {
        ed.speed = 1.5f;
        ed.damage = 8f;
        ed.curHp = 35f;
        ed.maxHp = ed.curHp;
    }
}
