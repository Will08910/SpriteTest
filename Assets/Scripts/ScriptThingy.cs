using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class ScriptThingy : MonoBehaviour
{
    HelperScript helper;
    public Animator anim;
    private float Move;
    public int speed = 10;
    public bool isFacingRight;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Transform player;
    private Vector3 offset = new Vector3(0,10,-10);
    public GameObject Camera1;
    public GameObject Camera2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
    }


        // Update is called once per frame
        void Update()
        {
            MoveSprite();
            Camera1.transform.position = player.position + offset;
            Camera2.transform.position = player.position + offset;

            helper.SayTheThing();    // this will execute the method in HelperScript.cs
        }
    

    void MoveSprite()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetKey("left") == true)
        {
            rb.velocity = new Vector2(speed * -1f, rb.velocity.y);
            sr.flipX = true;
        }

        if (Input.GetKey("right") == true)
        {
            rb.velocity = new Vector2(speed * 1f, rb.velocity.y);
            sr.flipX = false;
        }

        if (Input.GetKeyDown("space") && anim.GetBool("isJumping") == false)
        {
            rb.AddForce(new Vector3(0, 15, 0), ForceMode2D.Impulse);
        }


        if (Move >= 0.1f  || Move <= -0.1f)
        {
            anim.SetBool("Moving", true); 
        }
        else
        {
            anim.SetBool("Moving", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", true);
        }
    }

}
