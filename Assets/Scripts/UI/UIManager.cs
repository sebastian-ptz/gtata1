using UnityEngine;

public class UIManager : Singleton<UIManager>
{
   [SerializeField] private GameObject MainMenuUI;
   [SerializeField] private GameObject levelSelectionUI;
   [SerializeField] private GameObject controlUI;

       private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);        
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            Debug.Log("GameStateChanged");
        }

        if (previousState != GameManager.GameState.PREGAME && currentState == GameManager.GameState.PREGAME)
        {

            Debug.Log("GameStateChanged");
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

}