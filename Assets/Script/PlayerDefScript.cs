using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefScript : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpForce;
    [SerializeField] public bool _isGrounded = true;
    [SerializeField] public int _jumpCount;
    [SerializeField] public int _maxJump = 2;

    protected Rigidbody2D _rb2d;
    protected Animator _anim;
    protected float _h = 0;

    protected void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    protected void Update()
    {
        Move();
        Jump();

        if (Input.GetKey(KeyCode.S))
        {
            _rb2d.AddForce(Vector2.down * _jumpForce/5);
        }
    }

    protected void Move()
    {
        _h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(_h * _speed ,_rb2d.velocity.y);
        _rb2d.velocity = velocity;
    }

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded || _jumpCount < _maxJump))
        {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
            _isGrounded = false;
        }
    }

    protected void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpCount = 0;
        }
    }
}
