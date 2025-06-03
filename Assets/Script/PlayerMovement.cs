using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    int groundLayer;
    public bool isGrounded;
    void Start()
    {
        // Ambil komponen rigidbody dari objek player
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundLayer = LayerMask.GetMask("Ground");
    }


    //sprite flip ini berguna untuk mengubah hadapan player
    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    
    private void Update()
    {
        // Menggerakan player ke kanan atau kiri menggunakan transform.translate
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);
        if (horizontalInput != 0) { PlayWalk(); }

        // Mengaktifkan lompatan player jika player menyentuh tanah
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) <= 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJump();

        }
    }

    private void PlayWalk()
    {
        animator.SetTrigger("Go Walk");
    }
    private void PlayJump()
    {
        animator.SetTrigger("Go Jump");
    }
    
}