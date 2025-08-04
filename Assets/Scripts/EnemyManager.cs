using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

// Busca todos los enemigos en la escena.
// Dibuja una línea al enemigo más cercano al jugador.
public class EnemyManager : MonoBehaviour
{
    private EnemyBase[] enemigos;
    public Transform player;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        enemigos = FindObjectsOfType<EnemyBase>();
        AssignPlayer();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignPlayer();
    }

    private void AssignPlayer()
    {
        var playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (enemigos.Length > 0 && player != null)
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