using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private bool isJumping;

    private Rigidbody2D body;
    private CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;

        body = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if(isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(circle.bounds.center, circle.radius + 0.3f, LayerMask.GetMask("Ground"));
    }
}
