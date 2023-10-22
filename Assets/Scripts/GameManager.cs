using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool controlsEnabled, GamePaused;
    float GameTime;
    [SerializeField] private GameObject PausePanel;
    
   
  
    void Awake()
    {      
        Instance = this;       
    }

    private void Start()
    {
      //  GameTime = 0;
        GamePaused = false;
    }


    private void Update()
    {
        PauseAndResume();
    }
    private void PauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (GamePaused)
            {
                case false:
                    Time.timeScale = 0;
                    ShowUIPanel(PausePanel);
                    GamePaused = true;

                    break;

                case true:

                    ResumeGame();

                    break;
            }
        }
    }
    public void ShowUIPanel(GameObject objeto)
    {
        objeto.SetActive(true);
    }
    public void HideUIPanel(GameObject objeto)
    {
        objeto.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        HideUIPanel(PausePanel);
        GamePaused = false;
    }

    public void LoadXScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /* void CountTime()
     {
         GameTime += Time.deltaTime;
     }


     private void EnableAndDisableControls(bool controlsState)
     {
         controlsEnabled = controlsState;
     }







     

    */

}
