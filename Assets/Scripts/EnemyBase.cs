using UnityEngine;

// Clase base para enemigos. Tiene vida, puede recibir daño y morir.
// Al morir suma puntos y se elimina del juego.
public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected float health = 50f;

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GameManager.Instance.AddScore(100); // Suma 100 puntos, ajusta el valor si lo deseas
        Destroy(gameObject);
    }

    public abstract void Actuar();
}