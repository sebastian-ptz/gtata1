using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button LevelSelection;
    [SerializeField] private Button Settings;
    [SerializeField] private Button Quit;

    private void Start()
    {
        UIManager.Instance.setGameLock(true);
        LevelSelection.onClick.AddListener(UIManager.Instance.OnClickLevelSelection);
        Settings.onClick.AddListener(UIManager.Instance.OnClickSettings);
        Quit.onClick.AddListener(UIManager.Instance.OnClickQuit);
    }
}
