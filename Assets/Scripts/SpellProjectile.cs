using UnityEngine;

// Es el proyectil de un hechizo.
// Se mueve hacia el enemigo más cercano.
// Si choca con un enemigo, le quita vida y desaparece.
public class SpellProjectile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 10f;

    private Vector2 direction;

    public void Init(Vector2 spawnPosition)
    {
        // Buscar el enemigo más cercano
        EnemyBase[] enemigos = FindObjectsOfType<EnemyBase>();
        EnemyBase enemigoCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (var enemigo in enemigos)
        {
            float distancia = Vector2.Distance(spawnPosition, enemigo.transform.position);
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                enemigoCercano = enemigo;
            }
        }

        if (enemigoCercano != null)
        {
            direction = (enemigoCercano.transform.position - transform.position).normalized;
        }
        else
        {
            direction = Vector2.right; // Dirección por defecto si no hay enemigos
        }
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject); // Se destruye si choca con algo que no sea el jugador
        }
    }
}