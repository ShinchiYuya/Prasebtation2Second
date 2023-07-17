using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDef : MonoBehaviour
{

    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] bool  _isGrounded = true;
    [SerializeField] int _jumpcount = 0;
    [SerializeField] int _maxJumpCount = 2;
    [SerializeField] float _downSpeed = 50;

    Rigidbody2D _rb2d;
    Animation _animator;

    float h = 0;
    float v = 0;


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animation>();
    }
    void Update()
    {
        Movement();
        Jump();
    }

     public void Movement()
    {
        h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Velocity");

        Vector2 velocity = new Vector2(h, 0) * _speed;
        _rb2d.velocity = velocity;

        if(Input.GetKey(KeyCode.S))
        {
            _rb2d.AddForce(Vector2.down * _downSpeed);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _maxJumpCount >= _jumpcount)
        {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            //_rb2d.velocity = new Vector2(h, _jumpForce * _speed);
            _isGrounded = false;
            _jumpcount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpcount = 0;
        }
    }
}
