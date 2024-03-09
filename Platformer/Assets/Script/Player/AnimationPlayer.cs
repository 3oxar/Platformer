using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(MovePlayer))]
public class AnimationPlayer : MonoBehaviour
{

    private Animator animatorPlayer;
    private MovePlayer movePlayer;
  
    private void Awake()
    {
        animatorPlayer = this.GetComponent<Animator>();
        movePlayer = this.GetComponent<MovePlayer>();
    }

    void FixedUpdate()
    {
        if (!movePlayer.isGround)
            animatorPlayer.SetBool("Fall", true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision != null) animatorPlayer.SetBool("Fall", false);
    }


    /// <summary>
    /// Управления анимациями персонажа 
    /// </summary>
    /// <param name="runPlayerAnim">бежит ли персонаж</param>
    public void PlayerAnim(float runPlayerAnim, bool jumpPlayerAnim, bool attackPlayerAnim)
    {
        if (runPlayerAnim != 0)
            RunAnim(true);
        else
            RunAnim(false);

        if (jumpPlayerAnim)
            JumpAnim(jumpPlayerAnim);
        else 
            JumpAnim(jumpPlayerAnim);

        if(attackPlayerAnim)
            AttackAnim(attackPlayerAnim);
        else 
            AttackAnim(attackPlayerAnim);
    }

    public void RunAnim(bool state)
    {
        animatorPlayer.SetBool("Run", state);
    }

    public void JumpAnim(bool state)
    {
        animatorPlayer.SetBool("Jump", state);
    }

    public void AttackAnim(bool state)
    {
        animatorPlayer.SetBool("Attack",state);
    }

    public void Dead()
    {
        StartCoroutine(DeadPlayer());
        animatorPlayer.SetBool("Death", true);
    }

    /// <summary>
    /// Делаем задержку что бы проиграть анимацию смерти
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeadPlayer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }


}
