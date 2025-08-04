using UnityEngine;
using UnityEngine.SceneManagement;

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

        // Verifica si quedan enemigos en la escena
        if (FindObjectsOfType<EnemyBase>().Length == 1) // Solo este queda antes de destruirse
        {
            var currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "TutorialGod")
            {
                SceneManager.LoadScene("Nivel1");
            }
            else if (currentScene == "Nivel1")
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }

    public abstract void Actuar();
}