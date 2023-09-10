using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _speed = 1f;

    protected Rigidbody2D _rb2d;
    protected Animation _anim;

    protected void Start()
    {
        _anim = GetComponent<Animation>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);//ç∂Ç…à⁄ìÆÇ≥ÇπÇÈ
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}