using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Item : MonoBehaviour
{
    protected GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        if (!GameController.instance.player.isLive)
            return;

        if (Vector2.Distance(target.transform.position, transform.position) <= GameController.instance.itemArea)
        {

            Vector2 vec = transform.position - target.transform.position;
            vec = vec * Time.deltaTime * GameController.instance.player.speed * 2f;

            transform.Translate(new Vector2(-vec.x, -vec.y));
        }
    }
    /*
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

        if (Vector2.Distance(target.transform.position, transform.position) <= GameController.instance.itemArea)
        {

            Vector2 vec = transform.position - target.transform.position;
            vec = vec * Time.deltaTime * GameController.instance.player.speed * 2f;

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
    */
}
