using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stay = 3;

    private Animator enemyAnim;
    private Rigidbody2D enemyRigidbody2D;
    private SpriteRenderer spriteRenderer;

    private float direction = 1;
   
    private bool stayCheck = false;

    private void Awake()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stayCheck)
        {
            enemyAnim.SetBool("Run", false);
            stay -= Time.deltaTime;
            if(stay < 0)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                stayCheck = false;
                stay = 3;
            }
        }
        else
        {
            EnemyMove();
        }
    }

    private void EnemyMove()
    {
        enemyRigidbody2D.velocity = new Vector2(direction * speed, enemyRigidbody2D.velocity.y);
        enemyAnim.SetBool("Run", true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RevertMoveEnemy"))
        {
            direction *= -1;
            stayCheck = true;
        }
    }
}
