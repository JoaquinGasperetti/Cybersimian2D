using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    // Volver al men� principal desde la pantalla de victoria
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
