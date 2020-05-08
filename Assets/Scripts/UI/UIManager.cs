using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject LevelSelection;
a
    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.PREGAME)
        {
            PauseMenu.SetActive(false);
        }

        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (currentState == GameManager.GameState.RUNNING)
        {
            PauseMenu.SetActive(false);
            MainMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (previousState == GameManager.GameState.RUNNING && currentState == GameManager.GameState.PAUSED)
        {
            PauseMenu.SetActive(true);
            MainMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }

        //if (previousState == GameManager.GameState.PAUSED && currentState == GameManager.GameState.RUNNING)
        //{

        //    PauseMenu.SetActive(false);
        //    LevelSelection.SetActive(false);
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }

    public void OnClickLevelSelection()
    {
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        LevelSelection.SetActive(true);
    }

    public void OnClickSettings()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void OnClickToggleMainMenu()
    {
        LevelSelection.SetActive(false);
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(false);
        MainMenu.SetActive(true);

        //string levelname = SceneManager.GetActiveScene().name;
    }

    public void OnClickTogglePause()
    {
        LevelSelection.SetActive(false);
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void OnClickLevel()
    {
        LevelSelection.SetActive(false);
    }


    public void OnClickQuit()
    {
        Application.Quit();
    }
}