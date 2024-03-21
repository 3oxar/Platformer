using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private Transform attackCollider;
    [SerializeField] private LayerMask attackLayerMask;

    [SerializeField] private float radiusAttack;

    private Collider2D enemyCollider2D;
    private Animator animator;

    private float attackTime = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCollider2D = Physics2D.OverlapCircle(attackCollider.position, radiusAttack, attackLayerMask);
        if (enemyCollider2D != null)
        {
            if(attackTime <= 0)
            {
                animator.SetBool("Attack", true);
                attackTime = 2;
            }
            else
            {
                animator.SetBool("Attack", false);
                attackTime -= Time.deltaTime;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            attackTime = 0;
        }
    }
}
