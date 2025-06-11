using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerLives = 3;
    public int score = 0;

    private void Awake()
    {
        // Singleton pattern para asegurar solo una instancia
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
        UIManager.Instance.UpdateLives(playerLives);
        UIManager.Instance.UpdateScore(score);
    }

    // Llamar cuando el jugador muere
    public void PlayerDied()
    {
        playerLives--;
        UIManager.Instance.UpdateLives(playerLives);
        if (playerLives > 0)
        {
            // Reinicia el nivel actual
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
        // Aquí puedes actualizar la UI
    }

    private void GameOver()
    {
        // Aquí puedes mostrar la pantalla de Game Over o reiniciar el juego
        Debug.Log("Game Over");
        // Reinicia el juego (opcional)
        playerLives = 3;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
