using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController e = collision.collider.GetComponent<EnemyController>();
        Debug.Log("Entered OnCollisionEnter2D");
        Debug.Log(collision.collider.name);
        if (e != null)
        {
            Debug.Log("Fix triggered");
            e.Fix();
        }

        Destroy(gameObject);
    }
}