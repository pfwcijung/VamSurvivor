using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Relocation : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("area"))
            return;

        Vector3 playerPos = GameController.instance.player.transform.position;
        Vector3 tilemapPos = transform.position;

        float dirX = playerPos.x - tilemapPos.x;
        float dirY = playerPos.y - tilemapPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        if (diffX > diffY)
            transform.Translate(Vector3.right * dirX * 40);
        else if (diffY > diffX) 
            transform.Translate(Vector3.up * dirY * 40);
        else
        {
            transform.Translate(Vector3.right * dirX * 40);
            transform.Translate(Vector3.up * dirY * 40);
        }
    }
}
