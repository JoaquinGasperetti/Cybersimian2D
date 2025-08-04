using System.Linq;
using UnityEngine;

// Busca todos los enemigos en la escena.
// Dibuja una línea al enemigo más cercano al jugador.
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
            var vivos = enemigos.Where(e => e != null).ToList();
            if (vivos.Count > 0)
            {
                var ordenados = vivos.OrderBy(e => Vector3.Distance(e.transform.position, player.position)).ToList();
                var masCercano = ordenados.FirstOrDefault();
                if (masCercano != null)
                {
                    Debug.DrawLine(masCercano.transform.position, player.position, Color.red);
                }
            }
        }
    }
}