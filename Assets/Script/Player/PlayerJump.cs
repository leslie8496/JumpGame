using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float isGroundCheck;

    public Rigidbody2D rb;
    private bool isJump;
    public float jumpSpeed;
    private bool isGround;

    private Animator anim;
    
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpSpeed = 5f;
        isGroundCheck = 1.1f;
        GroundLayer.value = 5;
    }

    // Update is called once per frame
    void Update()
    {
        OnJump();

        JumpAnimationController();

        IsGroundAni();
    }

    private void IsGroundAni()
    {
        //是否在地面
        isGround = Physics2D.Raycast(transform.position, Vector2.down, isGroundCheck, GroundLayer);
        anim.SetBool("isGround", isGround);
    }

    private void JumpAnimationController()
    {
        //是否跳跃
        if (rb.velocity.y > 0.3f)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }

        anim.SetBool("isJump", isJump);
    }

    private void OnJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - isGroundCheck));
    }
}