using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlying : MonoBehaviour
{
    public int damage;
    public float speed = 10;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collidable"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<zombieMovement>().Hit(damage);
            Destroy(gameObject);
        }
    }

}
