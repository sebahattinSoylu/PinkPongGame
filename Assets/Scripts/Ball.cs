using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float hareketHizi=4f;

    [SerializeField]
    float maxBaslangicAngle = 0.6f;

    float hizArtisMiktari = 1.01f;

    public ParticleSystem particleEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
    }

    void HareketFNC()
    {
        YaymayiGerceklestir(50);
        float rastgeleDeger = Random.value;

        Vector2 direction=Vector2.zero;


       

        if(rastgeleDeger>.5f)
        {
            direction = Vector2.left;
        } else
        {
            direction = Vector2.right;
        }

        direction.y = Random.Range(-maxBaslangicAngle, maxBaslangicAngle);

        rb.velocity = direction*hareketHizi;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Paddle"))
        {
            rb.velocity *= hizArtisMiktari;
            YaymayiGerceklestir(20);
        } else if(other.gameObject.CompareTag("upDownWall"))
        {
            YaymayiGerceklestir(35);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("leftWall"))
        {
            GameManager.instance.LeftPuanArttir();
            ResetPosition();
        } else if(other.CompareTag("rightWall"))
        {
            GameManager.instance.RightPuanArttir();
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.localPosition = Vector2.zero;

        HareketFNC();
    }

    void YaymayiGerceklestir(int yaymaAdeti)
    {
        particleEffect.Emit(yaymaAdeti);
    }
}
