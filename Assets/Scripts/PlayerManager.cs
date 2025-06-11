using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Atributos")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float maxMana = 50f;
    public float currentMana;

    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    protected Rigidbody2D rb;
    protected bool isGrounded = false;
    private Vector2 moveInput;
    private bool jumpPressed = false;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    // Callback para el evento Move del Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Callback para el evento Jump del Input System
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpPressed = true;
    }

    protected void Move()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    protected void Jump()
    {
        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        jumpPressed = false;
    }

    // Detección de suelo usando colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Método virtual para lanzar hechizos, para ser sobrescrito en clases hijas
    protected virtual void CastSpell()
    {
        // Implementar en clases hijas
    }

    // Método para recibir daño
    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Lógica de muerte aquí
        }
    }

    // Método para usar maná
    public virtual void UseMana(float amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
            currentMana = 0;
    }
}
