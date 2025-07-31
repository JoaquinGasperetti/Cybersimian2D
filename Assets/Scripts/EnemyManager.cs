using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyBase[] enemigos;
    public Transform player;

    void Start()
    {
        enemigos = FindObjectsOfType<EnemyBase>();
    }

    void Update()
    {
        if (enemigos.Length > 0)
        {
            var ordenados = enemigos.OrderBy(e => Vector3.Distance(e.transform.position, player.position)).ToList();
            var masCercano = ordenados.FirstOrDefault();
            if (masCercano != null)
            {
                Debug.DrawLine(masCercano.transform.position, player.position, Color.red);
            }
        }
    }
}