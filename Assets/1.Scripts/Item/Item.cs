using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Item : MonoBehaviour
{
    protected GameObject target;

    void Start()
    {
        //�÷��̾ Ÿ������ ��� �ϱ� ����
        target = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        if (!GameController.instance.player.isLive)
            return;

        //�÷��̾�� ������ �Ÿ� ���� ������ �ڼ�ó�� ����� �ϱ� ����
        if (Vector2.Distance(target.transform.position, transform.position) <= GameController.instance.itemArea)
        {

            Vector2 vec = transform.position - target.transform.position;
            vec = vec * Time.deltaTime * GameController.instance.player.speed * 2f; //�÷��̾� �ӵ��� �� �踦 �Ͽ� �������� ������� �ʰ� ���� ����ٴϴ°� ������ ����

            transform.Translate(new Vector2(-vec.x, -vec.y));
        }
    }
}
