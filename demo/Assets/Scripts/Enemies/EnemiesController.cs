using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private float direction, timeMove;
    private GameObject targetObj;
    private bool isCollider;

    public Collider2D col2D;
    public LayerMask layer;

    Enemy frog;

    void Start()
    {
        isCollider = false;
        frog = new Enemy(gameObject, 1, 12, layer);
        targetObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        frog.AnimatorController();

        if (targetObj != null && isCollider)
        {
            timeMove += Time.deltaTime;

            if (timeMove > 0.5f)
            {
                direction = targetObj.transform.position.x - gameObject.transform.position.x;
                frog.Move(direction);
                frog.Jump();

                if (timeMove >= 1)
                {
                    timeMove = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            isCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            isCollider = false;
        }
    }
}
