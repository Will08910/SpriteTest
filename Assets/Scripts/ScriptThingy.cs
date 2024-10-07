using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class ScriptThingy : MonoBehaviour
{
    LayerMask groundLayerMask;
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
    public GameObject Camera3;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }


        // Update is called once per frame
        void Update()
        {
            DoRayCollisionCheck();
            MoveSprite();
            Camera1.transform.position = player.position + offset;
            Camera2.transform.position = player.position + offset;
            Camera3.transform.position = player.position + offset;

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

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, 21, 0), ForceMode2D.Impulse);
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

    public void DoRayCollisionCheck()
    {
        float rayLength = 0.5f;

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.white;
        isGrounded = false;

        if (hit.collider != null)
        {
            hitColor = Color.green;
            isGrounded = true;
        }
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        
    }

}
