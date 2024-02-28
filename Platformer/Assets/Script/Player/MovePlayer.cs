using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private Animator animatorPlayer;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D playerRigidbody;

    private float horizontal, vertical;
    private float speed = 1.3f;

    public static bool jump = false;
    public static bool run = false;
    public static bool fall = false;

    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            if (horizontal > 0) spriteRenderer.flipX = false;
            if (horizontal < 0) spriteRenderer.flipX = true;

            run = true;

            this.gameObject.transform.position += speed * Time.deltaTime * new Vector3(horizontal, vertical).normalized;
        }

        if (vertical > 0 && jump == false)
        {
            jump = true;
            playerRigidbody.AddForce(new Vector2(horizontal, 4f), ForceMode2D.Impulse);
          
        }

        if (horizontal == 0) run = false;
    }

}
