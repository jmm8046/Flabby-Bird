using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private bool isJumping;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;

            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }

        if(IsGrounded())
        {
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down * 1.3f);
    }
}
