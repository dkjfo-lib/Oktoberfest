using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    public float speed = 200;
    public float speedMult = .7f;
    public float speedMultInAir = .98f;
    [Space]
    public float jumpForce = 200;
    public float jumpVelCut = 2;
    public float gravity = 3;

    Rigidbody2D rb;
    GroundDetector gd;

    Vector2 input;
    public Vector2 CurrentInput => input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetector>();
        rb.gravityScale = gravity;
    }

    void FixedUpdate()
    {
        // if in jump and 'W' is released
        //if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / jumpVelCut);
        //}

        var input = CreateInput();

        if (gd.onGround)
        {
            // move x
            if (input.x != 0)
            {
                if (gd.onGround)
                {
                    var movementX = input.x * speed * Time.fixedDeltaTime;
                    rb.velocity = new Vector2(movementX, rb.velocity.y);
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x * speedMult, rb.velocity.y);
            }
            // move y
            if (input.y != 0)
            {
                var movementY = input.y * jumpForce;
                rb.velocity = new Vector2(rb.velocity.x, movementY);
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * speedMultInAir, rb.velocity.y);
        }
    }

    private Vector2 CreateInput()
    {
        input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            input -= Vector2.right;
        if (Input.GetKey(KeyCode.D))
            input += Vector2.right;
        if (Input.GetKey(KeyCode.W))
            input += Vector2.up;
        return input;
    }
}

public interface IMovement
{
    Vector2 CurrentInput { get; }
}