using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject gameOverPanel, initialUI, exitMenu;

    private void Awake()
    {
        Time.timeScale = 1;
        initialUI.SetActive(true);
        PlayerPrefs.SetString("Start", "");
        PlayerPrefs.Save();
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Scene");
    }

    public void InitialFase()
    {
        initialUI.SetActive(false);
        exitMenu.SetActive(true);
        PlayerPrefs.SetString("Start", "start");
        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActiveMenu()
    {
        exitMenu.SetActive(false);
        initialUI.SetActive(true);
        PlayerPrefs.SetString("Start", "");
        PlayerPrefs.Save();
    }
}
