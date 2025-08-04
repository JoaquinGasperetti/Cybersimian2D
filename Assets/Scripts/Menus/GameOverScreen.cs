using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Volver al menú principal
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Reiniciar el nivel actual. (no lo implementamos xq el GameOver al final lo hacemos ne usa escena aparte)
    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
