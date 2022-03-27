using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layerGround, layerWall;
    public GameObject mask, mask2, platforms;
    public Text gemTex;
    public GameObject gameOverPanel;

    private int contGem;

    Player p;

    void Start()
    {
        p = new Player(gameObject, 5, 21, layerGround, layerWall);
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
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    private void OnColliderController(GameObject obj)
    {
        // onTrigger
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
            Destroy(obj.gameObject);
        }

        // onCollider
        if (obj.CompareTag("Spikes"))
        {
            GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        OnColliderController(coll.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        OnColliderController(coll.gameObject);   
    }
}
