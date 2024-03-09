using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Transform groundedColiderTransform;
    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private float speed = 1.4f;
    [SerializeField] private float jumpForse = 4;

    private Rigidbody2D playerRigidbody;
    private Vector2 groundPosition;

    public bool isGround = true;

    private float radiusColiderGrounded = 0.03f;
   

    // Start is called before the first frame update
    private void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        groundPosition = groundedColiderTransform.position;
        isGround = Physics2D.OverlapCircle(groundPosition, radiusColiderGrounded, groundLayerMask);
    }

    public void Move(float horizontal, bool jump)
    {
        if(Mathf.Abs(horizontal) >0.01f) 
            HorizontalMovePlayer(horizontal);

        if (jump)
            JumpPlayer();
    }

    private void HorizontalMovePlayer(float direction)
    {
        playerRigidbody.velocity = new Vector2(direction * speed, playerRigidbody.velocity.y);
    }

    private void JumpPlayer()
    {
        if (isGround)
            playerRigidbody.AddForce(new Vector2(playerRigidbody.velocity.x, jumpForse), ForceMode2D.Impulse);
    }
}
