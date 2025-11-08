using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private enum Anim
    {
        idle,run,jump,fall
    }

    private Anim stat;
    private Animator anim;
    private PlayerMove playerMove;
    private PlayerJump playerJump;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerJump = GetComponent<PlayerJump>();
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.MoveController!=0)
        {
            stat = Anim.run;
        }
        else
        {
            stat = Anim.idle;
        }

        if (playerJump.rb.velocity.y > 0.3f)
        {
            stat = Anim.jump;
        }

        if (playerJump.rb.velocity.y < -0.3f)
        {
            stat = Anim.fall;
        }
        anim.SetInteger("states",(int)stat);
    }
}
