using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public float moveSpeed;

    public float MoveController;
    private bool isRunScript;
    private Animator anim;

    void Start()
    {
        moveSpeed = 5f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        XMove();
        Run4Move();
        AnimatorlController();
    }

    private void AnimatorlController()
    {
        //是否正在跑步
        isRunScript = MoveController != 0;
        anim.SetBool("isRun", isRunScript);
        
    }

    private void Run4Move()
    {
        //左右方向跑
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void XMove()
    {
        MoveController = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * MoveController, rb.velocity.y);
    }
}