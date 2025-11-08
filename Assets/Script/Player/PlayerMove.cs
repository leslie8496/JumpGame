using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rd;
    public float moveSpeed;

    public float MoveController;
    private bool isRunScript;
    private Animator anim;

    void Start()
    {
        moveSpeed = 5f;
        anim = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(moveSpeed * MoveController, rd.velocity.y);

        //是否正在跑步
        isRunScript = MoveController != 0;
        anim.SetBool("isRun", isRunScript);
        //左右方向跑
        if (rd.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (rd.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}