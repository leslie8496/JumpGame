using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    
    private WallCheck wallCheck;
    
    [Header("跳跃相关")]
    [SerializeField] private float jumpAddPower;
    [SerializeField] private float fullAddPower;
    [SerializeField] private float jumpAddTime;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float xWallJumpSpeed;
    [SerializeField] private float yWallJumpSpeed;
    
    public bool wallJumping;
    private float jumpAddController;
    public AudioSource jumpSound;
    private bool isJump;
    private bool isJumping;
    
    [Header("二连跳相关")]
    public bool doubleJump;
    
    [Header("检测相关")]
    [SerializeField] private float isGroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    public bool isGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        wallCheck = GameObject.FindGameObjectWithTag("WallCheck").GetComponent<WallCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        OnJump();

        JumpAnimationController();

        IsGroundAni();
        WallJump();
    }

    IEnumerator WallJumping()
    {
        wallJumping = true;
        yield return new WaitForSeconds(0.5f);
        wallJumping = false;
    }
    private void WallJump()
    {
        if (wallCheck.inWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(-xWallJumpSpeed*transform.localScale.x,yWallJumpSpeed);
                StartCoroutine(WallJumping());
            }
        }
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
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;
            jumpAddController = 0;
            doubleJump = true;
        }

        if (doubleJump && !isGround&&Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;
            jumpAddController = 0;
            doubleJump = false;
            anim.SetTrigger("isDoubleJump");
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (isJumping)
        {
            if (jumpAddController < jumpAddTime)
            {
                rb.velocity += new Vector2(0, -Physics2D.gravity.y * Time.deltaTime * jumpAddPower);
            }
            else
            {
                isJumping = false;
            }

            jumpAddController += Time.deltaTime;
        }
        
        if (!isJumping && !isGround && rb.velocity.y <= 0) 
        {
            // 这个额外的力应该是一个向下的加速力
            rb.velocity -= new Vector2(0, -Physics2D.gravity.y * Time.deltaTime * fullAddPower);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - isGroundCheck));
    }
}