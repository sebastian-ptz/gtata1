using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button Apply;
    [SerializeField] private Button Cancel;

    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UIManager.Instance.getGameLock())
           GameManager.Instance.TogglePause();

        Cancel.onClick.AddListener(UIManager.Instance.OnClickToggleMenu);
    }
}