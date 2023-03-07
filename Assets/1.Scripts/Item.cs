using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float exp;
    GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if (!GameController.instance.player.isLive)
            return;

        if (Vector2.Distance(target.transform.position, transform.position) <= 2)
        {

            Vector2 vec = transform.position - target.transform.position;
            vec = vec * Time.deltaTime * GameController.instance.player.speed;

            transform.Translate(new Vector2(-vec.x, -vec.y));
        }
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