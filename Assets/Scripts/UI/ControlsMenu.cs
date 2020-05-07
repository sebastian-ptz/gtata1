using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] private Button BackToMenu;

    private void Start()
    {
        BackToMenu.onClick.AddListener(UIManager.Instance.onClickBacktoMenu);
    }
}
