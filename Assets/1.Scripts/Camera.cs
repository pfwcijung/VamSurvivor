using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position =
            new Vector3(
            GameController.instance.player.transform.position.x,
            GameController.instance.player.transform.position.y,
            -10f);
    }
}
