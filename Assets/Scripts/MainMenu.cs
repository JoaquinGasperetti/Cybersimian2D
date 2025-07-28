using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Cargar el primer nivel del juego
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    // Salir del juego
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se cerró.");
    }
}
