using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Volver al menú principal
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    // Reiniciar el nivel actual.
    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
