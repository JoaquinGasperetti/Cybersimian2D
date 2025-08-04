using UnityEngine;

// Enemigo que persigue al jugador si está cerca.
public class EnemyChaser : EnemyBase
{
    [SerializeField] private float chaseDistance = 5f; // Modificable desde el inspector
    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player")?.transform;
    }

    void Update()
    {
        Actuar();
    }

    public override void Actuar()
    {
        if (target != null)
        {
            float distancia = Vector3.Distance(transform.position, target.position);
            if (distancia <= chaseDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
            }
        }
    }
}