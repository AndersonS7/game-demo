using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{

    private Vector3 _direction;
    private float _speed = 5;

    public Rigidbody2D r;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (r.velocity.y < 0)
        {
            print("estou caindo");
        }
    }

    public void Move()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += _direction * Time.deltaTime * _speed;
    }
}
