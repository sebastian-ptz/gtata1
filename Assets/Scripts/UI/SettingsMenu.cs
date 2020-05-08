using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button CancelExectution; // from level to Pausemenu and also to Mainmenu
    [SerializeField] private Button ApplySettings;

    private void Start()
    {
       CancelExectution.onClick.AddListener(OvertakeMenu);
    }

    public void OvertakeMenu()
    {
        UIManager.Instance.HandleMenuExecution(GameManager.Instance._currentGameState);
    }

    public void ExecuteSettings()
    {
        //TODO EInstellungen für das Spiel z.B. Mausempfidnlichkeit
    }
}