using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationPlayer))]
public class Health : MonoBehaviour
{
    [SerializeField] public float health;

    private AnimationPlayer Animation;

    private void Awake()
    {
        Animation = GetComponent<AnimationPlayer>();
    }

    /// <summary>
    /// �������� ��������� ���� �� ������
    /// </summary>
    /// <param name="damage"></param>
    public void DamageChatacter(float damage)
    {
        health -= damage;
        Debug.Log($"Damage - {damage}, health - {health}");
        IsAliveCheck();

    }

    /// <summary>
    /// ��������� ���� �� ����� � ���������
    /// </summary>
    private void IsAliveCheck()
    {
        if(health <= 0)
        {
            Animation.Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead")) Animation.Dead();
    }
}
