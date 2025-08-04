using UnityEngine;
using UnityEngine.SceneManagement;

// Controla las vidas y el puntaje del jugador.
// Reinicia el nivel si el jugador muere.
// Si se acaban las vidas, reinicia el juego.
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerLives = 3;
    public int score = 0;

    private void Awake()
    {
        // Singleton para que haya una sola instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        PlayerManager.OnPlayerDead += PlayerDied;
    }

    void OnDisable()
    {
        PlayerManager.OnPlayerDead -= PlayerDied;
    }

    void Start()
    {
        UIManager.Instance.UpdateLives(playerLives);
        UIManager.Instance.UpdateScore(score);
    }

    // Se llama cuando el jugador muere
    public void PlayerDied()
    {
        playerLives--;
        //UIManager.Instance.UpdateLives(playerLives);
        if (playerLives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            GameOver();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        //UIManager.Instance.UpdateScore(score);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        playerLives = 3;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
