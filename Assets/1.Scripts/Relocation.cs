using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relocation : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("area"))
            return;

        Vector3 playerPos = GameController.instance.player.transform.position;
        Vector3 playerDir = GameController.instance.player.inputVec;
        Vector3 tilemapPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - tilemapPos.x);
        float diffY = Mathf.Abs(playerPos.y - tilemapPos.y);

        float dirX = playerDir.x > 0 ? 1 : -1;
        float dirY = playerDir.y > 0 ? 1 : -1;
        
        if (diffX > diffY)
            transform.Translate(Vector3.right * dirX * 40);
        else if (diffY > diffX) 
            transform.Translate(Vector3.up * dirY * 40);
    }
}
