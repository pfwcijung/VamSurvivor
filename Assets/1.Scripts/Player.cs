using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3f;
    public Vector3 inputVec;
    SpriteRenderer sprite;
    Animator anim;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        anim.SetTrigger("Idle");
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        inputVec.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(transform.position.x + inputVec.x, transform.position.y + inputVec.y);

        if (inputVec.x != 0 || inputVec.y != 0) 
        {
            anim.SetTrigger("Move");

            if (inputVec.x < 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;
        }
        else
        {
            anim.SetTrigger("Idle");
        }
    }
}
