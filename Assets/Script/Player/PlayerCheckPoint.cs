using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    private PlayerDead _playerDead;
    // Start is called before the first frame update
    void Start()
    {
        _playerDead = GetComponent<PlayerDead>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            Animator pointAnim = collision.gameObject.GetComponent<Animator>();
            pointAnim.SetTrigger("isCheck");
            _playerDead.pos = new Vector2(collision.transform.position.x, collision.transform.position.y);
        }
    }
}
