using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    GameObject target;

    [SerializeField]
    public string weaponType;
    [SerializeField]
    public float damage;
    [SerializeField]
    public float speed;

    float destroyTime = 0f;

    void Start()
    {

    }

    void Update()
    {
        switch (weaponType)
        {
            case "ShootingBullet":
                {
                    transform.Translate(new Vector2(0, Time.deltaTime * speed));

                    destroyTime += Time.deltaTime;
                    if (destroyTime >= 7f)
                        Destroy(gameObject);
                    break;
                }
            case "ThrowBullet":
                {
                    transform.Translate(Vector2.up);
                    destroyTime += Time.deltaTime;
                    if (destroyTime >= 7f)
                        Destroy(gameObject);
                    break;
                }
            default:
                break;
        }
    }

    public void SetWeaponInfo(string weaponType, float damage, float speed)
    {
        this.weaponType = weaponType;
        this.damage = damage;
        this.speed = speed;
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
