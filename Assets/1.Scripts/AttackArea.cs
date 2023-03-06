using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<GameObject> InAttArea;

    public float distance = 100;

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, GameController.instance.player.transform.position) <= 4) 
        {
            InAttArea.Add(gameObject);
        }

        //if (InAttArea == null)
            //return;
        //else
        {
            foreach (var item in InAttArea)
            {
                float itemDis = Vector3.Distance(item.transform.position, GameController.instance.player.transform.position);

                if (itemDis < distance)
                {
                    distance = itemDis;
                    GameController.instance.player.nearstTarget = item.gameObject;
                }
            }
        }
    }

    public void DestroyOBJ(GameObject gameObject)
    {
        //foreach(var item in InAttArea)
        //{
        //if (item.gameObject == gameObject)
                InAttArea.Remove(gameObject);
        //}
    }   
}
