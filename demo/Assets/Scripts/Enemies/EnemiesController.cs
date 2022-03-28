using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private float direction, timeMove;
    private GameObject targetObj;

    public LayerMask layer;

    Enemy frog;

    void Start()
    {
        frog = new Enemy(gameObject, 1, 12, layer);
        targetObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        frog.AnimatorController();

        if (targetObj != null && 
            Vector2.Distance(targetObj.transform.position, gameObject.transform.position) < 4)
        {
            timeMove += Time.deltaTime;

            if (timeMove > 1)
            {
                direction = targetObj.transform.position.x - gameObject.transform.position.x;
                frog.Move(direction);
                frog.Jump();

                if (timeMove >= 1.5f)
                {
                    timeMove = 0;
                }
            }
        }
    }
}
