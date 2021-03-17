using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpedd = 2;
    public float jumpSpedd = 3;

    Rigidbody2D rb20;

    public bool betterJump = false;
    public float fallMultiplayer = 0.5f;
    public float lowJumpMultiplayer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        rb20 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb20.velocity = new Vector2(runSpedd, rb20.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        } 
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb20.velocity = new Vector2(-runSpedd, rb20.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        } 
        else
        {
            rb20.velocity = new Vector2(0, rb20.velocity.y);
            animator.SetBool("Run", false);
        }

        if(Input.GetKey("space") && CheckGround.isGround)
        {
            rb20.velocity = new Vector2(rb20.velocity.x, jumpSpedd);
        }

        if(CheckGround.isGround == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if(CheckGround.isGround == true)
        {
            animator.SetBool("Jump", false);
        }

        if(betterJump)
        {
            if (rb20.velocity.y < 0)
            {
                rb20.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;
            }

            if (rb20.velocity.y > 0 && Input.GetKey("space"))
            {
                rb20.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
                

      
        }
    }
}
