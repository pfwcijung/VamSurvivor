using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            GameController.instance.magnetActive = true;
            Destroy(gameObject);
        }
    }
}
