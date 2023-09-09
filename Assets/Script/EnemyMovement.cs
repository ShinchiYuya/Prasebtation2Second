using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] float _speed;
    //[SerializeField] float _pX, _pY;
    //[SerializeField] float _dur;
    [SerializeField] float _speed = 1f;

    Rigidbody2D _rb2d;
    Animation _anim;

    private void Start()
    {
        _anim = GetComponent<Animation>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.DOLocalMoveX(_pX, _dur).SetEase(Ease.Linear);
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}