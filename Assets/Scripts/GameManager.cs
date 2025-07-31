using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        PlayerManager.OnPlayerDead += PlayerDied;
        UIManager.Instance.UpdateLives(playerLives);
        UIManager.Instance.UpdateScore(score);
    }

    // Se llama cuando el jugador muere
    public void PlayerDied()
    {
        playerLives--;
        UIManager.Instance.UpdateLives(playerLives);
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
        UIManager.Instance.UpdateScore(score);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        playerLives = 3;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
