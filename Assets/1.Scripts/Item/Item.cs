using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Item : MonoBehaviour
{
    protected GameObject target;

    void Start()
    {
        //플레이어를 타겟으로 잡게 하기 위함
        target = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        if (!GameController.instance.player.isLive)
            return;

        //플레이어와 일정한 거리 내에 있으면 자석처럼 따라게 하기 위함
        if (Vector2.Distance(target.transform.position, transform.position) <= GameController.instance.itemArea)
        {

            Vector2 vec = transform.position - target.transform.position;
            vec = vec * Time.deltaTime * GameController.instance.player.speed * 2f; //플레이어 속도의 두 배를 하여 아이템이 습득되지 않고 영영 따라다니는거 방지를 위함

            transform.Translate(new Vector2(-vec.x, -vec.y));
        }
    }
}
