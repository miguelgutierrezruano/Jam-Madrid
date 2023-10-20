using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;

    private void Start()
    {
        // Asocia los botones a sus funciones respectivas
        playButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        // Inicia el juego (reemplaza "NombreDeTuEscena" con el nombre de la escena de juego)
        SceneManager.LoadScene("NombreDeTuEscena");
    }

    private void OpenOptions()
    {
        // Abre el menú de opciones
        SceneManager.LoadScene("OptionsMenu");
    }

    private void QuitGame()
    {
        // Sale del juego
        Application.Quit();
    }
}
