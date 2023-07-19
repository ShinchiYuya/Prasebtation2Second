using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefScript : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] bool _isGrounded = true;
    [SerializeField] int _jumpCount;
    [SerializeField] int _maxJump = 2;

    Rigidbody2D _rb2d;
    Animator _anim;
    float _h = 0;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();

        if (Input.GetKey(KeyCode.S))
        {
            _rb2d.AddForce(Vector2.down * _jumpForce/5);
        }
    }

    void Move()
    {
        _h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(_h * _speed ,_rb2d.velocity.y);
        _rb2d.velocity = velocity;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded || _jumpCount < _maxJump))
        {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
            _isGrounded = false;
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpCount = 0;
        }
    }
}
