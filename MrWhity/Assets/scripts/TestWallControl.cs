using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestWallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    public Joystick joystick;

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 15f)] public float jumpForce = 8f;

    [Header("Player Animation Settings")]
    public Animator animator;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && Time.timeScale > 0)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        // HorizontalMove = joystick.Horizontal * speed;
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed; //вкл когда делаешь пк билд!! Ставь // в самом начале когда андроид!!


    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        CheckGround();
    }

    public void OnJumpButtonDown()
    {
        if (isGrounded && Time.timeScale > 0)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


}

