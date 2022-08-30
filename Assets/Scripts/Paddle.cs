using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public string paddleName;

    Rigidbody2D rb;

    public float hareketHizi = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HareketFNC();
    }

    void HareketFNC()
    {
        float moveY = 0f;

        if(paddleName=="leftPaddle")
        {
            moveY = Input.GetAxis("LeftPaddle");
        } else if(paddleName=="rightPaddle")
        {
            moveY = Input.GetAxis("RightPaddle");
        }

        Vector2 hiz = rb.velocity;

        hiz.y = moveY * hareketHizi;

        rb.velocity = hiz;
    }
}
