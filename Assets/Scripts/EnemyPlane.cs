using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlane : MonoBehaviour
{
    public delegate void EnemyDestroyedAction();
    public static EnemyDestroyedAction OnDestroyedEnemy;

    Rigidbody2D rb;
    public Transform target;
    public GameManager gameManager;
    public GameObject explosionEffect;

    public float speed = 20;
    public float rotateSpeed = 200f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            if (OnDestroyedEnemy != null)
            {
                OnDestroyedEnemy();
            }

            GetComponent<SimpleFlashColored>().Flash(Color.white);
            Debug.Log("Enemy hit!");
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.PlaySound("Explosion");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy0") || other.gameObject.CompareTag("Enemy1") || other.gameObject.CompareTag("Enemy2") || other.gameObject.CompareTag("Enemy3"))
        {
            GetComponent<SimpleFlashColored>().Flash(Color.white);
            Debug.Log("Enemy hit Enemy!");
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.PlaySound("Explosion");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy1"))
        {
            GetComponent<SimpleFlashColored>().Flash(Color.white);
            Debug.Log("Enemy hit Enemy!");
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.PlaySound("Explosion");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy2"))
        {
            GetComponent<SimpleFlashColored>().Flash(Color.white);
            Debug.Log("Enemy hit Enemy!");
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.PlaySound("Explosion");
            Destroy(gameObject);
        }

        if ((other.gameObject.CompareTag("Enemy3")) && (other.gameObject.CompareTag("Enemy2")))
        {
            GetComponent<SimpleFlashColored>().Flash(Color.white);
            Debug.Log("Enemy hit Enemy!");
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.PlaySound("Explosion");
            Destroy(gameObject);
        }
    }
}
