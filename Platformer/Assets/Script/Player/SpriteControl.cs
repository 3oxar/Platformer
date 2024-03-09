using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class SpriteControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void ChangedSpriteFlip(float leftOrRight)
    {
        if (leftOrRight > 0) spriteRenderer.flipX = false;
        if (leftOrRight < 0) spriteRenderer.flipX = true;
    }
}
