using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject _gameObj;
    private Vector3 _direction;
    private float _speed, _jumpForce, _timeFallingDrown;
    private int _totalJump;
    private Rigidbody2D _rig;
    private Collider2D _coll2D;
    private Animator _animator;
    private LayerMask _layerGround;

    public Player(GameObject gameObj)
    {
        _gameObj = gameObj;
        Initialize();
    }

    public Player(GameObject gameObj, float speed, float jumpForce, LayerMask layerGround)
    {
        _gameObj = gameObj;
        _speed = speed;
        _jumpForce = jumpForce;
        _layerGround = layerGround;
        Initialize();
    }

    public void Move()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        _gameObj.transform.position += _direction * Time.deltaTime * _speed;

        // animação correndo
        if (Input.GetAxis("Horizontal") != 0)
        {
            _animator.SetBool("TaCorrendo", true);
        }
        else
        {
            _animator.SetBool("TaCorrendo", false);
        }

        // vira para os lados
        if (Input.GetAxis("Horizontal") > 0)
        {
            _gameObj.transform.localScale = new Vector3(1,
                _gameObj.transform.localScale.y, _gameObj.transform.localScale.z);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _gameObj.transform.localScale = new Vector3(-1,
                _gameObj.transform.localScale.y, _gameObj.transform.localScale.z);
        }
    }
    public void Jump()
    {
        // verifica se o player está caindo
        CheckFallingDown();

        // pulo comum
        if (isGround() && _totalJump < 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rig.velocity = Vector2.up * _jumpForce;
                _totalJump++;
                _animator.SetBool("TaPulando", true);
            }
        }// pulo se estiver caindo
        else if (!isGround() && _totalJump < 1 && _timeFallingDrown < 0.15f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _rig.velocity = Vector2.up * _jumpForce;
                _totalJump++;
                _animator.SetBool("TaPulando", true);
            }
        }

        // corte do pulo
        CutJump();

        // recupera o pulo
        if (isGround() && _totalJump >= 1)
        {
            _totalJump = 0;
        }
        if (_rig.velocity.y == 0)
        {
            _animator.SetBool("TaPulando", false);
        }
    }
    private void CutJump()
    {
        // corte do  pulo
        if (Input.GetButtonUp("Jump"))
        {
            _rig.velocity = new Vector2(_rig.velocity.x, _rig.velocity.y * 0.5f);
            _totalJump++;
        }
    }
    private bool isGround()
    {
        RaycastHit2D ground = Physics2D.BoxCast(_coll2D.bounds.center,
            _coll2D.bounds.size, 0, Vector2.down, 0.1f, _layerGround);

        return ground.collider != null;
    }
    private void CheckFallingDown()
    {
        if (_rig.velocity.y < 0)
        {
            _timeFallingDrown += Time.deltaTime;
        }
        else
        {
            _timeFallingDrown = 0;
        }

        //if (isGround())
        //{
        //    _timeFallingDrown = 0;
        //}
    }
    private void Initialize()
    {
        _rig = _gameObj.GetComponent<Rigidbody2D>();
        _coll2D = _gameObj.GetComponent<Collider2D>();
        _animator = _gameObj.GetComponent<Animator>();
    }
}
