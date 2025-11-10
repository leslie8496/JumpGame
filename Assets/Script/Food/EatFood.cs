using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    private int gameScore;
    public TextMeshProUGUI playerScoreTMP;

    void Start()
    {
        gameScore = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            gameScore++;
            playerScoreTMP.text = ":" + gameScore;
            Destroy(collision.gameObject);
        }
    }
}