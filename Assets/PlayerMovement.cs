using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    private enum MovementState { idle, running, falling, jumping }

    private MovementState state = MovementState.idle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
        }

        UpdateAnimation(dirX);
    }

    private void UpdateAnimation(float dirX)
    {

        // If player is on the move
        if (dirX != 0f)
        {
            state = MovementState.running;
            // if player going left
            if (dirX < 0f)
            {
                sprite.flipX = false;
            }
            // if player going right
            if (dirX > 0f)
            {
                sprite.flipX = true;

            } 
        } 
        else
        {
            state = MovementState.idle;
        }

       

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } 
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state);
     
    }

    private bool isGrounded()
    {
        Vector2 boxCastOrigin = coll.bounds.center;
        float yOffset = 0.2f; // Adjust this value as needed
        boxCastOrigin.y -= yOffset;
        Physics2D.BoxCast(boxCastOrigin, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);

        return state != MovementState.falling && state != MovementState.jumping;
    }
}
