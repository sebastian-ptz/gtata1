using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using UnityEngine.Experimental.UIElements;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED      // How to use as boolen?
    }

    private GameState _currentGameState = GameState.PREGAME;
    public Events.EventGameState OnGameStateChanged;

    public GameObject[] SystemPrefabs;
    List<AsyncOperation> _loadOperations;

    string _currentLevelName = string.Empty;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _loadOperations = new List<AsyncOperation>();
    }

    private void Update()
    {
        if (_currentGameState == GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            Debug.Log("Pause Toggle");
        }
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            if (_loadOperations.Count == 0)
            {
                UpdateState(GameState.RUNNING);
            }
        }

        Debug.Log("Load Complete");
    }

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        private set { _currentGameState = value; }
    }

    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;


            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;


            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;

            default:
                break;
        }

        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
        Debug.Log(_currentGameState);
    }

    public void StartGame()
    {
        LoadLevel("StartScene");
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level" + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;
        }
        ao.completed += OnUnloadOperationComplete;

        if (levelName == "StartScene")
        {
            Destroy(gameObject);
        }
    }

    public void Reset(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;
        }
        ao.completed += OnUnloadOperationComplete;
        Destroy(gameObject);
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete");
    }

    public void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    public void RestartGame()
    {
        UpdateState(GameState.RUNNING);
        string previousLevelName = SceneManager.GetActiveScene().name;
        UnloadLevel(previousLevelName);
    }
}using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using UnityEngine.Experimental.UIElements;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED      // How to use as boolen?
    }

    private GameState _currentGameState = GameState.PREGAME;
    public Events.EventGameState OnGameStateChanged;

    public GameObject[] SystemPrefabs;
    List<AsyncOperation> _loadOperations;

    string _currentLevelName = string.Empty;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _loadOperations = new List<AsyncOperation>();
    }

    private void Update()
    {
        if (_currentGameState == GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            Debug.Log("Pause Toggle");
        }
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            if (_loadOperations.Count == 0)
            {
                UpdateState(GameState.RUNNING);
            }
        }

        Debug.Log("Load Complete");
    }

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        private set { _currentGameState = value; }
    }

    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;


            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;


            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;

            default:
                break;
        }

        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
        Debug.Log(_currentGameState);
    }

    public void StartGame()
    {
        LoadLevel("StartScene");
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level" + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;
        }
        ao.completed += OnUnloadOperationComplete;

        if (levelName == "StartScene")
        {
            Destroy(gameObject);
        }
    }

    public void Reset(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level" + levelName);
            return;
        }
        ao.completed += OnUnloadOperationComplete;
        Destroy(gameObject);
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete");
    }

    public void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    public void RestartGame()
    {
        UpdateState(GameState.RUNNING);
        string previousLevelName = SceneManager.GetActiveScene().name;
        UnloadLevel(previousLevelName);
    }
}