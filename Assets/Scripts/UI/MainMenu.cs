using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button LevelSelection;
    [SerializeField] private Button Settings;
    [SerializeField] private Button Quit;
    private bool SettingsChanged;

    private void Start()
    {
        LevelSelection.onClick.AddListener(UIManager.Instance.HandleLevelSelect);
        Settings.onClick.AddListener(HandleSettings);
        Quit.onClick.AddListener(UIManager.Instance.HandleQuit);
    }

    private void HandleSettings()
    {
        UIManager.Instance.HandleSetting();
    }
}
