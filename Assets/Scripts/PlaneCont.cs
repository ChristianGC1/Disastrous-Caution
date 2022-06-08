using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneCont : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosionEffect;
    public GameManager gameManager;
    public static int speed = 10;
    public float acceleration;
    public float rotationControl;

    float MovY, MovX = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    void Update()
    {
        MovY = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Add more speed
            if (speed >= 0)
            {
                speed++;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Lower speed
            if (speed <= 100)
            {
                speed--;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * (MovX * acceleration);
        rb.AddForce(Vel);


        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if (acceleration > 0)
        {

            if (Dir > 0)
            {
                rb.rotation -= MovY * rotationControl * (rb.velocity.magnitude / speed);
            }

            else
            {
                rb.rotation += MovY * rotationControl * (rb.velocity.magnitude / speed);
            }
        }

        float thrustforce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustforce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathWall")
        {
            GetComponent<SimpleFlashColored>().Flash(Color.red);
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            rb.velocity = Vector2.zero;
            this.enabled = false;
            gameManager.GameOver();
        }
    }
}
