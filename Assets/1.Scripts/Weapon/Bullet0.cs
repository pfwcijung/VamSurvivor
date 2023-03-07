using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0 : MonoBehaviour
{
    GameObject target;

    public float damage;
    public float speed = 10f;

    float destroyTime = 0f;

    void Start()
    {
        target = GameController.instance.player.nearstTarget;
        damage = 10f + (2 * GameController.instance.playerLevel);

        Vector2 vec = transform.position - target.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    void Update()
    {
        transform.Translate(new Vector2(0, Time.deltaTime * speed));

        destroyTime += Time.deltaTime;
        if (destroyTime >= 7f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<Enemy>().GetDamage(damage, transform);
        }
    }
}
