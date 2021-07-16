using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAP2D;

public class zombieMovement : MonoBehaviour
{
    public int hp, damage;
    public float speed = 4, attackDistance = 1, seeDistance = 10;
    bool canAttack;
    GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    SAP2DAgent agent;

    void Start()
    {
        canAttack = true;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<SAP2DAgent>();
        agent.MovementSpeed = speed;
        agent.Target = player.transform;
    }

    void Update()
    {
        if (hp <= 0) return;

        var dist = Vector2.Distance(transform.position, player.transform.position);
        //if (dist <= seeDistance && dist > attackDistance)
        //{
        //    rb.velocity = (player.transform.position - transform.position).normalized * speed;
        //}
        //else rb.velocity = Vector2.zero;

        if (dist <= attackDistance && canAttack)
        {
            Attack();
        }

        sprite.flipX = transform.position.x - player.transform.position.x > 0;
        animator.SetBool("isMoving", agent.isMoving);
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        player.GetComponent<PlayerControls>().Hit(damage);
        canAttack = false;
        agent.CanMove = false;
        if (hp > 0) Invoke("CanAttack", 2);
    }

    void CanAttack()
    {
        canAttack = true;
        agent.CanMove = true;
    }

    public void Hit(int damage)
    {
        hp -= damage;
        animator.SetTrigger("hit");
        if (hp <= 0)
        {
            agent.Target = null;
            player.GetComponent<PlayerControls>().kills++;
            rb.velocity = Vector2.zero;
            animator.SetTrigger("die");
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 15);
        }
    }
}
