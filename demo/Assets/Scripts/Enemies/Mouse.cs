using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private float direction;

    Enemy mouse;

    void Start()
    {
        mouse = new Enemy(gameObject, 2);
        mouse.Move(-1);
    }

    void Update()
    {
        mouse.Move(direction);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Wall"))
        {
            if (direction > 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
    }
}
