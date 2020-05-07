using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button BackToMenu;
    [SerializeField] private Button level1;
    [SerializeField] private Button level2;
    [SerializeField] private Button level3;

    private void Start()
    {
        BackToMenu.onClick.AddListener(UIManager.Instance.onClickBacktoMenu);
        level1.onClick.AddListener(sceneLevel1);
        level2.onClick.AddListener(sceneLevel2);
        level3.onClick.AddListener(sceneLevel3);
    }

    public void sceneLevel1()
    {
        GameManager.Instance.StartGame();
        SceneManager.LoadScene(1);
    }

    public void sceneLevel2()
    {
        GameManager.Instance.StartGame();
        SceneManager.LoadScene(1);
    }

    public void sceneLevel3()
    {
        GameManager.Instance.StartGame();
        SceneManager.LoadScene(1);
    }
}