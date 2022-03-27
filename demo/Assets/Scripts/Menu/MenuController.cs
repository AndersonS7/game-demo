using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Scene");
    }
}
