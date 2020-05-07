using UnityEngine;

public class UIManager : Singleton<UIManager>
{
   [SerializeField] private GameObject MainMenuUI;
   [SerializeField] private GameObject levelSelectionUI;
   [SerializeField] private GameObject controlUI;
   [SerializeField] private GameObject pauseUI;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);        
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.PREGAME)
        {
            pauseUI.SetActive(false);
        }

        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (currentState == GameManager.GameState.RUNNING)
        {
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (previousState == GameManager.GameState.RUNNING && currentState == GameManager.GameState.PAUSED)
        {
            pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void onClickLevelSelect()
   {
       MainMenuUI.SetActive(false);
       levelSelectionUI.SetActive(true);
   }

   public void onClickControl()
   {
       MainMenuUI.SetActive(false);
       controlUI.SetActive(true);
   }

   public void onClickQuit()
   {
       Application.Quit();
   }

   public void onClickBacktoMenu() 
   {
       MainMenuUI.SetActive(true);
       controlUI.SetActive(false);
       levelSelectionUI.SetActive(false);    
   }

    public void onClickPlay()
    {
        levelSelectionUI.SetActive(false);
    }

}