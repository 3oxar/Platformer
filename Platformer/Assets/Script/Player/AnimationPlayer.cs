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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") )
        {
            OfAllAnimation();
            animatorPlayer.SetBool("Death", true);
            StartCoroutine(DeadPlayer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            MovePlayer.jump = false;
            OfAllAnimation();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && MovePlayer.jump == false)
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
        animatorPlayer.SetBool("Fall", false);
        animatorPlayer.SetBool("Run", false);
    }

    private IEnumerator DeadPlayer()
    {
        yield return new WaitForSeconds(1f);
        Dead.DeadPlayer();
    }
}
