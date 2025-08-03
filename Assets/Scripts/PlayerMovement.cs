using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    public Rigidbody2D rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float moveInput;

    void Update()
    {
        // Input
        moveInput = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        _animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Flip sprite
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}

