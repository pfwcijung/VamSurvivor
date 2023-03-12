using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    //무기 정보 얻기 위함
    [SerializeField]
    public string weaponType;
    [SerializeField]
    public float damage;
    [SerializeField]
    public float speed;

    //폭탄 무기 이미지
    public Image timerImage;

    //총알이 무한으로 날라가는 것 방지
    float destroyTime = 0f;

    void Start()
    {
        timerImage.fillAmount = 0f;
    }

    void Update()
    {
        //무기 이름에 따라 무기를 생성
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

                    //폭탄 주변의 원이 꽉 차야 폭탄이 터지도록 만듬
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
    //무기 정보를 얻는 용도
    public void SetWeaponInfo(string weaponType, float damage, float speed)
    {
        this.weaponType = weaponType;
        this.damage = damage;
        this.speed = speed;
    }
    //적과 충돌하면 적에게 데미지를 주며 무기 삭제
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<Enemy>().GetDamage(damage);

            Destroy(gameObject);
        }
    }
}
