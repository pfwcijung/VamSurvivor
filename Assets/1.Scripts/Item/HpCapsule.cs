using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCapsule : Item
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            GameController.instance.player.curHp += (GameController.instance.player.maxHp / 10);
            Destroy(gameObject);
        }
    }
}
