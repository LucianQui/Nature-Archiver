using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float moveSpeed = 6f;
    private float Horizontal;
    public float jumpForce = 5f;
    private bool isGrounded = true;
    private Animator Animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2 (moveInput * moveSpeed, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {   
            Jump();
        }

        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("walking", Horizontal != 0.0f);

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
          
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(Horizontal, _rb.velocity.y);
    }

    void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
}
