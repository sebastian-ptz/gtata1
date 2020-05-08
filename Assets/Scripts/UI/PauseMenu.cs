using System;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button Resume;
    [SerializeField] private Button Restart;        //TODO Saving
    [SerializeField] private Button LoadGame;       //TODO Loading
    [SerializeField] private Button Settings;
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button RageQuit;

    private void Start()
    {       
        Resume.onClick.AddListener(OnClickResume);
        Restart.onClick.AddListener(OnClickRestart); //TODO Saving
        LoadGame.onClick.AddListener(OnClickLoadGame); //TODO Loading
        Settings.onClick.AddListener(OnClickSettings);
        MainMenu.onClick.AddListener(OnClickMainMenu);
        RageQuit.onClick.AddListener(UIManager.Instance.OnClickQuit);
    }

    void OnClickResume()
    {
        GameManager.Instance.TogglePause();
        //UIManager.Instance.OnClickToggleMenu();
    }

    void OnClickRestart()
    {
        //TODO OnClickSave overwrite savegame
        GameManager.Instance.RestartGame();
    }

    private void OnClickLoadGame()
    {
        UIManager.Instance.setGameLock(true);
        LoadGame.onClick.AddListener(UIManager.Instance.OnClickLevelSelection);
    }

    private void OnClickSettings()
    {
        UIManager.Instance.setGameLock(true);
        Settings.onClick.AddListener(UIManager.Instance.OnClickSettings);
    }

    public void OnClickMainMenu()
    {
        UIManager.Instance.OnClickToggleMenu();
    }

    void OnClickQuit()
    {
        Application.Quit();
    }
}