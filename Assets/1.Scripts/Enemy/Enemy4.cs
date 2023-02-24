using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy
{
    void Start()
    {
        ed.speed = 1f;
        ed.damage = 4f;
        ed.curHp = 100f;
        ed.maxHp = ed.curHp;
    }
}
