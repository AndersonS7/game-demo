using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private float direction;
    private bool target;
    private GameObject targetObj;

    public LayerMask layer;

    Enemy frog;

    void Start()
    {
        frog = new Enemy(gameObject, 0.5f, 15, layer);
        target = false;
        targetObj = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (target)
        {
            if (targetObj != null)
            {
                direction = targetObj.transform.position.x - gameObject.transform.position.x;
                frog.Move(direction);
                frog.Jump();
            }
        }
    }

    private void OnColliderController(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            target = true;
        }
    }

    private void OnColliderExitController(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            target = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        OnColliderController(coll.gameObject);
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        OnColliderExitController(coll.gameObject);
    }
}
