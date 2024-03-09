using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovePlayer))]
[RequireComponent(typeof(AnimationPlayer))]
[RequireComponent(typeof(SpriteControl))]
[RequireComponent(typeof(Attack))]
public class InputPlayer : MonoBehaviour
{
    private MovePlayer movePlayer;
    private AnimationPlayer animationPlayer;
    private SpriteControl spriteControl;
    private Attack attack;

    private float horizontalMove;
    private bool jump;
    private bool attacked;

    private void Awake()
    {
        movePlayer = GetComponent<MovePlayer>();
        animationPlayer = GetComponent<AnimationPlayer>();
        spriteControl = GetComponent<SpriteControl>();
        attack = GetComponent<Attack>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        attacked = Input.GetButtonDown("Fire1");

        movePlayer.Move(horizontalMove, jump);//движение
        animationPlayer.PlayerAnim(horizontalMove, jump, attacked);//управление анимациями
        spriteControl.ChangedSpriteFlip(horizontalMove);//управление спрайтами
        attack.AttackSide(horizontalMove);//управлние атакай 
    }
}
