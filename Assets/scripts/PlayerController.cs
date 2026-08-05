using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int maxJumps = 2; // Maximum 2 jumps

    [Header("Components")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private float mobileInput = 0f;
    private int _jumpsRemaining;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        _jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // 1. Keyboard Controls (A/D or Arrow keys)
        float keyboardInput = 0f;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                keyboardInput = -1f;
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                keyboardInput = 1f;

            // Spacebar Jump
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }
        }

        // 2. Mobile Button Input takes priority if pressed, else Keyboard Input
        float currentInput = (mobileInput != 0) ? mobileInput : keyboardInput;

        // 3. RUNNING ANIMATION CONTROL:
        // Current input jab tak 0 nahi hoga (daba ke rakhoge), movespeed chalti rahegi aur isRunning true rahega!
        if (animator != null)
        {
            animator.SetBool("isRunning", currentInput != 0);
        }

        // 4. Player Flip (Face direction change)
        if (currentInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (currentInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // Apply movement velocity
        rb.linearVelocity = new Vector2(currentInput * moveSpeed, rb.linearVelocity.y);
    }

    // --- DOUBLE JUMP SYSTEM ---
    public void Jump()
    {
        if (_jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Air control reset
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            _jumpsRemaining--;

            if (animator != null)
            {
                animator.SetBool("isJumping", true);
            }
        }
    }

    // --- MOBILE UI BUTTON EVENTS ---
    // Jab button dabaye rakhoge:
    public void MoveLeft() => mobileInput = -1f;
    public void MoveRight() => mobileInput = 1f;

    // Jab button chhodge (PointerUp):
    public void StopMove() => mobileInput = 0f;

    // --- COLLISION DETECTIONS ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground pe aate hi jumps restore ho jayenge aur jumping animation stop ho jayega
        _jumpsRemaining = maxJumps;

        if (animator != null)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player touches spikes/hazard
        if (collision.CompareTag("Hazard"))
        {
            // Hide player sprite or disable movement controls
            gameObject.SetActive(false);

            // Call GameManager to open the Game Over panel
            if (GameManager.Instance != null)
            {
                GameManager.Instance.TriggerGameOver();
                Debug.Log("LOSS GAME");            }
        }
    }
}