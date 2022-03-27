using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void StartScene()
    {
        SceneManager.LoadScene("Scene");
    }
}
