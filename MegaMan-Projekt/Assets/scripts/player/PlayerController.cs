using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    // References
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider;
    
    // Checks
    private bool isShooting;
    private bool isFlipped;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        JumpLogic();

    }

    private void FixedUpdate()
    {
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody2D.velocity.y);

        if (horizontalInput < 0 && !isFlipped)
            Flip();
        else if (horizontalInput > 0 && isFlipped)
            Flip();
    }

    private void JumpLogic()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);

        if (Input.GetButtonUp("Jump"))
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * .1f);
        //_rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        isFlipped = !isFlipped;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private bool IsGrounded()
    {
        Bounds bounds = _boxCollider.bounds;
        float rayExtraLength = .05f;
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, rayExtraLength, LayerMask.GetMask("Ground"));
        
        return raycastHit.collider != null;
    }
}
