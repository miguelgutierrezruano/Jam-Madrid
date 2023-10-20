using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Toggle fullscreenToggle;
    public Button returnButton;

    private void Start()
    {
        // Cargar las configuraciones iniciales
        LoadSettings();

        // Asocia los eventos de los elementos UI a sus funciones respectivas
        musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
        returnButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void ChangeMusicVolume(float volume)
    {
        // Cambia el volumen de la música (puedes usar AudioManager o similar para aplicar esto)
        Debug.Log("Cambiando volumen de la música a: " + volume);
        // AudioManager.SetMusicVolume(volume);
    }

    private void ToggleFullscreen(bool isFullscreen)
    {
        // Cambia entre pantalla completa y modo ventana
        Debug.Log("Modo pantalla completa: " + isFullscreen);
        Screen.fullScreen = isFullscreen;
    }

    private void LoadSettings()
    {
        // Carga las configuraciones guardadas previamente (por ejemplo, desde PlayerPrefs)
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1; // 1 = true, 0 = false

        musicVolumeSlider.value = savedVolume;
        fullscreenToggle.isOn = savedFullscreen;
    }

    private void SaveSettings()
    {
        // Guarda las configuraciones en PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ApplySettings()
    {
        // Aplica las configuraciones
        ChangeMusicVolume(musicVolumeSlider.value);
        ToggleFullscreen(fullscreenToggle.isOn);

        // Guarda las configuraciones
        SaveSettings();
    }

    public void ReturnToMainMenu()
    {
        // Vuelve al menú principal
        SceneManager.LoadScene("MainMenuScene");
    }
}
