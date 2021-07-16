using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public int hp = 25, maxHP, kills;
    public float speed = 5;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        kills = 0;
        hp = maxHP;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Hit(int damage)
    {
        hp -= damage;
        animator.SetTrigger("hit");
        CancelInvoke();
        if (hp <= 0)
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("die");
            Destroy(GameObject.FindGameObjectWithTag("gun"));
        }
        else InvokeRepeating("Regeneration", 5, 1);
    }

    void Regeneration()
    {
        if (hp < maxHP) hp++;
    }

    void Update()
    {
        if (hp <= 0) return;

        int x = 0, y = 0;
        var rotation = transform.eulerAngles;

        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
            transform.eulerAngles = new Vector3(rotation.x, 0, rotation.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
            transform.eulerAngles = new Vector3(rotation.x, 180, rotation.z);
        }

        if (Input.GetKey(KeyCode.W)) y = 1;
        if (Input.GetKey(KeyCode.S)) y = -1;

        rb.velocity = new Vector2(x, y).normalized * speed;
    }
}
