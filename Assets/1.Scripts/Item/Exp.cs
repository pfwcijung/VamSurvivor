using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Exp : Item
{
    public float exp;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            GameController.instance.playerCurEXP += exp;
            Destroy(gameObject);
        }
    }
}
