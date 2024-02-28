using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private Animator animatorPlayer;
    private SpriteRenderer spriteRenderer;

    private float horizontal, vertical;
    private float speed = 1.3f;

    private bool jump = true;

    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            if(horizontal > 0) spriteRenderer.flipX = false;
            if(horizontal < 0) spriteRenderer.flipX = true;

            animatorPlayer.SetBool("Run", true);
            this.gameObject.transform.position += speed * Time.deltaTime * new Vector3(horizontal, vertical).normalized;
        }

        if (vertical > 0 && jump == true)
        {
            jump = false;
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(0, 3f, 0), 0.2f);
        }
        
        
        if (horizontal == 0) animatorPlayer.SetBool("Run", false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) jump = true; 
    }
}
