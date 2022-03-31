using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject gameOverPanel, initialUI;

    private void Awake()
    {
        Time.timeScale = 1;
        initialUI.SetActive(true);
        PlayerPrefs.SetString("Start", "");
        PlayerPrefs.Save();
    }

    void Update()
    {
        ActiveMenu();
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Scene");
    }

    public void InitialFase()
    {
        initialUI.SetActive(false);
        PlayerPrefs.SetString("Start", "start");
        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ActiveMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            initialUI.SetActive(true);
            PlayerPrefs.SetString("Start", "");
            PlayerPrefs.Save();
        }
    }
}
