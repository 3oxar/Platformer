using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health;

    private AnimationPlayer Animation;

    private void Awake()
    {
        Animation = GetComponent<AnimationPlayer>();
    }

    /// <summary>
    /// Отнимает наносимий урон от жизней
    /// </summary>
    /// <param name="damage"></param>
    public void DamageChatacter(float damage)
    {
        health -= damage;
        Debug.Log($"Damage - {damage}, health - {health}");
        isAliveCheck();

    }

    /// <summary>
    /// проверяем есть ли жизни у персонажа
    /// </summary>
    private void isAliveCheck()
    {
        if(health <= 0)
        {
            Animation.Dead();
        }
    }


}
