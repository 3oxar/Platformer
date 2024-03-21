using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Health))]
public class Attack : MonoBehaviour
{
    [SerializeField] private Transform attackCollider;
    [SerializeField] private LayerMask attackLayerMask;

    [SerializeField] private float radiusAttack;
    [SerializeField] private float damage;

    private Collider2D enemyCollider2D;
  
    private float attackside;

    public void Attacked()
    {
        enemyCollider2D = Physics2D.OverlapCircle(attackCollider.position, radiusAttack, attackLayerMask);
        if(enemyCollider2D != null) 
            enemyCollider2D.GetComponent<Health>().DamageChatacter(damage);
    }

    /// <summary>
    /// Определяет где центр удара от которого рисуем круг радиуса атаки 
    /// </summary>
    /// <param name="inputKey">принимает нажатие клавиши для перемещения центра удара</param>
    public void AttackSide(float inputKey)
    {
        attackside = inputKey;

        if(attackside > 0)
            attackCollider.localPosition = new Vector2(0.2f, 0.2f);
        else if(attackside < 0)
            attackCollider.localPosition = new Vector2(-0.2f, 0.2f);
    }

    /// <summary>
    /// рисуем круг что на сцене что бы видить радиус атаки
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackCollider.position, radiusAttack);
    }
}
