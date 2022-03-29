using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layerGround, layerWall;
    public GameObject mask, mask2, platforms, gameOverPanel, endPanel;
    public Text gemTex;

    private int contGem;

    Player p;

    void Start()
    {
        p = new Player(gameObject, 5, 22.5f, layerGround, layerWall);
    }

    void Update()
    {
        p.Jump();
        ActivePlatform();
    }
    void FixedUpdate()
    {
        p.Move();
    }
    private void ActivePlatform()
    {
        if (contGem == 2)
        {
            platforms.SetActive(true);
        }
    }
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
    private void OnTriggerController(GameObject obj)
    {
        if (obj.CompareTag("FrontDoor"))
        {
            mask.SetActive(false);
        }
        else if (obj.CompareTag("ExitDoor"))
        {
            mask.SetActive(true);
        }
        else if (obj.CompareTag("FrontDoor2"))
        {
            mask2.SetActive(false);
        }
        else if (obj.CompareTag("Gem"))
        {
            contGem++;
            gemTex.text = contGem.ToString("00");
        }
        else if (obj.CompareTag("End"))
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnColliderController(GameObject obj)
    {
        if (obj.CompareTag("Spikes"))
        {
            GameOver();
        }
        else if (obj.CompareTag("Enemy"))
        {
            GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        OnTriggerController(coll.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        OnColliderController(coll.gameObject);
    }
}
