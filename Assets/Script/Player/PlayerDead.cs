using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traps"))
        {
            
            anim.SetTrigger("isDead");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    public void Revive()
    {
        transform.position = pos;
    }
    public void Revive2()
    {
        Debug.Log("Revive 2");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
