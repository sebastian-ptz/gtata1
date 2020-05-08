using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button CancelExectution; // from level to Pausemenu and also to Mainmenu
    [SerializeField] private Button ApplySettings;

    private void Start()
    {
       CancelExectution.onClick.AddListener(UIManager.Instance.HandleMenuExecution);
    }
}