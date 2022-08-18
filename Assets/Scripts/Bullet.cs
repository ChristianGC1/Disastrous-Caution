using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        Vector2 dir = GetComponent<Rigidbody2D>().velocity;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("Bullet Destroyed");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy0")
        {
            Debug.Log("Bullet hit Enemy");
            PlaneCont.score += 1;
        }
        if (collision.gameObject.tag == "Enemy1")
        {
            Debug.Log("Bullet hit Enemy");
            PlaneCont.score += 2;
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            Debug.Log("Bullet hit Enemy");
            PlaneCont.score += 3;
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            Debug.Log("Bullet hit Enemy");
            PlaneCont.score += 5;
        }
    }
}