using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{

    private Animator animatorPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovePlayer.run)
        {
            if (MovePlayer.jump == false) animatorPlayer.SetBool("Run", true);
        }
        else
        {
            animatorPlayer.SetBool("Run", false);
        }

        if (MovePlayer.jump)
        {
            animatorPlayer.SetBool("Run", false);
            animatorPlayer.SetBool("Jump", true);
            animatorPlayer.SetBool("JumpFall", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            MovePlayer.jump = false;
            OfAllAnimation();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && MovePlayer.jump == false)
        {
            OfAllAnimation();
            animatorPlayer.SetBool("Fall", true);
        }
    }

    /// <summary>
    /// Выключаем все анимации на персонаже 
    /// </summary>
    private void OfAllAnimation()
    {
        animatorPlayer.SetBool("Jump", false);
        animatorPlayer.SetBool("JumpFall", false);
        animatorPlayer.SetBool("Fall", false);
    }
}
