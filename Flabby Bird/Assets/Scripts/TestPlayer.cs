using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private bool isJumping;
    private bool doubleJump;
    private bool wasGrounded;
    private int cholLvl;
    private int life;

    private Animator anim;

    private Rigidbody2D body;
    private CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        doubleJump = false;
        wasGrounded = false;
        cholLvl = 0;
        life = 3;

        body = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            anim.SetBool("isJumping", isJumping);
        }
        else if (Input.GetButtonDown("Jump") && doubleJump)
        {
            isJumping = true;
            doubleJump = false;
            anim.SetBool("isJumping", isJumping);
        }

        if (!wasGrounded && IsGrounded())
            OnLanding();

        wasGrounded = IsGrounded();
    }

    private void FixedUpdate()
    {
        if(isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isJumping = false;
            anim.SetBool("isJumping", true);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(circle.bounds.center, circle.radius + 0.3f, LayerMask.GetMask("Ground"));
    }

    public void OnLanding()
    {
        doubleJump = true;
        anim.SetBool("isJumping", false);
    }

    public void PlayerCollide(string tag)
    {
        if (tag == "Bad")
        {
            if(cholLvl < 2)
                cholLvl = cholLvl + 1;
        }
        else if (tag == "Good")
        {
            if (cholLvl == 0)
            {
                life = life + 1;
            }
            else
            {
                cholLvl = cholLvl - 1;
            }
        }

        else if (tag == "Obstacle")
        {
            anim.SetBool("isHit", true);
            if (life == 1)
            {
                life = life - 1;
                Debug.Log("Dead");
                SceneManager.LoadScene("EndGame");
            }
            else
            {
                life = life - 1;
                cholLvl = 0;
            }
        }
    }

    public int GetLife()
    {
        return life;
    }
    
    public int GetChol()
    {
        return cholLvl;
    }
}
