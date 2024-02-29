using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MovePlayer.leftOfRight) spriteRenderer.flipX = false;
        if (MovePlayer.leftOfRight) spriteRenderer.flipX = true;
    }
}
