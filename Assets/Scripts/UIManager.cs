using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text livesText;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Vidas: " + lives;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Puntaje: " + score;
    }
}
