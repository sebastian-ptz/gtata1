using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button LevelSelection;
    [SerializeField] private Button Controls;
    [SerializeField] private Button Quit;

    private void Start()
    {
        LevelSelection.onClick.AddListener(UIManager.Instance.onClickLevelSelect);
        Controls.onClick.AddListener(UIManager.Instance.onClickControl);
        Quit.onClick.AddListener(UIManager.Instance.onClickQuit);
    }
}
