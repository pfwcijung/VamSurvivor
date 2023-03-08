using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : Item
{
    public float exp;

    public void SetExp(float exp)
    {
        this.exp = exp;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            GameController.instance.playerCurEXP += exp;
            Destroy(gameObject);
        }
    }
}
