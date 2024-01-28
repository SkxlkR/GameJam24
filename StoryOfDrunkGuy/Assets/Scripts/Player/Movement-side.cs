using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovementSide : MonoBehaviour
{
    [SerializeField] AudioSource yell;
    [SerializeField] float speed;
    private Rigidbody2D body;
    private Animator anim;

    bool isMove = false;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    private void Update()
    {
        Time.timeScale = 1f;
        float kretnjaX = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(kretnjaX * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            isMove = true;
            anim.SetInteger("anim", 1);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isMove = true;
            anim.SetInteger("anim", 1);
        }
        else if (isMove == false)
        {
            anim.SetInteger("anim", 0);
        }


        if (gameObject.transform.position.y > 0)
        {
            yell.Play();
        }
        isMove = false;
    }
}
