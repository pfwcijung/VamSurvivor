using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //카메라가 플레이어를 따라 오기 하기 위함
    void Update()
    {
        transform.position =
            new Vector3(
            GameController.instance.player.transform.position.x,
            GameController.instance.player.transform.position.y,
            -10f);
    }
}
