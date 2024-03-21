using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private AnimationPlayer Animation;

    private void Awake()
    {
        Animation = GetComponent<AnimationPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead")) Animation.Dead();
    }
}
