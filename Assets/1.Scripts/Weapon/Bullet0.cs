using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0 : MonoBehaviour
{
    float damage = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "enemy")
        {
            GetComponent<Enemy>().GetDamage(damage);
        }
    }
}
