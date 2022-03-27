using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private float direction;
    private GameObject targetObj;

    public LayerMask layer;

    Enemy frog;

    void Start()
    {
        frog = new Enemy(gameObject, 0.3f, 10, layer);
        targetObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (targetObj != null && 
            Vector2.Distance(targetObj.transform.position, gameObject.transform.position) < 3)
        {
            direction = targetObj.transform.position.x - gameObject.transform.position.x;
            frog.Move(direction);
            frog.Jump();
        }
    }
}
