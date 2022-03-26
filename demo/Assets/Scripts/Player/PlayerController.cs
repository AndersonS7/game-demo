using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layerGround;
    public GameObject mask, mask2, platforms;
    public Text gemTex;

    private int contGem;

    Player p;

    void Start()
    {
        p = new Player(gameObject, 5, 21, layerGround);
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
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("FrontDoor"))
        {
            mask.SetActive(false);
        }
        else if (coll.CompareTag("ExitDoor"))
        {
            mask.SetActive(true);
        }
        else if (coll.CompareTag("FrontDoor2"))
        {
            mask2.SetActive(false);
        }
        else if (coll.CompareTag("Gem"))
        {
            contGem++;
            gemTex.text = contGem.ToString("00");
            Destroy(coll.gameObject);
        }
    }
}
