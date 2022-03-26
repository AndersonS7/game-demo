using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 direction;

    public float speed, jumpForce, totalJump;
    public Rigidbody2D rig;
    public Collider2D coll2D;
    public LayerMask layerGround;

    void Start()
    {
        totalJump = 0;
        //speed = 5;
    }

    void Update()
    {
        if (isGround() && totalJump > 1)
        {
            totalJump = 0;
        }
        Jump();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += direction * Time.deltaTime * speed;
    }

    private void Jump()
    {
        if (isGround())
        {
            if (Input.GetButtonDown("Jump"))
            {
                rig.velocity = Vector2.up * jumpForce;
                totalJump++;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
            totalJump++;
        }
    }

    private bool isGround()
    {
        RaycastHit2D ground = Physics2D.BoxCast(coll2D.bounds.center,
            coll2D.bounds.size, 0, Vector2.down, 0.1f, layerGround);

        return ground.collider != null;
    }
}
