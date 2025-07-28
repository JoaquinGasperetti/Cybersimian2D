using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Volver al menú principal desde la pantalla de victoria
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
