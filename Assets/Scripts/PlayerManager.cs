using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerManager : MonoBehaviour, IDamageable
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

    // Evento para avisar cuando el jugador recibe daño
    public static event Action OnPlayerDamaged;

    // Evento para cuando el jugador muere
    public static event Action OnPlayerDead;

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

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

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

    // Método para recibir daño, viene de la interfaz IDamageable
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        OnPlayerDamaged?.Invoke(); // Dispara el evento

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDead?.Invoke(); // Notifica que murió
            GameManager.Instance.PlayerDied();
        }
    }

    public virtual void UseMana(float amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
            currentMana = 0;
    }

    // Método con parámetro y retorno: calcula distancia a otro objeto
    public float CalcularDistancia(Vector3 otro)
    {
        return Vector3.Distance(transform.position, otro);
    }
}
