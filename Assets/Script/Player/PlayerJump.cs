using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float isGroundCheck;

    public Rigidbody2D rd;
    private bool isJump;
    public float jumpSpeed;
    private bool isGround;

    private Animator anim;
    
   

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpSpeed = 5f;
        isGroundCheck = 1.1f;
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
        if (rd.velocity.y > 0.3f)
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
            rd.velocity = new Vector2(rd.velocity.x, jumpSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - isGroundCheck));
    }
}