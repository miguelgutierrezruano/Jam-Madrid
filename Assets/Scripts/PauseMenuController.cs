using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false); // Inicialmente, el menú de pausa está desactivado
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f; // Reanuda el juego
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f; // Pausa el juego
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void RestartGame()
    {
        // Reinicia la escena actual (puedes personalizar esto si es necesario)
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        ResumeGame(); // Asegúrate de despausar el juego después de reiniciar
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1.0f; // Asegúrate de despausar el juego
        SceneManager.LoadScene("MainMenu"); 
    }
}
