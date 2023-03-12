using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    //���� ���� ��� ����
    [SerializeField]
    public string weaponType;
    [SerializeField]
    public float damage;
    [SerializeField]
    public float speed;

    //��ź ���� �̹���
    public Image timerImage;

    //�Ѿ��� �������� ���󰡴� �� ����
    float destroyTime = 0f;

    void Start()
    {
        timerImage.fillAmount = 0f;
    }

    void Update()
    {
        //���� �̸��� ���� ���⸦ ����
        switch (weaponType)
        {
            case "ShootingBullet":
                {
                    destroyTime += Time.deltaTime;
                    transform.Translate(Vector2.up * speed);

                    if (destroyTime >= 7f)
                        Destroy(gameObject);
                    break;
                }
            case "ThrowBullet":
                {
                    destroyTime += Time.deltaTime;
                    transform.Translate(Vector2.up * speed);

                    if (destroyTime >= 7f)
                        Destroy(gameObject);
                    break;
                }
            case "BoomBullet":
                {
                    destroyTime += Time.deltaTime;
                    timerImage.fillAmount = destroyTime / 2f;

                    //��ź �ֺ��� ���� �� ���� ��ź�� �������� ����
                    if (timerImage.fillAmount >= 1)
                    {
                        GetComponent<CircleCollider2D>().enabled = true;
                    }
                    
                    if (destroyTime > 2.2f)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
            default:
                break;
        }
    }
    //���� ������ ��� �뵵
    public void SetWeaponInfo(string weaponType, float damage, float speed)
    {
        this.weaponType = weaponType;
        this.damage = damage;
        this.speed = speed;
    }
    //���� �浹�ϸ� ������ �������� �ָ� ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<Enemy>().GetDamage(damage);

            Destroy(gameObject);
        }
    }
}
