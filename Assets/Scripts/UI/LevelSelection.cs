using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button Cancel;
    [SerializeField] private Button Level1;
    [SerializeField] private Button Level2;
    [SerializeField] private Button Level3;

    private void Start()
    {
        Cancel.onClick.AddListener(UIManager.Instance.HandleMenuExecution);
        Level1.onClick.AddListener(SceneLevel1);
        Level2.onClick.AddListener(SceneLevel2);
        Level3.onClick.AddListener(SceneLevel3);
    }

    public void SceneLevel1()
    {
        UIManager.Instance.OnClickPlay();
        GameManager.Instance.StartGame();
        SceneManager.LoadScene(1);
    }

    public void SceneLevel2()
    {
        UIManager.Instance.OnClickPlay();
        GameManager.Instance.StartGame();
        SceneManager.LoadScene(2);
    }

    public void SceneLevel3()
    {
        UIManager.Instance.OnClickPlay();
        GameManager.Instance.StartGame();
        SceneManager.LoadScene(3);
    }
}