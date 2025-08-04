using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Muestra las vidas y el puntaje en pantalla.
// Actualiza los textos cuando cambian vidas o puntaje.
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text manaText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Suscribe al evento de carga de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        livesText = GameObject.Find("TextoVidas")?.GetComponent<TMP_Text>();
        scoreText = GameObject.Find("TextoPuntos")?.GetComponent<TMP_Text>();
        manaText = GameObject.Find("TextoMana")?.GetComponent<TMP_Text>();

        UpdateLives(GameManager.Instance.playerLives);
        UpdateScore(GameManager.Instance.score);

        // Obtiene el mana del jugador actual
        var player = FindObjectOfType<PlayerManager>();
        if (player != null)
            UpdateMana(player.currentMana, player.maxMana);
    }

    public void UpdateLives(int lives)
    {
        if (livesText != null)
            livesText.text = "Vidas: " + lives;
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Puntaje: " + score;
    }

    public void UpdateMana(float currentMana, float maxMana)
    {
        if (manaText != null)
            manaText.text = $"Mana: {currentMana:0}/{maxMana:0}";
    }
}
